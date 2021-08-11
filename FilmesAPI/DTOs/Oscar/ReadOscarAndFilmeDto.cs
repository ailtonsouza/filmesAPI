using System.ComponentModel.DataAnnotations;
using FilmesAPI.Models.Dtos;

namespace FilmesAPI.Models.Dtos
{
    public class ReadOscarAndFilmeDto
    {
        [Key]
        [Required]
        public int id { get; set; }
        
        [Required(ErrorMessage = "Insira uma valor para o ano da premição entre {1} e {2}")]
        public virtual int Ano { get; set; }


        [Required(ErrorMessage = "A categoria é obrigatório")]
        public virtual string Categoria
        {
            get;
            set;
        }
        
        public virtual ReadFilmeDto Filme { get; set; }
   }
}