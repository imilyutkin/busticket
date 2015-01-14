using System.Diagnostics;
using FluentMigrator.Runner;
using FluentMigrator.Runner.Announcers;
using FluentMigrator.Runner.Processors;
using FluentMigrator.Runner.Processors.SqlServer;

namespace BusTicket.DomainModels.Migrations
{
    public class Server2012Migrator : Migrator
    {
        public Server2012Migrator(string connectionString, string dbType) : base(connectionString, dbType)
        {
        }

        protected override IMigrationProcessorFactory GetProcessorFactory()
        {
            return new SqlServer2012ProcessorFactory();
        }

        protected override IAnnouncer GetAnnouncer()
        {
            return new TextWriterAnnouncer(s => Debug.WriteLine(s));
        }
    }
}
