using APIBiblioteca.Model;
using APIBiblioteca.Repository;

namespace APIBiblioteca.Services
{
    public class CategoriaService
    {
        private readonly GenericRepository<Categoria> _categoriaRepository;

        public CategoriaService(GenericRepository<Categoria> categoriaRepository)
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
