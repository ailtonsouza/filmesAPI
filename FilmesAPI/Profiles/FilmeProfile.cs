using AutoMapper;
using FilmesAPI.Entidades;
using FilmesAPI.Models.Dtos;

namespace FilmesAPI.Profiles
{
    public class FilmeProfile : Profile
    {
        public FilmeProfile()
        {
            CreateMap<Filme, ReadFilmeAndOscarDto>();
            CreateMap<CreateFilmeDto, Filme>();
            CreateMap<Filme, ReadFilmeDto>();
            CreateMap<UpdateFilmeDto, Filme>();
        } 
    }
}