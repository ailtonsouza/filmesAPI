using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using FilmesAPI.Dtos.Genero;
using FilmesAPI.DTOs.Temporada;

namespace FilmesAPI.DTOs.Serie
{
    public class SerieAgregaçõesDTO
    {
        public virtual int Id { get; set; }
        
        [Required(ErrorMessage = "O campo título é obrigatório")]
        public virtual string Titulo { get; set; }
        
        public virtual IList<SerieGeneroDTO> serieGenero { get; set; }
        
        public virtual IList<TemporadaAtorDiretorDTO> Temporadas { get; set; }
    }
}