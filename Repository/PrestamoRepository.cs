using APIBiblioteca.LibraryDbContext;
using APIBiblioteca.Model;
using APIBiblioteca.Repository.Contrato;

namespace APIBiblioteca.Repository
{
    public class PrestamoRepository : GenericRepository<Prestamo>, IPrestamoRepository
    {
        private readonly BibliotecaDbContext _bibliotecaDbContext;
        public PrestamoRepository(BibliotecaDbContext bibliotecaDbContext) : base(bibliotecaDbContext)
        {
            _bibliotecaDbContext = bibliotecaDbContext;
        }


        public async Task<Prestamo> Registrar(Prestamo modelo)
        {
            Prestamo prestamoGenerado = new Prestamo();


            using (var transaction = _bibliotecaDbContext.Database.BeginTransaction()) {
                try
                {
                    foreach (DetallePrestamo dP in modelo.DetallePrestamo)
                    {
                        Libro libroEncontrado = _bibliotecaDbContext.Libros.Where(p => p.IdLibro == dP.IdLibro).First();
                        libroEncontrado.Stock = libroEncontrado.Stock - dP.Cantidad;
                        
                        _bibliotecaDbContext.Libros.Update(libroEncontrado);
                    }
                    await _bibliotecaDbContext.SaveChangesAsync();

                    NumeroDocumento correlativo = _bibliotecaDbContext.NumeroDocumentos.First();

                    correlativo.UltimoNumero = correlativo.UltimoNumero + 1;

                    correlativo.FechaRegistro = DateTime.Now;

                    await _bibliotecaDbContext.SaveChangesAsync();

                    _bibliotecaDbContext.NumeroDocumentos.Update(correlativo);

                    await _bibliotecaDbContext.SaveChangesAsync();

                    int CantidadDigitos = 4;
                    string ceros = string.Concat(Enumerable.Repeat("0", CantidadDigitos));

                    string numeroPrestamo = ceros + correlativo.UltimoNumero.ToString();

                    numeroPrestamo = numeroPrestamo.Substring(numeroPrestamo.Length - CantidadDigitos, CantidadDigitos);

                    modelo.NumeroDocumento = numeroPrestamo;

                    await _bibliotecaDbContext.AddAsync(modelo);
                    await _bibliotecaDbContext.SaveChangesAsync();

                    prestamoGenerado = modelo;

                    transaction.Commit();
                }
                catch
                {
                    transaction.Rollback();
                    throw;
                }
                return prestamoGenerado;
            }

        }

    }
}
