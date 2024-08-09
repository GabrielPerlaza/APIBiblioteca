using APIBiblioteca.Services;
using APIBiblioteca.Response;
using APIBiblioteca.Model;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace APIBiblioteca.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RolController : ControllerBase
    {
        private readonly RolService _rolServicio;

        public RolController(RolService rolServicio)
        {
            _rolServicio = rolServicio;
        }

        [HttpGet]
        [Route("Lista")]
        public async Task<IActionResult> Lista()
        {
            var rsp = new Response<List<Rol>>();

            try
            {
                rsp.Status = true;
                rsp.value = await _rolServicio.Lista();


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

