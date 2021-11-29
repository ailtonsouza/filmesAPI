using FilmesAPI.DTOs.Temporada;

namespace FilmesAPI.DTOs.Epsodio
{
    public class EpsodioTemporadaDTO
    {
        public int Id { get; set; }
        public string Titulo { get; set; }
        public int Duracao { get; set; }
        public int NumeroEpsodio { get; set; }
        public TemporadaSerieDTO Temporada { get; set; }
    }
}