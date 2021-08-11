using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace FilmesAPI.Entidades
{
    public class Serie : Midia
    {
        [Required(ErrorMessage = "")]
        public virtual IList<Temporada> Temporadas { get; set; }
    }
}