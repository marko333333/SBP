using FluentNHibernate.Cfg;
using FluentNHibernate.Cfg.Db;
using Gradjevinska_firmaLibrary.Mapiranja;
using NHibernate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Gradjevinska_firmaLibrary;

namespace Gradjevinska_firmaLibrary.Data
{
    internal static class DataLayer
    {
        private static ISessionFactory? _factory = null;
        private static readonly object objLock = new();

        //funkcija na zahtev otvara sesiju
        public static ISession? GetSession()
        {
            //ukoliko session factory nije kreiran
            if (_factory == null)
            {
                lock (objLock)
                {
                    _factory ??= CreateSessionFactory();
                }
            }

            return _factory?.OpenSession();
        }

        //konfiguracija i kreiranje session factory
        private static ISessionFactory? CreateSessionFactory()
        {
            try
            {
                var cfg = OracleManagedDataClientConfiguration.Oracle10
                            .ShowSql()
                            .ConnectionString(c =>
                                c.Is("Data Source=gislab-oracle.elfak.ni.ac.rs:1521/SBP_PDB;User Id=S19107;Password=Kaca2003"));

                return Fluently.Configure()
                    .Database(cfg)
                    .Mappings(m => m.FluentMappings.AddFromAssembly(Assembly.GetExecutingAssembly()))
                    .BuildSessionFactory();
            }
            catch (Exception e)
            {
                string error = e.HandleError();
                return null;
            }
        }
    }
}
