using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;


namespace FilmesAPI.Dtos.Diretor
{
    public class ReadDiretorDto
    {
         [Key]
         [Required]
          public int Id { get; set; }
        
           public string nomeCompleto { get; set; }
        
           public virtual string dataNascimento { get; set; }

    }
}