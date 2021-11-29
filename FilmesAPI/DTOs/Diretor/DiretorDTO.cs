using System;

namespace FilmesAPI.Dtos.Diretor
{
    public class DiretorDTO
    {
        public int Id { get; set; }
        
        public string NomeCompleto { get; set; }
        
        public virtual DateTime DataNascimento { get; set; }
    }
}