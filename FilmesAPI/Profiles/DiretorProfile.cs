using AutoMapper;
using FilmesAPI.DTOs.Ator;
using FilmesAPI.Dtos.Diretor;
using FilmesAPI.Entidades;

namespace FilmesAPI.Profiles
{
    public class DiretorProfile : Profile
    {
        public DiretorProfile()
        {
            CreateMap<DiretorDTO, Diretor>();
            CreateMap<Diretor, DiretorDTO>();
            CreateMap<FilmeDiretor, DiretorFilme>();
            CreateMap<TemporadaDiretor, DiretorTemporadaDTO>();
        }
    }
}