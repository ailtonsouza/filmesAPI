using FilmesAPI.DTOs.Serie;

namespace FilmesAPI.DTOs.Temporada
{
    public class TemporadaSerieDTO
    {
        public virtual int Id { get; set; }
        
        public virtual int NumeroDaTemporada { get; set; }
        
        public virtual SerieDTO Serie { get; set; }
    }
}