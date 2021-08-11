using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;


namespace FilmesAPI.Entidades
{
    public class Diretor :Pessoa 
    {
        public virtual IList<Filme> Filmes { get; set; }
    }
}