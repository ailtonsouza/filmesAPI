using FilmesAPI.Entidades;
using FluentNHibernate.Mapping;

namespace FilmesAPI.Mapeamentos
{
    public class SerieGeneroMap : ClassMap<SerieGenero>
    {
        public SerieGeneroMap()
        {
            Id(x => x.Id);

            References(x => x.Genero)
                .Not.Nullable()
                .Cascade.SaveUpdate()
                .Column("Genero_Id");
            
            References(x => x.Serie)
                .Not.Nullable()
                .Cascade.SaveUpdate()
                .Column("Serie_Id");
        }
    }
}