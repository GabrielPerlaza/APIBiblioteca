using APIBiblioteca.Model;
using APIBiblioteca.Repository;
using Microsoft.EntityFrameworkCore;
using APIBiblioteca.Repository.Contrato;
namespace APIBiblioteca.Services
{
    public class UsuarioService
    {
        private readonly IGenericRepository<Usuario> _usuarioRepository;

        public UsuarioService(IGenericRepository<Usuario> usuarioRepository)
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

        public async Task<bool> Editar(Usuario modelo)
        {
            
            try
            {
                var usuarioEncontrado = await _usuarioRepository.Obtener(
                    u => u.IdUsuario == modelo.IdUsuario
                    );

                if(usuarioEncontrado == null)
                {
                    throw new TaskCanceledException("No se encontro el usuario");
                }

                usuarioEncontrado.Nombre = modelo.Nombre;
                usuarioEncontrado.Correo = modelo.Correo;
                usuarioEncontrado.Contrasena = modelo.Contrasena;
                usuarioEncontrado.IdRol = modelo.IdRol;
                usuarioEncontrado.EsActivo = modelo.EsActivo;
                bool respuesta = await _usuarioRepository.Editar(usuarioEncontrado);
                if (!respuesta)
                {
                    throw new TaskCanceledException("No se encontro el usuario");
                }
                return respuesta;
            }
            catch
            {
                throw;
            }
        }

        public async Task<bool> Eliminar(int idUsuario)
        {
            try
            {
                var usuarioEncontrado = await _usuarioRepository.Obtener(
                    u => u.IdUsuario == idUsuario
                    );
                if (usuarioEncontrado == null) {
                    throw new TaskCanceledException("No se pudo encontrar el usuario");
                }

                bool respuesta = await _usuarioRepository.Eliminar(usuarioEncontrado);

                if (!respuesta)
                {
                    throw new TaskCanceledException("No se pudo eliminar");
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
