using System.ComponentModel.DataAnnotations;

namespace APIBiblioteca.Model
{
    public class Menu
    {
        [Key]
        public int IdMenu { get; set; }

        public string? Nombre { get; set; }

        public string? Link { get; set; }

        public virtual ICollection<MenuRol> MenuRols { get; } = new List<MenuRol>();
    }
}

