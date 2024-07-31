using System.ComponentModel.DataAnnotations;

namespace APIBiblioteca.Model
{
    public class NumeroDocumento
    {
        [Key] public int IdNumeroDocumento { get; set; }
        public int UltimoNumero {  get; set; }
        public DateTime FechaRegistro { get; set; }

    }
}
