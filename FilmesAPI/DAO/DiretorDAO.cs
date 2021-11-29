using System.Collections;
using System.Collections.Generic;
using System.Linq;
using FilmesAPI.Entidades;
using NHibernate;


namespace FilmesAPI.DAO
{
    public class DiretorDAO
    {
        private ISession session;
        
        public DiretorDAO(ISession session)
        {
            this.session = session;
        }
        
        public void Adiciona(Diretor diretor)
        {
            ITransaction transacao = session.BeginTransaction();
            session.Save(diretor);
            transacao.Commit();
        }
        
        public Diretor BuscaPorId(int id)
        {
            return session.Get<Diretor>(id);
        }
        
        public IList<Diretor> BuscaPorIds(IList<int> ids)
        {
            return session.Query<Diretor>().Where(p => ids.Contains(p.Id)).ToList();
        }
        
        public IEnumerable<Diretor>  BuscaTodos()
        {
            return session.Query<Diretor>();
        }
        
        public void Remove(Diretor diretor)
        {
            ITransaction transacao = session.BeginTransaction();
            session.Delete(diretor);
            transacao.Commit();
        }
        
        public void Update(Diretor diretor)
        {
            ITransaction transacao = session.BeginTransaction();
            session.Save(diretor);
            transacao.Commit();
        }
    }
}