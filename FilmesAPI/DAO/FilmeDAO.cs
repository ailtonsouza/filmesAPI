using System.Collections.Generic;
using System.Linq;
using FilmesAPI.Entidades;
using NHibernate;

namespace FilmesAPI.DAO
{
    public class FilmeDAO
    {
        private ISession session;
        
        public FilmeDAO(ISession session)
        {
            this.session = session;
        }
        
        public void Adiciona(Filme filme)
        {
            ITransaction transacao = session.BeginTransaction();
            session.Save(filme);
            transacao.Commit();
        }
        
        public void Remove(Filme filme)
        {
            ITransaction transacao = session.BeginTransaction();
            session.Delete(filme);
            transacao.Commit();
        }
        
        public void Update(Filme filme)
        {
            ITransaction transacao = session.BeginTransaction();
            session.Save(filme);
            transacao.Commit();
        }
        
        public Filme BuscaPorId(int id)
        {
            return session.Get<Filme>(id);
        }
        
        public IEnumerable<Filme> BuscaTodos()
        {
            return session.Query<Filme>();
        }
        
 
    }
}