using APIBiblioteca.Repository;
using APIBiblioteca.Model;
using Microsoft.EntityFrameworkCore;
using AutoMapper;
using APIBiblioteca.Repository.Contrato;
using System.Linq.Expressions;
namespace APIBiblioteca.Services
{
    public class LibroService
    {
        private readonly IGenericRepository<Libro> _libroRepository;
 

        public LibroService(IGenericRepository<Libro> libroRepository)
        {
            _libroRepository = libroRepository;
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

                libroEncontrado.Descripcion = modelo.Descripcion;
                libroEncontrado.Stock = modelo.Stock;
                libroEncontrado.FechaRegistro = modelo.FechaRegistro;
                libroEncontrado.IdCategoria = modelo.IdCategoria;
                libroEncontrado.Nombre = modelo.Nombre;


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
                    
                var libroEncontrado = await _libroRepository.Obtener(p => p.IdLibro == id);

                if (libroEncontrado == null)
                {
                    throw new TaskCanceledException("No se logro encontrar el producto");
                }
                bool respuesta = await _libroRepository.Eliminar(libroEncontrado);

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
