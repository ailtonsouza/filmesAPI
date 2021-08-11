using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace FilmesAPI.Entidades
{
    public abstract class Midia
    {
        [Key]
        [Required]
        public virtual int Id { get; set; }
        
        [Required(ErrorMessage = "O campo título é obrigatório")]
        public virtual string Titulo { get; set; }
        
        public virtual IList<Genero> Genero { get; set; }

    }
}