using FilmesAPI.Entidades;
using FluentNHibernate.Mapping;

namespace FilmesAPI.Mapeamentos
{
    public class FilmeAtorMap : ClassMap<FilmeAtor>
    {
        public FilmeAtorMap()
        {
            Table("FilmeAtor");
            
            Id(x => x.Id);
            Map(x => x.NomePersonagem);

            References(x => x.Ator)
                .Not.Nullable()
                .Cascade.SaveUpdate()
                .Column("Ator_Id");
            
            References(x => x.Filme)
                .Not.Nullable()
                .Cascade.SaveUpdate()
                .Column("Filme_Id");

        }
    }
}