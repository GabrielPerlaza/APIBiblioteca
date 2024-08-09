using APIBiblioteca.Services;
using APIBiblioteca.Model;
using APIBiblioteca.Response;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace APIBiblioteca.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuarioController : ControllerBase
    {
        // GET: api/<UsuarioController>
        private readonly UsuarioService _usuarioService;

        public UsuarioController(UsuarioService usuarioService)
        {
            _usuarioService = usuarioService;
        }

        [HttpGet]
        [Route("Lista")]
        public async Task<IActionResult> Lista()
        {
            var rsp = new Response<List<Usuario>>();
            try
            {
                rsp.Status = true;
                rsp.value = await _usuarioService.Lista();

            }
            catch (Exception ex)
            {
                rsp.Status = false;
                rsp.msg = ex.Message;
            }
            return Ok(rsp);
        }

        [HttpPost]
        [Route("IniciarSesion")]

        public async Task<IActionResult> IniciarSesion([FromBody] Usuario login)
        {
            var rsp = new Response<Usuario>();
            try
            {
                rsp.Status = true;
                rsp.value = await _usuarioService.ValidarCredenciales(login.Correo, login.Contrasena);

            }
            catch (Exception ex)
            {
                rsp.Status = false;
                rsp.msg = ex.Message;
            }
            return Ok(rsp);
        }

        [HttpPost]
        [Route("Guardar")]

        public async Task<IActionResult> Guardar([FromBody] Usuario usuario)
        {
            var rsp = new Response<Usuario>();
            try
            {
                rsp.Status = true;
                rsp.value = await _usuarioService.Crear(usuario);

            }
            catch (Exception ex)
            {
                rsp.Status = false;
                rsp.msg = ex.Message;
            }
            return Ok(rsp);
        }


        [HttpPut]
        [Route("Editar")]

        public async Task<IActionResult> Editar([FromBody] Usuario usuario)
        {
            var rsp = new Response<bool>();
            try
            {
                rsp.Status = true;
                rsp.value = await _usuarioService.Editar(usuario);

            }
            catch (Exception ex)
            {
                rsp.Status = false;
                rsp.msg = ex.Message;
            }
            return Ok(rsp);
        }


        [HttpDelete]
        [Route("Eliminar/{id:int}")]

        public async Task<IActionResult> Eliminar(int id)
        {
            var rsp = new Response<bool>();

            try
            {
                rsp.Status = true;
                rsp.value = await _usuarioService.Eliminar(id);

            }
            catch (Exception ex)
            {
                rsp.Status = false;
                rsp.msg = ex.Message;
            }
            return Ok(rsp);
        }
    }
}
