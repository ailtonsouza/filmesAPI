using System.Collections.Generic;

namespace FilmesAPI.Dtos.Genero
{
    public class GeneroFilmeDTO
    {
        public int Id { get; set; }
        
        public GeneroDTO Genero {get; set;}
    }
}