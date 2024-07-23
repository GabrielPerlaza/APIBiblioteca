namespace APIBiblioteca.Model
{
    public partial class Prestamo
    {
        public int IdPrestamo { get; set; }

        public string? NumeroDocumento { get; set; }

        public DateTime? FechaRegistro { get; set; }

        public virtual ICollection<DetallePrestamo> DetallePrestamo { get; } = new List<DetallePrestamo>();



    }
}
