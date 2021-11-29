using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using FilmesAPI.DTOs.Ator;
using FilmesAPI.Dtos.Diretor;

namespace FilmesAPI.Models.Dtos
{
    public class FilmeAgreçõesDTO
    {
        [Key]
        [Required]
        public int id { get; set; }
        
        [Required(ErrorMessage = "O campo título é obrigatório")]
        public string Titulo { get; set; }
        
        [Range(1, 600, ErrorMessage = "Duração deve ter no minimo 1 e no máximo 600 minutos")]
        public int Duracao { get; set; }
        
        public virtual IList<AtorFilmeDTO> Atores { get; set; }
        public virtual IList<DiretorFilme> Diretores { get; set; }
        //
        public virtual IList<FilmeGeneroDTO> FilmeGenero { get; set; }
        //
        public virtual IList<OscarDTO> Oscar { get; set; }
    }
}