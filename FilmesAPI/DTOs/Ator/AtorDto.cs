using System;

namespace FilmesAPI.DTOs.Ator
{
    public class AtorDTO
    {
                public int Id { get; set; }
                
                public virtual string NomeCompleto { get; set; }
                
                public virtual DateTime DataNascimento { get; set; }
                
    }
}