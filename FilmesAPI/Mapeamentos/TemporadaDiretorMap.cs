using FilmesAPI.Entidades;
using FluentNHibernate.Mapping;

namespace FilmesAPI.Mapeamentos
{
    public class TemporadaDiretorMap : ClassMap<TemporadaDiretor>
    {
        public TemporadaDiretorMap()
        {
            Table("TemporadaDiretor");
            
            Id(x => x.Id);

            References(x => x.Diretor)
                .Not.Nullable()
                .Cascade.SaveUpdate()
                .Column("Diretor_Id");
            
            References(x => x.Temporada)
                .Not.Nullable()
                .Cascade.SaveUpdate()
                .Column("Temporada_Id");
        }
    }
}