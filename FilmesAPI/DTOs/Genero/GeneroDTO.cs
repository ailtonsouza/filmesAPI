using System.ComponentModel.DataAnnotations;

namespace FilmesAPI.Dtos.Genero
{
    public class GeneroDTO
    {
        public int Id { get; set; }
        
        public virtual string Nome { get; set; }
    }
}