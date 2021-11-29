using System.Collections.Generic;

namespace FilmesAPI.Entidades
{
    public class Ator : Pessoa
    {
        //public virtual IList<Filme> Filmes { get; set; }
        
        public virtual IList<FilmeAtor> FilmeAtor { get; set; }
        
        public virtual IList<TemporadaAtor> TemporadaAtor { get; set; }
        
   
    }
}