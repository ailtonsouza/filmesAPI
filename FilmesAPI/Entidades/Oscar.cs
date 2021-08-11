using System.ComponentModel.DataAnnotations;

namespace FilmesAPI.Entidades
{
    public class Oscar
    {

        
            [Key]
            [Required]
            public virtual int Id { get; set; }
        
            [Required(ErrorMessage = "A data é obrigatória")]
            public virtual int Ano { get; set; }
        
            [Required(ErrorMessage = "A categoria é obrigatório")]
            [Range(1, 3, ErrorMessage = "As categorias devem estar em 1 e 3")]
            public virtual CategoriaOscar Categoria
            {
                get; 
                set;
            }

            public virtual Filme Filme { get; set; }

            public virtual void AdicionaFilme(Filme filme)
            {
                Filme = filme.ValidaOscar(this);
            }

            
    }
}