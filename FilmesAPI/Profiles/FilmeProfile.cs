using AutoMapper;
using FilmesAPI.DTOs.Ator;
using FilmesAPI.Entidades;
using FilmesAPI.Models.Dtos;

namespace FilmesAPI.Profiles
{
    public class FilmeProfile : Profile
    {
        public FilmeProfile()
        {
            CreateMap<FilmeDTO, Filme>();
            CreateMap<Filme, FilmeDTO>();
            CreateMap<Filme, FilmeAgreçõesDTO>().ForMember(dest => dest.Atores,
                opt => opt.MapFrom(src => src.FilmeAtor))
                .ForMember(dest => dest.Diretores, 
                    opt => opt.MapFrom(src =>src.FilmeDiretor));
            CreateMap<UpdateFilmeDto, Filme>();
            CreateMap<FilmeAtor, AtorFilmeDTO>();
            CreateMap<FilmeGenero, FilmeGeneroDTO>();
        } 
    }
}