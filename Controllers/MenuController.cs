using APIBiblioteca.Services;
using APIBiblioteca.Model;
using APIBiblioteca.Response;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace APIBiblioteca.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MenuController : ControllerBase
    {
       
     private readonly MenuService _menuService;

     public MenuController(MenuService menuService)
     {
        _menuService = menuService;
     }

        [HttpGet]
            [Route("Lista")]
            public async Task<IActionResult> Lista(int idUsuario)
            {
                var rsp = new Response<List<Menu>>();
                try
                {
                    rsp.Status = true;
                    rsp.value = await _menuService.Lista(idUsuario);

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

