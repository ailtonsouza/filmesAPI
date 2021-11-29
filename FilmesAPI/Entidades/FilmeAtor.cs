namespace FilmesAPI.Entidades
{
    public class FilmeAtor
    {
        public virtual int Id { get; set; }
         public virtual Ator Ator { get; set; }
         public virtual Filme Filme { get; set; }
        public virtual string NomePersonagem { get; set; }
    }
}