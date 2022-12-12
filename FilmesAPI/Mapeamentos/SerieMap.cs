using FilmesAPI.Entidades;
using FluentNHibernate.Mapping;

namespace FilmesAPI.Mapeamentos
{
    public class SerieMap : ClassMap<Serie>
    {
        public SerieMap()
        {
            Table("Serie");
            
            Id(x => x.Id);
            Map(x => x.Titulo);

            HasMany(x => x.Temporadas)
                .Cascade.AllDeleteOrphan()
                .Inverse()
                .KeyColumn("Serie_Id");
            
            HasMany(x => x.SerieGenero)
                .Cascade.AllDeleteOrphan()
                .Inverse()
                .KeyColumn("Serie_Id");

        }
    }
}