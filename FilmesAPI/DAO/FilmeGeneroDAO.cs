using System.Collections.Generic;
using System.Linq;
using FilmesAPI.Entidades;
using NHibernate;


namespace FilmesAPI.DAO
{
    public class FilmeGeneroDAO
    {
        private ISession session;
        
        public FilmeGeneroDAO(ISession session)
        {
            this.session = session;
        }
        
        public FilmeGenero BuscaPorId(int id)
        {
            return session.Get<FilmeGenero>(id);
        }
        
        public void Remove(FilmeGenero FilmeGenero)
        {
            ITransaction transacao = session.BeginTransaction();
            session.Delete(FilmeGenero);
            transacao.Commit();
        }
    }
}