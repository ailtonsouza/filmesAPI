using AutoMapper;
using FilmesAPI.Entidades;
using FilmesAPI.Models.Dtos;

namespace FilmesAPI.Profiles
{
    public class FilmeProfile : Profile
    {
        public FilmeProfile()
        {
            CreateMap<Filme, ReadFilmeDto>();
            CreateMap<CreateFilmeDto, Filme>();
            CreateMap<Filme, ReadFilmeDto>();
            CreateMap<UpdateFilmeDto, Filme>();
            CreateMap<Filme,ReadFilmeSemOscarDTO>();
        } 
    }
}