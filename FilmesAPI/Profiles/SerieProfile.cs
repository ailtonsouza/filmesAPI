using AutoMapper;
using FilmesAPI.DTOs.Serie;
using FilmesAPI.Entidades;

namespace FilmesAPI.Profiles
{
    public class SerieProfile : Profile
    {
        public SerieProfile()
        {
            CreateMap<SerieDTO, Serie>();
            CreateMap<Serie, SerieDTO>();
            CreateMap<Serie, SerieDTO>();
            CreateMap<Serie, SerieAgregaçõesDTO>();
            CreateMap<SerieGenero, SerieGeneroDTO>();
        }
    }
}