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
    }
}