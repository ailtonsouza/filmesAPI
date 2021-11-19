namespace FilmesAPI.DTOs.Epsodio
{
    public class CreateEpsodioDTO
    {
        public int Id { get; set; }
        public string Titulo { get; set; }
        public int Duracao { get; set; }
        public int TemporadaId { get; set; }
    }
}