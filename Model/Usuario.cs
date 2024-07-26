using System.ComponentModel.DataAnnotations;

namespace APIBiblioteca.Model
{
    public class Usuario
    {
        [Key]
        public int IdUsuario { get; set; }
        public string? Nombre { get; set; }
        public string? Correo { get; set; }
        public string? Contrasena { get; set; }
        public int IdRol {  get; set; }
        public virtual Rol? IdRolNavigation { get; set; }


    }
}
