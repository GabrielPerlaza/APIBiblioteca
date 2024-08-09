using APIBiblioteca.Model;
using APIBiblioteca.Repository;
using AutoMapper;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore;
using Microsoft.Identity.Client;
using APIBiblioteca.Repository.Contrato;
using System.Globalization;

namespace APIBiblioteca.Services
{
    public class PrestamoService
    {
        private readonly IGenericRepository<DetallePrestamo> _dpRepository;
        private readonly PrestamoRepository _prestamoRepository;


        public PrestamoService(IGenericRepository<DetallePrestamo> dpRepository, PrestamoRepository prestamoRepository)
        {
            _prestamoRepository = prestamoRepository;
            _dpRepository = dpRepository;
        }

        public async Task<Prestamo> Registrar(Prestamo modelo)
        {
            try
            {
                var prestamoGenerado = await _prestamoRepository.Registrar(modelo);
                if(prestamoGenerado.IdPrestamo == 0)
                {
                    throw new TaskCanceledException("No se pudo generar la venta");
                }
                return prestamoGenerado;
            }
            catch
            {
                throw;
            }
        }
      public async Task<List<Prestamo>> Historial (string buscarPor, string numeroVenta, string fechaInicio, string fechaFin)
        {
            IQueryable<Prestamo> query = await _prestamoRepository.Consultar();
            var ListaResultado = new List<Prestamo>();

            try
            {
                if (buscarPor == "fecha")
                {
                    DateTime fechInicio = DateTime.ParseExact(fechaInicio, "dd/MM/yyyy", new CultureInfo("es-ECU"));
                    DateTime fechFin = DateTime.ParseExact(fechaFin, "dd/MM/yyyy", new CultureInfo("es-ECU"));

                    ListaResultado = await query.Where(v =>
                    v.FechaRegistro.Value.Date >= fechInicio.Date && v.FechaRegistro.Value.Date <= fechFin.Date
                    ).Include(dp => dp.DetallePrestamo).ThenInclude(p => p.IdLibroNavigation).ToListAsync();

                }
                else
                {
                    ListaResultado = await query.Where(v =>
                        v.NumeroDocumento == numeroVenta)
                        .Include(dv => dv.DetallePrestamo).ThenInclude(p => p.IdLibroNavigation).ToListAsync();
                }
                
            }
            catch
            {
                throw;
            }
            return ListaResultado;
        }

    }
}
