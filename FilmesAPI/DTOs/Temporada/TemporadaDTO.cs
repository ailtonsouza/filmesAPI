using System.Collections.Generic;
using FilmesAPI.DTOs.Ator;
using FilmesAPI.Dtos.Diretor;
using FilmesAPI.DTOs.Epsodio;
using FilmesAPI.DTOs.Serie;

namespace FilmesAPI.DTOs.Temporada
{
    public class TemporadaDTO
    {
        public virtual int Id { get; set; }
        
        public virtual int NumeroDaTemporada { get; set; }
        
        public virtual SerieDTO Serie { get; set; }
      
        public virtual IList<AtorTemporadaDTO> TemporadaAtor { get; set; }
        
        public virtual IList<DiretorTemporadaDTO> TemporadaDiretor { get; set; }
        
        public virtual IList<EpsodioDTO> Epsodio { get; set; }
    }
}