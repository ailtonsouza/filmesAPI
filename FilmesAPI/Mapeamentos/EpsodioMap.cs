using FilmesAPI.Entidades;
using FluentNHibernate.Mapping;

namespace FilmesAPI.Mapeamentos
{
    public class EpsodioMap : ClassMap<Epsodio>
    {
        public EpsodioMap()
        {
            Table("Epsodio");
            
            Id(x => x.Id);
            Map(x => x.Titulo);
            Map(x => x.Duracao);
            Map(x => x.NumeroEpsodio);

            References(x => x.Temporada).Column("Temporada_id");
        }
    }
}