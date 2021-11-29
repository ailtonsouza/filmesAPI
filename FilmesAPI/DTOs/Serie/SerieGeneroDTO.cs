using FilmesAPI.Dtos.Genero;

namespace FilmesAPI.DTOs.Serie
{
    public class SerieGeneroDTO
    {
        public virtual int Id { get; set; }
        
        public virtual GeneroDTO Genero { get; set; }
    }
}