using Dapper;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Linq;
using System.Threading.Tasks;
using TransitoDB.Domain.Entities;
using TransitoDB.Domain.Interfaces.IRepositories;
using TransitoDB.Infrastructure.Data;
using TransitoDB.Infrastructure.Data.Repositories;

namespace TransitoApp.Infrastructure.Data.Repositories
{
    public class MultaRepository : GenericRepository<Multa>, IMultaRepository
    {
        private readonly TransitoDbContext _context;
        private readonly IConfiguration _configuration;
        private readonly string _connectionString;

        public MultaRepository(TransitoDbContext context, IConfiguration configuration) : base(context)
        {
            _context = context;
            _configuration = configuration;
            _connectionString = _configuration.GetConnectionString("DefaultConnection");
        }

        public async Task<IEnumerable<Multa>> GetMultasByConductorAsync(int conductorId)
        {
            return await _context.Multas
                .Where(m => m.ConductorId == conductorId)
                .Include(m => m.MultaDetalles)
                .ThenInclude(md => md.TipoInfraccion)
                .Include(m => m.Agente)
                .ThenInclude(a => a.Empleado)
                .OrderByDescending(m => m.FechaHora)
                .ToListAsync();
        }

        public async Task<Multa> GetMultaWithDetailsAsync(long multaId)
        {
            return await _context.Multas
                .Include(m => m.MultaDetalles)
                .ThenInclude(md => md.TipoInfraccion)
                .Include(m => m.Conductor)
                .Include(m => m.Vehiculo)
                .Include(m => m.Agente)
                .ThenInclude(a => a.Empleado)
                .FirstOrDefaultAsync(m => m.MultaId == multaId);
        }

        public async Task<IEnumerable<Multa>> GetMultasConSaldoAsync()
        {
            // Usamos la vista vw_MultasConSaldo
            using (var connection = new SqlConnection(_connectionString))
            {
                await connection.OpenAsync();
                var multas = await connection.QueryAsync<Multa>("SELECT * FROM vw_MultasConSaldo");
                return multas;
            }
        }

        public async Task<long> EmitirMultaAsync(Multa multa, IEnumerable<MultaDetalle> detalles)
        {
            // Usamos el procedimiento almacenado usp_EmitirMulta
            using (var connection = new SqlConnection(_connectionString))
            {
                await connection.OpenAsync();

                var parameters = new DynamicParameters();
                parameters.Add("@Folio", multa.Folio);
                parameters.Add("@ConductorId", multa.ConductorId);
                parameters.Add("@VehiculoId", multa.VehiculoId);
                parameters.Add("@AgenteId", multa.AgenteId);
                parameters.Add("@FechaHora", multa.FechaHora);
                parameters.Add("@Localizacion", multa.Localizacion);
                parameters.Add("@Observaciones", multa.Observaciones);
                parameters.Add("@FechaVence", multa.FechaVencimiento);

                // Crear tabla de detalles
                var detalleTable = new DataTable();
                detalleTable.Columns.Add("TipoInfraccionId", typeof(int));
                detalleTable.Columns.Add("Cantidad", typeof(int));
                detalleTable.Columns.Add("MontoUnitario", typeof(decimal));

                foreach (var detalle in detalles)
                {
                    detalleTable.Rows.Add(detalle.TipoInfraccionId, detalle.Cantidad, detalle.MontoUnitario);
                }

                parameters.Add("@Detalle", detalleTable.AsTableValuedParameter("TVP_MultaDetalle"));

                var multaId = await connection.ExecuteScalarAsync<long>(
                    "usp_EmitirMulta",
                    parameters,
                    commandType: CommandType.StoredProcedure);

                return multaId;
            }
        }

        public async Task RegistrarPagoAsync(Pago pago)
        {
            // Usamos el procedimiento almacenado usp_RegistrarPago
            using (var connection = new SqlConnection(_connectionString))
            {
                await connection.OpenAsync();

                var parameters = new DynamicParameters();
                parameters.Add("@MultaId", pago.MultaId);
                parameters.Add("@Monto", pago.Monto);
                parameters.Add("@Medio", pago.Medio);
                parameters.Add("@Referencia", pago.Referencia);

                await connection.ExecuteAsync(
                    "usp_RegistrarPago",
                    parameters,
                    commandType: CommandType.StoredProcedure);
            }
        }

        public async Task AnularRenglonMultaAsync(long multaDetalleId, int agenteId, string motivo)
        {
            // Usamos el procedimiento almacenado usp_AnularRenglonMulta
            using (var connection = new SqlConnection(_connectionString))
            {
                await connection.OpenAsync();

                var parameters = new DynamicParameters();
                parameters.Add("@MultaDetalleId", multaDetalleId);
                parameters.Add("@AgenteId", agenteId);
                parameters.Add("@Motivo", motivo);

                await connection.ExecuteAsync(
                    "usp_AnularRenglonMulta",
                    parameters,
                    commandType: CommandType.StoredProcedure);
            }
        }
    }
}