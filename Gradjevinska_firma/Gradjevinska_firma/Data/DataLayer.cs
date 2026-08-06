using FluentNHibernate.Cfg.Db;
using FluentNHibernate.Cfg;
using NHibernate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Gradjevinska_firma.Mapiranja;

namespace Gradjevinska_firma.Data
{
    class DataLayer
    {
        private static ISessionFactory _factory = null;
        private static object objLock = new object();

        public static ISession GetSession()
        {
            //ukoliko session factory nije kreiran
            if (_factory == null)
            {
                lock (objLock)
                {
                    if (_factory == null)
                        _factory = CreateSessionFactory();
                }
            }

            return _factory.OpenSession();
        }

        //konfiguracija i kreiranje session factory
        private static ISessionFactory CreateSessionFactory()
        {
            try
            {
                var cfg = OracleManagedDataClientConfiguration.Oracle10
                .ShowSql()
                .ConnectionString(c =>
                    c.Is("Data Source=gislab-oracle.elfak.ni.ac.rs:1521/SBP_PDB;User Id=19107;Password=Kaca2003"));

                return Fluently.Configure()
                    .Database(cfg)
                    .Mappings(m => m.FluentMappings.AddFromAssemblyOf<OsobaMap>())
                    .BuildSessionFactory();
            }
            catch (Exception ex)
            {
                string poruka = ex.ToString();

                if (ex.InnerException != null)
                {
                    poruka += "\n\nINNER EXCEPTION:\n";
                    poruka += ex.InnerException.ToString();
                }

                MessageBox.Show(poruka);

                throw;
            }

        }
    }
}
