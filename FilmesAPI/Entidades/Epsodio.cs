using System.ComponentModel.DataAnnotations;

namespace FilmesAPI.Entidades
{
    public class Epsodio
    {
        [Key]
        [Required]
        public virtual int Id { get; set; }
        
        [Required(ErrorMessage = "O campo título é obrigatório")]
        public virtual string Titulo { get; set; }
        
        [Required(ErrorMessage = "O campo título é obrigatório")]
        public virtual int Duracao { get; set; }
        
        public virtual int NumeroEpsodio { get; set; }
        
        public virtual Temporada Temporada { get; set; }
    }
}