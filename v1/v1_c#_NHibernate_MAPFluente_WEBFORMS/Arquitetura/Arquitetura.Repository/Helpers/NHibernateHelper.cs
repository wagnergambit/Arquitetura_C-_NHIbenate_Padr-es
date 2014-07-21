using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Reflection;
using NHibernate;
using FluentNHibernate.Cfg;
using FluentNHibernate.Cfg.Db;
using NHibernate.Tool.hbm2ddl;
using Arquitetura.Domain;

namespace Arquitetura.Repository.Helpers
{
    public class NHibernateHelper
    {
        private static ISessionFactory _sessionFactory;
        private static ISessionFactory SessionFactory
        {
            get
            {
                if (_sessionFactory == null)
                    InitializeSessionFactory();
                return _sessionFactory;
            }
        }

        private static void InitializeSessionFactory()
        {
            _sessionFactory = Fluently.Configure()
                                .Database(MsSqlConfiguration
                                .MsSql2008
                                .ConnectionString(
                                            x => x.FromConnectionStringWithKey("empresaConnectionString")).ShowSql())
                                .Mappings(m => m.FluentMappings.AddFromAssembly(Assembly.GetExecutingAssembly()))
                                .BuildSessionFactory();
        }

        public static ISession OpenSession()
        {
            //TESTE DE ITERAÇÃO 
            return SessionFactory.OpenSession();
        }
    }
}
