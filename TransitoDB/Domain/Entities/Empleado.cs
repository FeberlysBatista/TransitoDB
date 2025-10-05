namespace TransitoDB.Domain.Entities
{
    public class Empleado
    {
        public int EmpleadoId { get; set; }
        public string Documento { get; set; }
        public string Nombre { get; set; }
        public string Apellido1 { get; set; }
        public string? Apellido2 { get; set; }
        public string? Email { get; set; }
        public string? Telefono { get; set; }
        public int CargoId { get; set; }
        public bool Activo { get; set; }
        public DateTime FechaAlta { get; set; }

        // Relaciones
        public Cargo Cargo { get; set; }
        public Agente Agente { get; set; }

        //Autenticacion 
        public string? PasswordHash { get; set; }      // BCrypt
        public short IntentosFallidos { get; set; }   // default 0
        public DateTime? BloqueadoHasta { get; set; }
        public DateTime? UltimoLogin { get; set; }
    }

}

