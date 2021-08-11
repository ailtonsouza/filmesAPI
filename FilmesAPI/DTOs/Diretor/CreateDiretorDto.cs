using System;

namespace FilmesAPI.Dtos.Diretor
{
    public class CreateDiretorDto
    {
        public string nomeCompleto { get; set; }
        
        public virtual string dataNascimento { get; set; }
    }
}