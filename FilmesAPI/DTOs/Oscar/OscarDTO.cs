using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using FilmesAPI.Entidades;

namespace FilmesAPI.Models.Dtos
{
    public class OscarDTO
    {
        [Range(minimum:1, maximum:int.MaxValue, 
            ErrorMessage = "Insira um id valido de um filme")]
        public int FilmeId { get; set; }
       
        [Range(minimum:1000, maximum:3000, 
        ErrorMessage = "Insira o ano do Oscar")]
        public virtual int Ano { get; set; }
        
        [Range(minimum:1, maximum:3, 
        ErrorMessage = "Insira o numero da categoria do Oscar")]
        public virtual string Categoria { get; set; }
        


    }
}