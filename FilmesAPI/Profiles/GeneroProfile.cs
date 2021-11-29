using AutoMapper;
using FilmesAPI.Dtos.Genero;
using FilmesAPI.DTOs.Serie;
using FilmesAPI.Entidades;

namespace FilmesAPI.Profiles
{
    public class GeneroProfile : Profile
    {
        public GeneroProfile()
        {
            CreateMap<GeneroDTO, Genero>();  
            CreateMap<Genero, GeneroDTO>(); 
            CreateMap<Genero, GeneroFilmeDTO>(); 
            CreateMap<Genero, GeneroFilmeDTO>(); 
            
        }
        
    }
}