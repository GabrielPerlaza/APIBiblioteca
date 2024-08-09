using APIBiblioteca.Model;

namespace APIBiblioteca.Repository.Contrato
{
    public interface IPrestamoRepository : IGenericRepository<Prestamo>
    {
        Task<Prestamo> Registrar(Prestamo modelo);
    }
}
