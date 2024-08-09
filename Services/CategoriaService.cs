using APIBiblioteca.Model;
using APIBiblioteca.Repository;
using APIBiblioteca.Repository.Contrato;
namespace APIBiblioteca.Services
{
    public class CategoriaService
    {
        private readonly IGenericRepository<Categoria> _categoriaRepository;

        public CategoriaService(IGenericRepository<Categoria> categoriaRepository)
        {
            _categoriaRepository = categoriaRepository;
        }

        public async Task<List<Categoria>> Lista()
        {
            try
            {
                var listaCategoria = await _categoriaRepository.Consultar();
                return listaCategoria.ToList();

            }
            catch
            {
                throw;
            }
        }

        
        
    }
}
