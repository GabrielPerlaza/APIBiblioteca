using APIBiblioteca.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
namespace APIBiblioteca.LibraryDbContext
{
    public  class BibliotecaDbContext : DbContext
    {
        public DbSet<Categoria> Categorias { get; set; }
        public DbSet<DetallePrestamo> DetallePrestamos { get; set; }
        public DbSet<Libro> Libros { get; set; }
        public DbSet<Menu> Menus { get; set; }
        public DbSet<MenuRol> MenuRoles { get; set; }
        public DbSet<Prestamo> Prestamos { get; set; }
        public DbSet<Rol> Roles {  get; set; }
        public DbSet<Usuario> Usuarios { get; set; }

        public DbSet<NumeroDocumento> NumeroDocumentos { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=DESKTOP-SKRMAA5;Database=BibliotecaDB;Integrated Security=True;TrustServerCertificate=True;");
        }

        public BibliotecaDbContext(DbContextOptions<BibliotecaDbContext> options) : base(options)
        {
        }


    }
}
