using System.Collections.Generic;
using FilmesAPI.Dtos.Ator;
using FilmesAPI.Dtos.Diretor;
using FilmesAPI.DTOs.Serie;

namespace FilmesAPI.DTOs.Temporada
{
    public class ReadTemporadaDTO
    {
        public virtual int Id { get; set; }
        
       public virtual int NumeroDaTemporada { get; set; }
       
       public virtual ReadSerieDTO Serie { get; set; }
        
       public virtual IList<ReadAtorDto> Ator { get; set; }
        
       public virtual IList<ReadDiretorDto> Diretor { get; set; }
        
        

    }
}