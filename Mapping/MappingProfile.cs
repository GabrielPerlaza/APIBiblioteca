using APIBiblioteca.Model;
using AutoMapper;

namespace APIBiblioteca.Mapping
{
    public class MappingProfile : Profile
    {
        public MappingProfile() 
        {
            CreateMap<Libro, Libro>();
        }
    }
}
