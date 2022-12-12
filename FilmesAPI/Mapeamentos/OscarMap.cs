using FilmesAPI.Entidades;
using FluentNHibernate.Mapping;

namespace FilmesAPI.Mapeamentos
{
    public class OscarMap : ClassMap<Oscar>
    {
        public OscarMap()
        {
            Table("Oscar");
            
            Id(x => x.Id);
            Map(x => x.Categoria);
            Map(x => x.Ano);

            References(x => x.Filme).Column("Filme_Id");

        }
    }
}