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
    }
}