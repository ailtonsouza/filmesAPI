namespace FilmesAPI.Entidades
{
    public class TemporadaDiretor
    {
        public virtual int Id { get; set; }
        
        public virtual Diretor Diretor { get; set; }
        
        public virtual Temporada Temporada { get; set; }
    }
}