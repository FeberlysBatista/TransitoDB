namespace TransitoDB.Application.DTOs
{
    public class PersonaDto
    {
        public int PersonaId { get; set; }
        public string Cedula { get; set; }
        public string Nombre { get; set; }
        public string Apellido1 { get; set; }
        public string Apellido2 { get; set; }
        public string FechaNacimiento { get; set; }
        public string Email { get; set; }
        public string Telefono { get; set; }
        public string Direccion { get; set; }
        public string FechaCreacion { get; set; }
    }
}