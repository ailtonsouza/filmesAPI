using FilmesAPI.Entidades;
using FluentNHibernate.Mapping;

namespace FilmesAPI.Mapeamentos
{
    public class FilmeDiretorMap : ClassMap<FilmeDiretor>
    {
        public FilmeDiretorMap()
        {
            Table("FilmeDiretor");

            Id(x => x.Id);

            References(x => x.Filme)
                .Not.Nullable()
                .Cascade.SaveUpdate()
                .Column("Filme_Id");
            
            References(x => x.Diretor)
                .Not.Nullable()
                .Cascade.SaveUpdate()
                .Column("Diretor_Id");
        }
    }
}