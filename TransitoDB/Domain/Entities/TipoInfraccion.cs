namespace TransitoDB.Domain.Entities
{
    public class TipoInfraccion
    {
        public int TipoInfraccionId { get; set; }
        public string Codigo { get; set; }
        public string Descripcion { get; set; }
        public decimal MontoBase { get; set; }
        public int Puntos { get; set; }
        public bool EsGrave { get; set; }

        // Relaciones
        public ICollection<MultaDetalle> MultaDetalles { get; set; }
    }
}

