namespace FilmesAPI.Entidades
{
    public class FilmeDiretor
    {
        public virtual int Id { get; set; }
        public virtual Diretor Diretor { get; set; }
        public virtual Filme Filme { get; set; }
    }
}