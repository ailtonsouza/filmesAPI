
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data;


namespace FilmesAPI.Entidades
{
    public class Filme : Midia
    {

       // [Required(ErrorMessage = "O campo diretor é obrigatório")]
        public virtual IList<Diretor> Diretor { get; set; }
        
        //[Required(ErrorMessage = "O campo Ator é obrigatório")]
        public virtual IList<Ator> Ator { get; set; }
        
       [Range(1, 600, ErrorMessage = "Duração deve ter no minimo 1 e no máximo 600 minutos")]
        public virtual int Duracao { get; set; }

       public virtual IList<Oscar> Oscar { get; set; }

       public virtual void AddDiretor(Diretor diretor)
       {
           this.Diretor.Add(diretor);
       }
       
       public virtual Filme ValidaOscar(Oscar oscar)
       {
           foreach (var scar in this.Oscar)
           {
              if (oscar.Ano == scar.Ano && oscar.Categoria == scar.Categoria)
               {
                   throw new DataException($"O filme {this.Titulo} já possui um oscar de mesma categoria para o ano de {scar.Ano}");
               } 
           }
       
           return this;
       }
    }
}