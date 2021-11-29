using System.ComponentModel.DataAnnotations;

namespace FilmesAPI.Models.Dtos
{
    public class UpdateFilmeDto
    {
        [Required(ErrorMessage = "O campo título é obrigatório")]
        public string Titulo { get; set; }
        
        [Range(1, 600, ErrorMessage = "Duração deve ter no minimo 1 e no máximo 600 minutos")]
        public int Duracao { get; set; }
    }
}