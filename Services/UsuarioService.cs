using APIBiblioteca.Model;
using APIBiblioteca.Repository;
using Microsoft.EntityFrameworkCore;

namespace APIBiblioteca.Services
{
    public class UsuarioService
    {
        private readonly GenericRepository<Usuario> _usuarioRepository;

        public UsuarioService(GenericRepository<Usuario> usuarioRepository)
        {
            _usuarioRepository = usuarioRepository;
        }

        public async Task<List<Usuario>> Lista()
        {
            var queryUsuario = await _usuarioRepository.Consultar();
            var listaUsuario = queryUsuario.Include(u => u.IdRolNavigation).ToList();

            return listaUsuario;

        }

        public async Task<Usuario> ValidarCredenciales(string correo, string contrasena)
        {
            try
            {
                var queryUsuario = await _usuarioRepository.Consultar(
               u => u.Correo == correo && u.Contrasena == contrasena);
                if (queryUsuario.FirstOrDefault() == null)
                {
                    throw new TaskCanceledException("El usuario no existe");
                }
                Usuario devolverUsuario = queryUsuario.Include(rol => rol.IdRolNavigation).First();
                return devolverUsuario;
            }
            catch
            {
                throw;
            }

        }

        public async Task<Usuario> Crear(Usuario modelo)
        {
            try
            {
                var usuarioCreado = await _usuarioRepository.Crear(modelo);
                if(usuarioCreado.IdUsuario == 0)
                {
                    throw new TaskCanceledException("No se pudo crear el usuario");
                }
                var query = await _usuarioRepository.Consultar(u => u.IdUsuario == usuarioCreado.IdUsuario);
                usuarioCreado = query.Include(rol => rol.IdRolNavigation).First();
                return usuarioCreado;
            }
            catch
            {
                throw;
            }
        }


    }
}
