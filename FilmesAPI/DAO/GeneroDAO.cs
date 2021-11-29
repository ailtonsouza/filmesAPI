using System.Collections.Generic;
using FilmesAPI.Entidades;
using NHibernate;

namespace FilmesAPI.DAO
{
    public class GeneroDAO
    {
        private ISession session;

        public GeneroDAO(ISession session)
        {
            this.session = session;
        }

        public void Adiciona(Genero genero)
        {
            ITransaction transacao = session.BeginTransaction();
            session.Save(genero);
            transacao.Commit();
        }
        
        public IEnumerable<Genero> BuscaTodos()
        {
            return session.Query<Genero>();
        }
        
        public Genero BuscaPorId(int id)
        {
            return session.Get<Genero>(id);
        }
        
        public void Remove(Genero genero)
        {
            ITransaction transacao = session.BeginTransaction();
            session.Delete(genero);
            transacao.Commit();
        }
        
        public void Update(Genero genero)
        {
            ITransaction transacao = session.BeginTransaction();
            session.Save(genero);
            transacao.Commit();
        }
    }
}