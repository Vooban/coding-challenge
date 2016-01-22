using FluentNHibernate.Cfg;
using FluentNHibernate.Cfg.Db;
using NHibernate.Tool.hbm2ddl;
using NHibernate;

namespace Coding_Challenge.Utility
{
    public class NHibernateUtility
    {
        private static ISessionFactory _sessionFactory;

        private static void CreateSessionFactory()
        {
            string connString = System.Web.Configuration.WebConfigurationManager.ConnectionStrings["VoobanCodingChallenge"].ConnectionString;

            _sessionFactory = Fluently.Configure()
                      .Database(MsSqlConfiguration.MsSql2008.ConnectionString(connString).ShowSql)
                      .Mappings(m => m.FluentMappings.AddFromAssemblyOf<Cities>())
                      .ExposeConfiguration(cfg => new SchemaExport(cfg).Create(false, false))
                      .BuildSessionFactory();
        }

        public static ISession OpenSession()
        {
            return SessionFactory.OpenSession();

        }
        private static ISessionFactory SessionFactory
        {
            get
            {
                if (_sessionFactory == null)
                    CreateSessionFactory();

                return _sessionFactory;
            }
        }
    }
}