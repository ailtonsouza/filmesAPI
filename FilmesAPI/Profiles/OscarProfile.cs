using AutoMapper;
using FilmesAPI.Entidades;
using FilmesAPI.Models.Dtos;

namespace FilmesAPI.Profiles
{
    public class OscarProfile : Profile
    {
        public OscarProfile()
        {
            CreateMap<CreateOscarDto, Oscar>();
            CreateMap<Oscar, ReadOscarDto>();
            CreateMap<Oscar, ReadOscarAndFilmeDto>();
            CreateMap<Oscar, CreateOscarDto>();
        }
    }
}