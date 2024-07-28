using System.ComponentModel.DataAnnotations;

namespace APIBiblioteca.Model
{
    public partial class Prestamo
    {
        [Key]
        public int IdPrestamo { get; set; }

        public string? NumeroDocumento { get; set; }

        public DateTime? FechaRegistro { get; set; }
        public DateTime? FechaDevolucion { get; set; }

        public Boolean EsActivo { get; set; }

        public virtual ICollection<DetallePrestamo> DetallePrestamo { get; } = new List<DetallePrestamo>();



    }
}
