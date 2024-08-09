using Microsoft.AspNetCore.Mvc;
using APIBiblioteca.Response;
using Microsoft.AspNetCore.Http;
using APIBiblioteca.Services;
using APIBiblioteca.Model;
// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace APIBiblioteca.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PrestamoController : ControllerBase
    {
        private readonly PrestamoService _prestamoService;

        public PrestamoController(PrestamoService prestamoService)
        {
            _prestamoService = prestamoService;
        }

        [HttpPost]
        [Route("Registrar")]

        public async Task<IActionResult> Registrar([FromBody] Prestamo prestamo)
        {
            var rsp = new Response<Prestamo>();
            try
            {
                rsp.Status = true;
                rsp.value = await _prestamoService.Registrar(prestamo);

            }
            catch (Exception ex)
            {
                rsp.Status = false;
                rsp.msg = ex.Message;
            }
            return Ok(rsp);
        }

        [HttpGet]
        [Route("Historial")]
        public async Task<IActionResult> Historial(string buscarPor, string? numeroVenta, string? fechaInicio, string? fechaFin)
        {
            var rsp = new Response<List<Prestamo>>();
            numeroVenta = numeroVenta is null ? "" : numeroVenta;
            fechaInicio = fechaInicio is null ? "" : fechaInicio;
            fechaFin = fechaFin is null ? "" : fechaFin;

            try
            {
                rsp.Status = true;
                rsp.value = await _prestamoService.Historial(buscarPor, numeroVenta, fechaInicio, fechaFin);

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
