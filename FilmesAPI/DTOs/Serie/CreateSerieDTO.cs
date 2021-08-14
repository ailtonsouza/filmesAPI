using System.Collections.Generic;
using FilmesAPI.Dtos.Genero;

namespace FilmesAPI.DTOs.Serie
{
    public class CreateSerieDTO
    {
      
        public virtual string Titulo { get; set; }
        public virtual IList<CreateGeneroDto> Genero { get; set; }
        
    }
}