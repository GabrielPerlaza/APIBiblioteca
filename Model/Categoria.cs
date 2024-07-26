using System.ComponentModel.DataAnnotations;

namespace APIBiblioteca.Model
{
    public class Categoria
    {
        [Key]
        public int IdCategoria { get; set; }

        public string? Nombre { get; set; }

        public string? Descripcion {  get; set; }

    }
}
