using System;
using System.Configuration;
using BusTicket.DomainModels.Migrations;

namespace BusTicket.Web
{
    public class DatabaseMigration
    {
        public static void Start()
        {
            var connectionString = GetConnectionString(GetCurrentConnectionStringName());

            var migrator = new Migrator(connectionString, "sqlserver");
            migrator.Migrate(runner => runner.MigrateDown(1));
            migrator.Migrate(runner => runner.MigrateUp(1));
        }

        protected static String GetConnectionString(String connectionStringName)
        {
            if (String.IsNullOrEmpty(connectionStringName))
            {
                throw new Exception("No DB connection string found");
            }
            return ConfigurationManager.ConnectionStrings[connectionStringName].ConnectionString;
        }

        protected  static String GetCurrentConnectionStringName()
        {
            return ConfigurationManager.AppSettings["DBConnectionStringName"];
        }
    }
}