namespace FilmesAPI.Entidades
{
    public class SerieGenero
    {
        public virtual int Id { get; set; }
        public virtual Genero Genero { get; set; }
        public virtual Serie Serie { get; set; }
    }
}