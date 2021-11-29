using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;


namespace FilmesAPI.Entidades
{
    public class Diretor :Pessoa 
    {
        public virtual IList<FilmeDiretor> FilmeDiretor { get; set; }
        
        public virtual IList<TemporadaDiretor> TemporadaDiretor { get; set; }
    }
}