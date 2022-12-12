using FilmesAPI.Entidades;
using FluentNHibernate.Mapping;

namespace FilmesAPI.Mapeamentos
{
    public class AtorMap : ClassMap<Ator>
    {
        
        public AtorMap()
        {
            Table("Ator");
            
            Id(a => a.Id);
            Map(a => a.NomeCompleto);
            Map(a => a.DataNascimento);

            HasMany(x => x.FilmeAtor)
                .Cascade.AllDeleteOrphan()
                .Inverse()
                .KeyColumn("Ator_Id");
            
            HasMany(x => x.TemporadaAtor)
                .Cascade.AllDeleteOrphan()
                .Inverse()
                .KeyColumn("Ator_Id");
        }
    }
}