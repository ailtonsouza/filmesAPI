using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using FilmesAPI.Entidades;

namespace FilmesAPI.Models.Dtos
{
    public class CreateOscarDto
    {
        // [Range(1929, 2019, 
        // ErrorMessage = "Insira uma valor para o ano da premição entre {1} e {2}")]
        // public virtual int Ano { get; set; }
        //
        // [Required(ErrorMessage = "A categoria é obrigatório")]
        // public virtual String Categoria { get; set; }
        //
        // [Range(minimum:1, maximum:int.MaxValue, 
        // ErrorMessage = "Insira um id valido de um filme")]
        // public virtual int FilmeId { get; set; }
        //
        // public virtual Filme filme { get; set; }
        
        
        [Range(minimum:1000, maximum:3000, 
            ErrorMessage = "Insira o ano do Oscar")]
        public virtual int Ano { get; set; }
        
        [Range(minimum:1, maximum:3, 
            ErrorMessage = "Insira o numero da categoria do Oscar")]
        public virtual string Categoria { get; set; }
        
        [Range(minimum:1, maximum:int.MaxValue, 
        ErrorMessage = "Insira um id valido de um filme")]
        public virtual int FilmeId { get; set; }

        public virtual string FilmeTitulo { get; set; }
    }
}