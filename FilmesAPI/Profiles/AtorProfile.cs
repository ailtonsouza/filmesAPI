using AutoMapper;
using FilmesAPI.Dtos.Ator;
using FilmesAPI.Entidades;

namespace FilmesAPI.Profiles
{
    public class AtorProfile : Profile
    {
        public AtorProfile()
        {
            CreateMap<CreateAtorDto, Ator>();
            CreateMap<Ator, CreateAtorDto>();
            CreateMap<Ator, ReadAtorDto>();
        }
    }
}