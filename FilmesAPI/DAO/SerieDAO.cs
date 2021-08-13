using FilmesAPI.Entidades;
using NHibernate;

namespace FilmesAPI.DAO
{
    public class SerieDAO
    {
        private ISession session;
        
        public SerieDAO(ISession session)
        {
            this.session = session;
        }
        
        public void Adiciona(Serie serie)
        {
            ITransaction transacao = session.BeginTransaction();
            session.Save(serie);
            transacao.Commit();
        }
        
        public Serie BuscaPorId(int id)
        {
            return session.Get<Serie>(id);
        }
    }
}