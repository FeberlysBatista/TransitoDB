namespace TransitoDB.Application.DTOs
{
    public class PagoRegistrarDto
    {
        public long MultaId { get; set; }
        public decimal Monto { get; set; }
        public string Medio { get; set; }
        public string Referencia { get; set; }
    }
}