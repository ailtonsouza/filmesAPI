using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using FilmesAPI.DTOs.Ator;
using FilmesAPI.Dtos.Diretor;
using FilmesAPI.Dtos.Genero;


namespace FilmesAPI.Models.Dtos
{
    public class FilmeDTO
    {
        [Key]
        [Required]
        public int id { get; set; }
        
        public string Titulo { get; set; }
        
        public int Duracao { get; set; }

    }
}