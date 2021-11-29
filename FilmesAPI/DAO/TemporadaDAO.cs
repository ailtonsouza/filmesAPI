using System.Collections.Generic;
using FilmesAPI.Entidades;
using NHibernate;

namespace FilmesAPI.DAO
{
    public class TemporadaDAO
    {
        private ISession session;
        
        public TemporadaDAO(ISession session)
        {
            this.session = session;
        }
        
        public void Adiciona(Temporada temporada)
        {
            ITransaction transacao = session.BeginTransaction();
            session.Save(temporada);
            transacao.Commit();
        }
        
        public Temporada BuscaPorId(int id)
        {
            return session.Get<Temporada>(id);
        }
        
        public void Update(Temporada temporada)
        {
            ITransaction transacao = session.BeginTransaction();
            session.Save(temporada);
            transacao.Commit();
        }
        
        public void Remove(Temporada temporada)
        {
            ITransaction transacao = session.BeginTransaction();
            session.Delete(temporada);
            transacao.Commit();
        }
        
        public IEnumerable<Temporada> BuscaTodos()
        {
            return session.Query<Temporada>();
            session.Query<Ator>();
        }
    }
}