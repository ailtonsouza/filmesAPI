using System.Collections.Generic;
using System.Linq;
using FilmesAPI.Entidades;
using NHibernate;


namespace FilmesAPI.DAO
{
    public class FilmeDiretorDAO
    {
        private ISession session;
        
        public FilmeDiretorDAO(ISession session)
        {
            this.session = session;
        }
        
        public FilmeDiretor BuscaPorId(int id)
        {
            return session.Get<FilmeDiretor>(id);
        }
        
        public void Remove(FilmeDiretor FilmeDiretor)
        {
            ITransaction transacao = session.BeginTransaction();
            session.Delete(FilmeDiretor);
            transacao.Commit();
        }
    }
}