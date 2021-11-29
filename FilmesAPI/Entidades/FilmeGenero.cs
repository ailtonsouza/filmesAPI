namespace FilmesAPI.Entidades
{
    public class FilmeGenero
    {
        public virtual int Id { get; set; }
        public virtual Genero Genero { get; set; }
        public virtual Filme Filme { get; set; }
    }
}