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
    }
}