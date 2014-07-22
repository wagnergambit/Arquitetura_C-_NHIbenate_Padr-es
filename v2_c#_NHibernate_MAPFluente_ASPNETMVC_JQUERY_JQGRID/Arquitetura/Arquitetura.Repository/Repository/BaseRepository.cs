using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NHibernate;
using NHibernate.Linq;
using Arquitetura.Domain.Interface;
using Arquitetura.Repository.Helpers;

namespace Arquitetura.Repository.Repository
{

    public class BaseRepository<T> : IRepository<T> where T : IEntity
    {
        public T BuscaPorID(long id)
        {
            using (ISession session = NHibernateHelper.OpenSession())
                return session.Get<T>(id);
        }

        public IList<T> ListaTodos()
        {
            using (ISession session = NHibernateHelper.OpenSession())
                return (from t in session.Query<T>()
                        select t).ToList();
        }

        public T Salva(T entity)
        {
            using (ISession session = NHibernateHelper.OpenSession())
            {
                using (ITransaction transaction = session.BeginTransaction())
                {
                    session.SaveOrUpdate(entity);
                    transaction.Commit();
                }
            }
            return entity;
        }

        public void Exclui(T entity)
        {
            using (ISession session = NHibernateHelper.OpenSession())
            {
                using (ITransaction transaction = session.BeginTransaction())
                {
                    session.Delete(entity);
                    transaction.Commit();
                }
            }
        }
    }
}
