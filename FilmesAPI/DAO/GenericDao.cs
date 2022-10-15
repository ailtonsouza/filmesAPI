using System.Collections.Generic;
using NHibernate;

namespace FilmesAPI.DAO
{
    public class GenericDao<T>
    {
        private ISession session;
        
        public GenericDao(ISession session)
        {
            this.session = session;
        }
        
        public void Adiciona(T item)
        {
            ITransaction transacao = session.BeginTransaction();
            session.Save(item);
            transacao.Commit();
        }
        
        public T BuscaPorId(int id)
        {
            return session.Get<T>(id);
        }
        
        
        public IEnumerable<T>  BuscaTodos()
        {
            return session.Query<T>();
        }
        
        public void Remove(T item)
        {
            ITransaction transacao = session.BeginTransaction();
            session.Delete(item);
            transacao.Commit();
        }
        
        public void Update(T item)
        {
            ITransaction transacao = session.BeginTransaction();
            session.Save(item);
            transacao.Commit();
        }
    }
}