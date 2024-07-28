using APIBiblioteca.LibraryDbContext;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace APIBiblioteca.Repository
{
    public class GenericRepository<Tmodelo> where Tmodelo : class
    {
        private readonly BibliotecaDbContext _bibliotecaDbContext;

        public GenericRepository(BibliotecaDbContext bibliotecaDbContext)
        {
            _bibliotecaDbContext = bibliotecaDbContext;
        }

        public async Task<Tmodelo> Obtener(Expression<Func<Tmodelo, bool>> Filtro)
        {
            try
            {
                Tmodelo modelo = await _bibliotecaDbContext.Set<Tmodelo>().FirstOrDefaultAsync(Filtro);
                return modelo;
            }
            catch
            {
                throw;
            }
        }

        public async Task<Tmodelo> Crear(Tmodelo modelo)
        {
            try
            {
                await _bibliotecaDbContext.Set<Tmodelo>().AddAsync(modelo);
                await _bibliotecaDbContext.SaveChangesAsync();
                return modelo;

            }
            catch
            {
                throw;
            }
        }

        public async Task<bool> Editar(Tmodelo modelo)
        {
            try
            {
                _bibliotecaDbContext.Set<Tmodelo>().Update(modelo);
                await _bibliotecaDbContext.SaveChangesAsync();
                return true;
            }
            catch
            {
                throw;
            }
        }

        public async Task<bool> Eliminar(Tmodelo modelo)
        {
            try
            {
                _bibliotecaDbContext.Set<Tmodelo>().Remove(modelo);
                await _bibliotecaDbContext.SaveChangesAsync();
                return true;
            }
            catch
            {
                throw;
            }

        }

        public async Task<IQueryable<Tmodelo>> Consultar (Expression<Func<Tmodelo, bool>> Filtro = null)
        {
            try
            {
                IQueryable<Tmodelo> queryModelo = Filtro == null ? _bibliotecaDbContext.Set<Tmodelo>() : _bibliotecaDbContext.Set<Tmodelo>().Where(Filtro);
                return queryModelo;

            }
            catch
            {
                throw;
            }
        }


    }
}
