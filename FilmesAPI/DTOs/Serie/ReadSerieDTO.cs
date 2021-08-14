using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using FilmesAPI.Dtos.Ator;
using FilmesAPI.Dtos.Genero;
using FilmesAPI.Entidades;

namespace FilmesAPI.DTOs.Serie
{
    public class ReadSerieDTO
    {
        [Key]
        [Required]
        public virtual int Id { get; set; }
        
        [Required(ErrorMessage = "O campo título é obrigatório")]
        public virtual string Titulo { get; set; }
        
        public virtual IList<ReadGeneroDto> Genero { get; set; }
        
    }
}