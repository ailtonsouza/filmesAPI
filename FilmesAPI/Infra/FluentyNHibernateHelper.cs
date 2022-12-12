using System;
using System.IO;
using System.Reflection;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using NHibernate;
using NHibernate.Tool.hbm2ddl;
using FluentNHibernate.Cfg;
using FluentNHibernate.Cfg.Db;
using NHibernate.Cfg;

namespace FilmesAPI.Infra
{
    public static class NHibernateHelper
    {
        public static ISessionFactory AddNHibernate()
        {
            IConfigurationRoot configuration = new ConfigurationBuilder()
                .SetBasePath(AppDomain.CurrentDomain.BaseDirectory)
                .AddJsonFile("appsettings.json")
                .Build();

            var _sessonFactory = Fluently.Configure()
                .Database(MsSqlConfiguration.MsSql2012.ConnectionString(configuration.GetConnectionString("ConexaoBD")))
                .Mappings(x => x.FluentMappings.AddFromAssembly(Assembly.GetExecutingAssembly()))
                .ExposeConfiguration(cfg =>
                {
                    new SchemaExport(cfg).Execute(true, false, false);
                })
                .BuildSessionFactory();
            
                return _sessonFactory;
        }
    }
}