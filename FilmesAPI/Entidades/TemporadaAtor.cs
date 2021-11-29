namespace FilmesAPI.Entidades
{
    public class TemporadaAtor
    {
        public virtual int Id { get; set; }
        public virtual Ator Ator { get; set; }
        public virtual Temporada Temporada { get; set; }
        public virtual string NomePersonagem { get; set; }
    }
}