using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using FilmesAPI.Dtos.Ator;
using FilmesAPI.Dtos.Diretor;
using FilmesAPI.Dtos.Genero;

namespace FilmesAPI.Models.Dtos
{
    public class ReadFilmeSemOscarDTO
    {
        [Key]
        [Required]
        public int id { get; set; }
        
        [Required(ErrorMessage = "O campo título é obrigatório")]
        public string Titulo { get; set; }
        
        [Range(1, 600, ErrorMessage = "Duração deve ter no minimo 1 e no máximo 600 minutos")]
        public int Duracao { get; set; }

        public virtual IList<ReadDiretorDto> Diretor{ get; set; }
        
        public virtual IList<ReadAtorDto> Ator{ get; set; }
        
        public virtual IList<ReadGeneroDto> Genero{ get; set; }
        
    }
}