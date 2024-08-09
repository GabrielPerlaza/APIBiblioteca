using APIBiblioteca.Model;
using APIBiblioteca.Repository;
using AutoMapper;
using APIBiblioteca.Repository.Contrato;

namespace APIBiblioteca.Services
{
    public class RolService
    {
        private readonly IGenericRepository<Rol> _rolRepository;
        private readonly IMapper _mapper;

        public RolService(IGenericRepository<Rol> rolRepository)
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
