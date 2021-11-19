using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using FilmesAPI.Dtos.Ator;
using FilmesAPI.Dtos.Diretor;
using FilmesAPI.Dtos.Genero;

namespace FilmesAPI.Models.Dtos
{
    public class ReadFilmeWithActorDto
    {
        [Required(ErrorMessage = "O campo título é obrigatório")]
        public virtual string Titulo { get; set; }
        
        [Range(1, 600, ErrorMessage = "Duração deve ter no minimo 1 e no máximo 600 minutos")]
        public virtual int Duracao { get; set; }
        
        public virtual IList<CreateAtorDto> Ator { get; set; }
        
        public virtual IList<CreateDiretorDto> Diretor { get; set; }
        
        public virtual IList<ReadOscarDto> Oscar { get; set; }
    }
}