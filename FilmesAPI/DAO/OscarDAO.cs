

using System.Collections.Generic;
using FilmesAPI.Entidades;
using NHibernate;

namespace FilmesAPI.DAO
{
    public class OscarDAO
    {
        private ISession session;
        
        public OscarDAO(ISession session)
        {
            this.session = session;
        }
        
        public void Adiciona(Oscar oscar)
        {
            ITransaction transacao = session.BeginTransaction();
            session.Save(oscar);
            transacao.Commit();
            
        }
        
        public IEnumerable<Oscar> BuscaTodos()
        {
            return session.QueryOver<Oscar>().List();
        }
        
        public Oscar BuscaPorId(int id)
        {
            return session.Get<Oscar>(id);
        }
        
        public void Remove(Oscar oscar)
        {
            ITransaction transacao = session.BeginTransaction();
            session.Delete(oscar);
            transacao.Commit();
        }
    }
}