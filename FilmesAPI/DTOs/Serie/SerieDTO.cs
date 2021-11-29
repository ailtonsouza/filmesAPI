using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

using FilmesAPI.Dtos.Genero;
using FilmesAPI.Entidades;

namespace FilmesAPI.DTOs.Serie
{
    public class SerieDTO
    {
        [Key]
        [Required]
        public virtual int Id { get; set; }
        
        public virtual string Titulo { get; set; }
        

        
    }
}