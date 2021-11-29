using System.Collections.Generic;
using System.Linq;
using FilmesAPI.Entidades;
using NHibernate;


namespace FilmesAPI.DAO
{
    public class SerieGeneroDAO
    {
        private ISession session;
        
        public SerieGeneroDAO(ISession session)
        {
            this.session = session;
        }
        
        public SerieGenero BuscaPorId(int id)
        {
            return session.Get<SerieGenero>(id);
        }
        
        public void Remove(SerieGenero SerieGenero)
        {
            ITransaction transacao = session.BeginTransaction();
            session.Delete(SerieGenero);
            transacao.Commit();
        }
    }
}