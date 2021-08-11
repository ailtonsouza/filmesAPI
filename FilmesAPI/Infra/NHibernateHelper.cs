using System;
using System.Reflection;
using Microsoft.Extensions.DependencyInjection;
using NHibernate;
using NHibernate.Cfg;
using NHibernate.Tool.hbm2ddl;

namespace FilmesAPI.Infra
{
    public static class NHibernateHelper
    {
        public static IServiceCollection AddNHibernate(this IServiceCollection services)
        {
            Console.WriteLine("Extensions");
            var configuration = new Configuration();
            configuration.Configure();
            configuration.AddAssembly(Assembly.GetExecutingAssembly());
            new SchemaUpdate(configuration).Execute(false, true);
            var sessionFactory = configuration.BuildSessionFactory();
            services.AddSingleton(sessionFactory);
            services.AddScoped(factory => sessionFactory.OpenSession());
            return services;
        }
    }
}