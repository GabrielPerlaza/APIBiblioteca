﻿using APIBiblioteca.Services;
using APIBiblioteca.Model;
using APIBiblioteca.Response;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace APIBiblioteca.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LibroController : ControllerBase
    {
        private readonly LibroService _libroService;
        public LibroController(LibroService libroservice)
        {
            _libroService = libroservice;
        }


        // GET: api/<LibroController>
        [HttpGet]
        [Route("Lista")]
        public async Task<IActionResult> Lista()
        {
            var rsp = new Response<List<Libro>>();

            try
            {
                rsp.Status = true;
                rsp.value = await _libroService.Lista();
            }
            catch(Exception ex)
            {
                rsp.Status = false;
                rsp.msg = ex.Message;
            }


            return Ok(rsp);
        }

        // GET api/<LibroController>/5
      

        // POST api/<LibroController>
        [HttpPost]
        [Route("Guardar")]
        public async Task<IActionResult> Guardar([FromBody] Libro libro)
        {
            var rsp = new Response<Libro>();
            try
            {
                rsp.Status = true;
                rsp.value = await _libroService.Crear(libro);

            }
            catch (Exception ex)
            {
                rsp.Status = false;
                rsp.msg = ex.Message;
            }
            return Ok(rsp);
        }

        // PUT api/<LibroController>/5
        [HttpPut]
        [Route("Editar")]
        public async Task<IActionResult> Editar([FromBody] Libro libro)
        {
            var rsp = new Response<bool>();
            try
            {
                rsp.Status = true;
                rsp.value = await _libroService.Editar(libro);

            }
            catch (Exception ex)
            {
                rsp.Status = false;
                rsp.msg = ex.Message;
            }
            return Ok(rsp);

        }

        // DELETE api/<LibroController>/5
        [HttpDelete]
        [Route("Eliminar/{id:int}")]
        public async Task<IActionResult> Delete(int id)
        {
            var rsp = new Response<bool>();

            try
            {
                rsp.Status = true;
                rsp.value = await _libroService.Eliminar(id);

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
