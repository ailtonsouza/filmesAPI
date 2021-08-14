using FilmesAPI.DTOs.Temporada;

namespace FilmesAPI.DTOs.Epsodio
{
    public class ReadEpsodioDTO
    {
        public string Titulo { get; set; }
        public int Duracao { get; set; }
        public ReadTemporadaDTO Temporada { get; set; }
    }
}