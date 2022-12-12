using FilmesAPI.Entidades;
using FluentNHibernate.Mapping;

namespace FilmesAPI.Mapeamentos
{
    public class FilmeMap : ClassMap<Filme>
    {
        public FilmeMap()
        {
            Table("Filme");
            
            Id(x => x.Id);
            Map(x => x.Titulo);
            Map(x => x.Duracao);

            HasMany(x => x.FilmeAtor)
                .Cascade.AllDeleteOrphan()
                .Inverse()
                .Fetch.Join()
                .KeyColumn("Filme_Id");
            
            HasMany(x => x.FilmeDiretor)
                .Cascade.AllDeleteOrphan()
                .Inverse()
                .KeyColumn("Filme_Id");
            
            HasMany(x => x.FilmeGenero)
                .Cascade.AllDeleteOrphan()
                .Inverse()
                .KeyColumn("Filme_Id");
            
            HasMany(x => x.Oscar)
                .Cascade.AllDeleteOrphan()
                .Inverse()
                .KeyColumn("Filme_Id");
        }
    }
}