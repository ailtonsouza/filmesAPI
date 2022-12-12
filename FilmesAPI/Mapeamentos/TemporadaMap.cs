using FilmesAPI.Entidades;
using FluentNHibernate.Mapping;

namespace FilmesAPI.Mapeamentos
{
    public class TemporadaMap : ClassMap<Temporada>
    {
        public TemporadaMap()
        {
            Table("Temporada");
            
            Id(x => x.Id);
            Map(x => x.NumeroDaTemporada);

            HasMany(x => x.Epsodio)
                .Cascade.AllDeleteOrphan()
                .Inverse()
                .KeyColumn("Temporada_Id");
            
            HasMany(x => x.TemporadaAtor)
                .Cascade.AllDeleteOrphan()
                .Inverse()
                .KeyColumn("Temporada_Id");
            
            HasMany(x => x.TemporadaDiretor)
                .Cascade.AllDeleteOrphan()
                .Inverse()
                .KeyColumn("Temporada_Id");
            
            References(x => x.Serie)
                .Not.Nullable()
                .Cascade.SaveUpdate()
                .Column("Serie_Id");
        }
    }
}