using System.Collections.Generic;
using FilmesAPI.Entidades;
using NHibernate;


namespace FilmesAPI.DAO
{
    public class EpsodioDAO
    {
        private ISession session;
        
        public EpsodioDAO(ISession session)
        {
            this.session = session;
        }
        
        public void Adiciona(Epsodio epsodio)
        {
            ITransaction transacao = session.BeginTransaction();
            session.Save(epsodio);
            transacao.Commit();
        }
        
        public Epsodio BuscaPorId(int id)
        {
            return session.Get<Epsodio>(id);
        }

        public IEnumerable<Epsodio> BuscaTodos()
        {
            return session.Query<Epsodio>();
        }
        
        public void Remove(Epsodio epsodio)
        {
            ITransaction transacao = session.BeginTransaction();
            session.Delete(epsodio);
            transacao.Commit();
        }
        
        public void Update(Epsodio epsodio)
        {
            ITransaction transacao = session.BeginTransaction();
            session.Save(epsodio);
            transacao.Commit();
        }
    }
}