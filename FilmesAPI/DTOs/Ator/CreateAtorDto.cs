namespace FilmesAPI.Dtos.Ator
{
    public class CreateAtorDto
    {
        public string nomeCompleto { get; set; }
        
        public virtual string dataNascimento { get; set; }
    }
}