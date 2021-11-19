using System.Collections.Generic;
using System.Linq;
using FilmesAPI.Entidades;
using NHibernate;


namespace FilmesAPI.DAO
{
    public class AtorDAO
    {
        private ISession session;
        
        public AtorDAO(ISession session)
        {
            this.session = session;
        }
        
        public void Adiciona(Ator ator)
        {
            ITransaction transacao = session.BeginTransaction();
            session.Save(ator);
            transacao.Commit();
        }
        
        public Ator BuscaPorId(int id)
        {
            return session.Get<Ator>(id);
        }
        
        public IEnumerable<Ator>  BuscaTodos()
        {
            return session.Query<Ator>();
        }
        
        public IList<Ator> BuscaPorIds(IList<int> ids)
        {
            return session.Query<Ator>().Where(p => ids.Contains(p.Id)).ToList();
        }
        
        public void Remove(Ator ator)
        {
            ITransaction transacao = session.BeginTransaction();
            session.Delete(ator);
            transacao.Commit();
        }

        
    }
}