using FilmesAPI.Dtos.Genero;

namespace FilmesAPI.Models.Dtos
{
    public class FilmeGeneroDTO
    {
        public int Id { get; set; }
        
        public GeneroDTO Genero {get; set;}
    }
}