using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using NHibernate.Mapping;

namespace FilmesAPI.Entidades
{
    public class Genero
    {
        
        [Key]
        [Required]
        public virtual int Id { get; set; }
        
        public virtual string Nome { get; set; }
        
        public virtual IList<FilmeGenero> FilmeGenero { get; set; }
        
        public virtual IList<SerieGenero> SerieGenero { get; set; }
    }
}