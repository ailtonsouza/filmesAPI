using AutoMapper;
using FilmesAPI.Dtos.Genero;
using FilmesAPI.Entidades;

namespace FilmesAPI.Profiles
{
    public class GeneroProfile : Profile
    {
        public GeneroProfile()
        {
            CreateMap<CreateGeneroDto, Genero>();  
            CreateMap<Genero, CreateGeneroDto>(); 
            CreateMap<Genero, ReadGeneroDto>(); 
            CreateMap<ReadGeneroDto, Genero>(); 
        }
    }
}