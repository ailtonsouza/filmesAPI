using System.ComponentModel.DataAnnotations;

namespace FilmesAPI.DTOs.Epsodio
{
    public class EpsodioDTO
    {
        public int Id { get; set; }
        public string Titulo { get; set; }
        public int Duracao { get; set; }
        public int TemporadaId { get; set; }
        public int NumeroEpsodio { get; set; }
    }
}