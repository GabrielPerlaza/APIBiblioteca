using APIBiblioteca.Model;
using APIBiblioteca.Repository;
using AutoMapper;

namespace APIBiblioteca.Services
{
    public class RolService
    {
        private readonly GenericRepository<Rol> _rolRepository;
        private readonly IMapper _mapper;

        public RolService(GenericRepository<Rol> rolRepository)
        {
            _rolRepository = rolRepository;

        }

        public async Task<List<Rol>> Lista()
        {
            try
            {
                var listaRoles = await _rolRepository.Consultar();
                return listaRoles.ToList();
            }
            catch
            {
                throw;
            }
        }

    }
}
