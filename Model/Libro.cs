﻿namespace APIBiblioteca.Model
{
    public class Libro
    {
        public int IdLibro { get; set; }

        public string? Name { get; set; }

        public string? Description { get; set; }

        public DateTime? FechaRegistro { get; set; }
        public bool? EsActivo { get; set; }
        public int? IdCategoria { get; set; }



    }
}