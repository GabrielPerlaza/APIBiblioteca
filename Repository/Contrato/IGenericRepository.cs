using APIBiblioteca.LibraryDbContext;
using System.Linq.Expressions;

namespace APIBiblioteca.Repository.Contrato
{
    public interface IGenericRepository <Tmodelo> where Tmodelo : class
    {
        Task<Tmodelo> Obtener(Expression<Func<Tmodelo, bool>> Filtro);


        Task<Tmodelo> Crear(Tmodelo modelo);


        Task<bool> Editar(Tmodelo modelo);
        

        Task<bool> Eliminar(Tmodelo modelo);


        Task<IQueryable<Tmodelo>> Consultar(Expression<Func<Tmodelo, bool>> Filtro = null);
       
    }
}
