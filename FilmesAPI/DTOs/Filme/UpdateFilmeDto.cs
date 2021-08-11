using System.ComponentModel.DataAnnotations;

namespace FilmesAPI.Models.Dtos
{
    public class UpdateFilmeDto
    {
        [Required(ErrorMessage = "O campo título é obrigatório")]
        public string Titulo { get; set; }
        
        [Required(ErrorMessage = "O campo diretor é obrigatório")]
        public string Diretor { get; set; }
        
        [StringLength(30, ErrorMessage = "O genenro não pode ser maior que 30 caracteres")]
        public string Genero { get; set; }
        
        [Range(1, 600, ErrorMessage = "Duração deve ter no minimo 1 e no máximo 600 minutos")]
        public int Duracao { get; set; }
    }
}