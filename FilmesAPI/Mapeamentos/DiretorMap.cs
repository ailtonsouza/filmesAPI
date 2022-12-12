using FilmesAPI.Entidades;
using FluentNHibernate.Mapping;

namespace FilmesAPI.Mapeamentos
{
    public class DiretorMap : ClassMap<Diretor>
    {
        public DiretorMap()
        {
            Table("Diretor");
            
            Id(a => a.Id);
            Map(a => a.NomeCompleto);
            Map(a => a.DataNascimento);

            HasMany(x => x.FilmeDiretor)
                .Cascade.AllDeleteOrphan()
                .Inverse()
                .KeyColumn("Diretor_Id");
            
            HasMany(x => x.TemporadaDiretor)
                .Cascade.AllDeleteOrphan()
                .Fetch.Join()
                .Inverse()
                .KeyColumn("Diretor_Id");
        }
    }
}