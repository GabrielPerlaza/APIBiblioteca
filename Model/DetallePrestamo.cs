namespace APIBiblioteca.Model
{
    public class DetallePrestamo
    {
        public int IdDetallePrestamo { get; set; }
        public int? IdPrestamo { get; set; }
        public int? IdLibro { get; set; }
        public int? Cantidad { get; set; }
        public virtual Prestamo? IdPrestamoNavigation { get; set; }
        public virtual Libro? IdLibroNavigation { get; set; }

    }
}
