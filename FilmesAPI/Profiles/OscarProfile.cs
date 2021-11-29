using AutoMapper;
using FilmesAPI.Entidades;
using FilmesAPI.Models.Dtos;

namespace FilmesAPI.Profiles
{
    public class OscarProfile : Profile
    {
        public OscarProfile()
        {
            CreateMap<OscarDTO, Oscar>();
            CreateMap<Oscar, OscarDTO>();
            CreateMap<Oscar, OscarFilmeDTO>();
        }
    }
}