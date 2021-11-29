namespace FilmesAPI.DTOs.Temporada
{
    public class TemporadaAgregações
    {
        public virtual int Id { get; set; }
        
        public virtual int NumeroDaTemporada { get; set; }
        
        public virtual SerieDTO Serie { get; set; }
        
        public virtual IList<AtorTemporadaDTO> TemporadaAtor { get; set; }
        
        public virtual IList<DiretorTemporadaDTO> TemporadaDiretor { get; set; }
    }
}