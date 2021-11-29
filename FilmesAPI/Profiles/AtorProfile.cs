using AutoMapper;
using FilmesAPI.DTOs.Ator;
using FilmesAPI.Entidades;

namespace FilmesAPI.Profiles
{
    public class AtorProfile : Profile
    {
        public AtorProfile()
        {
            CreateMap<AtorDTO, Ator>();
            CreateMap<Ator, AtorDTO>();
            CreateMap<Ator, AtorDTO>();
            CreateMap<FilmeAtor, AtorFilmeDTO>();
            CreateMap<TemporadaAtor, AtorTemporadaDTO>();
        }
    }
}