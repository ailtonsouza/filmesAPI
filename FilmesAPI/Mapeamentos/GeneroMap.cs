using FilmesAPI.Entidades;
using FluentNHibernate.Mapping;

namespace FilmesAPI.Mapeamentos
{
    public class GeneroMap : ClassMap<Genero>
    {
        public GeneroMap()
        {
            Table("Genero");
            
            Id(x => x.Id);
            Map(x => x.Nome);
            
            HasMany(x => x.FilmeGenero)
                .Cascade.AllDeleteOrphan()
                .Inverse()
                .KeyColumn("Genero_Id");
            
            HasMany(x => x.SerieGenero)
                .Cascade.AllDeleteOrphan()
                .Inverse()
                .KeyColumn("Genero_Id");

        }
    }
}