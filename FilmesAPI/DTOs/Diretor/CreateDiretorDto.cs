using System;

namespace FilmesAPI.Dtos.Diretor
{
    public class CreateDiretorDto
    {
        public string NomeCompleto { get; set; }
        
        public virtual string DataNascimento { get; set; }
    }
}