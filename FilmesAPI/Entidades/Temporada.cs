using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace FilmesAPI.Entidades
{
    public class Temporada
    {
        [Key]
        [Required]
        public virtual int Id { get; set; }
        
        [Required(ErrorMessage = "")]
        public virtual Serie Serie { get; set; }
        
        [Required(ErrorMessage = "")]
        public virtual int NumeroDaTemporada { get; set; }
        
        [Required(ErrorMessage = "")]
        public virtual IList<Epsodio> Epsodio { get; set; }
        
        [Required(ErrorMessage = "O campo diretor é obrigatório")]
        public virtual IList<TemporadaAtor> TemporadaAtor { get; set; }
        
        [Required(ErrorMessage = "O campo diretor é obrigatório")]
        public virtual IList<TemporadaDiretor> TemporadaDiretor { get; set; }
        
    }
}