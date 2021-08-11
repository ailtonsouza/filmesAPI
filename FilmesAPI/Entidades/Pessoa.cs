using System;
using System.ComponentModel.DataAnnotations;

namespace FilmesAPI.Entidades
{
    public abstract class Pessoa
    {
        [Key]
        [Required]
        public virtual int Id { get; set; }
        
        public virtual string NomeCompleto { get; set; }
        
        public virtual DateTime DataNascimento { get; set; }
    }
}