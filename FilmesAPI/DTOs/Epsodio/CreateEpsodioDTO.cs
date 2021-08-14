namespace FilmesAPI.DTOs.Epsodio
{
    public class CreateEpsodioDTO
    {
        public string Titulo { get; set; }
        public int Duracao { get; set; }
        public int TemporadaId { get; set; }
    }
}