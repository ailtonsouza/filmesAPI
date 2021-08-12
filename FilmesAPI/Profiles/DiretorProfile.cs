using AutoMapper;
using FilmesAPI.Dtos.Diretor;
using FilmesAPI.Entidades;

namespace FilmesAPI.Profiles
{
    public class DiretorProfile : Profile
    {
        public DiretorProfile()
        {
            CreateMap<CreateDiretorDto, Diretor>();
            CreateMap<Diretor, CreateDiretorDto>();
            CreateMap<Diretor, ReadDiretorDto>();
        }
    }
}