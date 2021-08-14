using AutoMapper;
using FilmesAPI.DTOs.Serie;
using FilmesAPI.Entidades;

namespace FilmesAPI.Profiles
{
    public class SerieProfile : Profile
    {
        public SerieProfile()
        {
            CreateMap<CreateSerieDTO, Serie>();
            CreateMap<Serie, CreateSerieDTO>();
            CreateMap<Serie, ReadSerieDTO>();
        }
    }
}