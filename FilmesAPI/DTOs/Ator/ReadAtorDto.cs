using System.ComponentModel.DataAnnotations;

namespace FilmesAPI.Dtos.Ator
{
    public class ReadAtorDto
    {
        [Key]
        [Required]
        public int Id { get; set; }
        
        public string nomeCompleto { get; set; }
        
        public virtual string dataNascimento { get; set; }
    }
}