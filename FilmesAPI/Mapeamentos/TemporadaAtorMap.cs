using FilmesAPI.Entidades;
using FluentNHibernate.Mapping;

namespace FilmesAPI.Mapeamentos
{
    public class TemporadaAtorMap : ClassMap<TemporadaAtor>
    {
        public TemporadaAtorMap()
        {
            Table("TemporadaAtor");
            Id(x => x.Id);
            Map( x => x.NomePersonagem);

            References(x => x.Ator)
                .Not.Nullable()
                .Cascade.SaveUpdate()
                .Column("Ator_Id");
            
            References(x => x.Temporada)
                .Not.Nullable()
                .Cascade.SaveUpdate()
                .Column("Temporada_Id");

        }
    }
}