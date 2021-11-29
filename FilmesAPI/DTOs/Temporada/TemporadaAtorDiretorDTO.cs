using System.Collections.Generic;
using FilmesAPI.DTOs.Ator;
using FilmesAPI.Dtos.Diretor;
using FilmesAPI.DTOs.Serie;

namespace FilmesAPI.DTOs.Temporada
{
    public class TemporadaAtorDiretorDTO
    {
      
         public virtual int Id { get; set; }
        
         public virtual int NumeroDaTemporada { get; set; }
        
      
         public virtual IList<AtorTemporadaDTO> TemporadaAtor { get; set; }
        
         public virtual IList<DiretorTemporadaDTO> TemporadaDiretor { get; set; }
    }
}