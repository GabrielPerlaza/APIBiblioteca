using APIBiblioteca.Repository;
using APIBiblioteca.Model;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
namespace APIBiblioteca.Services
{
    public class LibroService
    {
        private readonly GenericRepository<Libro> _libroRepository;

        public LibroService(GenericRepository<Libro> libroRepository)
        {
            _libroRepository=libroRepository;
        }

        public async Task<List<Libro>> Lista()
        {
            try
            {
                var queryLibro = await _libroRepository.Consultar();
                var listaLibro = queryLibro.Include(cat => cat.IdCategoriaNavigation).ToList();

                return listaLibro.ToList();
            }
            catch
            {
                throw;
            }
        }

        public async Task<Libro> Crear(Libro modelo)
        {
            try{
                var libroCreado = await _libroRepository.Crear(modelo);

                if (libroCreado.IdLibro == 0)
                {
                    throw new TaskCanceledException("No se pudo crear el producto");
                }
                return libroCreado;
            }
            catch
            {
                throw;
            }

        }


        public async Task<bool> Editar(Libro modelo)
        {
            return false;

        }

    }
}
