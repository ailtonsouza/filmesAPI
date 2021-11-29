using System.Collections.Generic;
using System.Linq;
using FilmesAPI.Entidades;
using NHibernate;


namespace FilmesAPI.DAO
{
    public class FilmeAtorDAO
    {
        private ISession session;
        
        public FilmeAtorDAO(ISession session)
        {
            this.session = session;
        }
        
        public FilmeAtor BuscaPorId(int id)
        {
            return session.Get<FilmeAtor>(id);
        }
        
        public void Remove(FilmeAtor FilmeAtor)
        {
            ITransaction transacao = session.BeginTransaction();
            session.Delete(FilmeAtor);
            transacao.Commit();
        }
    }
}