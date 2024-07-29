using APIBiblioteca.Repository;
using APIBiblioteca.Model;
using Microsoft.EntityFrameworkCore;
using AutoMapper;
using System.Linq.Expressions;
namespace APIBiblioteca.Services
{
    public class LibroService
    {
        private readonly GenericRepository<Libro> _libroRepository;
        private readonly IMapper _mapper;

        public LibroService(GenericRepository<Libro> libroRepository, IMapper mapper)
        {
            _libroRepository = libroRepository;
            _mapper = mapper;
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
            try
            {
                var libroEncontrado = await _libroRepository.Obtener(u => u.IdLibro == modelo.IdLibro);

                if (libroEncontrado == null)
                {
                    throw new TaskCanceledException("El producto no existe");
                }

                _mapper.Map(modelo, libroEncontrado);

                
                await _libroRepository.Editar(libroEncontrado);

                return true;
            }
            catch (Exception ex)
            {
                throw;
            }

        }

        public async Task<bool> Eliminar(int id)
        {

            try
            {
                var libroEncontrado = _libroRepository.Obtener(
                    p => p.IdLibro == id
                    );
                if (libroEncontrado == null)
                {
                    throw new TaskCanceledException("No se logro encontrar el producto");
                }
                bool respuesta = await _libroRepository.Eliminar(_mapper.Map<Libro>(libroEncontrado));

                if (!respuesta)
                {
                    throw new TaskCanceledException("No se pudo eliminar el producto");
                }
                return respuesta;
            }
            catch
            {
                throw;
            }
        }





    }
}
