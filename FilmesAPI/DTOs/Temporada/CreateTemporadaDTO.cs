using System.Collections.Generic;
using FilmesAPI.Dtos.Ator;
using FilmesAPI.Dtos.Diretor;

namespace FilmesAPI.DTOs.Temporada
{
    public class CreateTemporadaDTO
    {
        public virtual int Id { get; set; }
        public virtual int SerieId { get; set; }

        public virtual int NumeroDaTemporada { get; set; }
        
        public virtual IList<CreateDiretorDto> Diretor { get; set; }
        
        public virtual IList<CreateAtorDto> Ator { get; set; }
    }
}