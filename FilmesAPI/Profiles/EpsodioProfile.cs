using AutoMapper;
using FilmesAPI.DTOs.Epsodio;
using FilmesAPI.Entidades;

namespace FilmesAPI.Profiles
{
    public class EpsodioProfile : Profile
    {
        public EpsodioProfile()
        {
            CreateMap<Epsodio, EpsodioDTO>();
            CreateMap<Epsodio, EpsodioTemporadaDTO>();
            CreateMap<EpsodioDTO, Epsodio>();
        }
    }
}