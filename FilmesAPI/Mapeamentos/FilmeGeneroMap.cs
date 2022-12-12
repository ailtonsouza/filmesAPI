using FilmesAPI.Entidades;
using FluentNHibernate.Mapping;

namespace FilmesAPI.Mapeamentos
{
    public class FilmeGeneroMap : ClassMap<FilmeGenero>
    {
        public FilmeGeneroMap()
        {
            Table("FilmeGenero");

            Id(x => x.Id);

            References(x => x.Filme)
                .Not.Nullable()
                .Cascade.SaveUpdate()
                .Column("Filme_Id");
            
            References(x => x.Genero)
                .Not.Nullable()
                .Cascade.SaveUpdate()
                .Column("Genero_Id");
            
            
        }
    }
}