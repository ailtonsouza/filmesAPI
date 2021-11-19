namespace FilmesAPI.Entidades
{
    public class Filme_Ator
    {
        public virtual Ator Ator { get; set; }
        public virtual Filme Filme { get; set; }
        public virtual string NomePersonagem { get; set; }
    }
}