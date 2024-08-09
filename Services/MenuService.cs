using APIBiblioteca.Model;
using APIBiblioteca.Repository;
using APIBiblioteca.Repository.Contrato;

namespace APIBiblioteca.Services
{
    public class MenuService
    {
        private readonly IGenericRepository<Usuario> _usuarioRepository;
        private readonly IGenericRepository<MenuRol> _menuRolRepository;
        private readonly IGenericRepository<Menu> _menuRepository;


        public MenuService(IGenericRepository<Usuario> usuarioRepository, IGenericRepository<MenuRol> menuRolRepository, IGenericRepository<Menu> menuRepository)
        {
            _usuarioRepository = usuarioRepository;
            _menuRolRepository = menuRolRepository;
            _menuRepository = menuRepository;
        }
        
        public async Task<List<Menu>> Lista(int idUsuario)
        {
            IQueryable<Usuario> tbUsuario = await _usuarioRepository.Consultar(u => u.IdUsuario == idUsuario);
            IQueryable<Menu> tbMenu = await _menuRepository.Consultar();
            IQueryable<MenuRol> tbMenuRol = await _menuRolRepository.Consultar();

            try
            {
                IQueryable<Menu> tbResultado = (from u in tbUsuario
                                                join mr in tbMenuRol on u.IdRol equals mr.IdRol
                                                join m in tbMenu on mr.IdMenu equals m.IdMenu
                                                select m).AsQueryable();
                var listaMenus = tbResultado.ToList();
                return listaMenus;
            }
            catch
            {
                throw;
            }

        }

        }
    }

