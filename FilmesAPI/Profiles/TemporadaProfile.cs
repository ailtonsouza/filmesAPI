using AutoMapper;
using FilmesAPI.DTOs.Temporada;
using FilmesAPI.Entidades;

namespace FilmesAPI.Profiles
{
    public class TemporadaProfile : Profile
    {
        public TemporadaProfile()
        {
            CreateMap<Temporada, TemporadaDTO>();
            CreateMap<Temporada, TemporadaAtorDiretorDTO>();
            CreateMap< TemporadaDTO, Temporada>();
            CreateMap<Temporada, TemporadaSerieDTO>();
        }
    }
}