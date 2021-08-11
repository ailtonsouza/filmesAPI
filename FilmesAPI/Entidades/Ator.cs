using System.Collections.Generic;

namespace FilmesAPI.Entidades
{
    public class Ator : Pessoa
    {
        public virtual IList<Filme> Filmes { get; set; }
    }
}