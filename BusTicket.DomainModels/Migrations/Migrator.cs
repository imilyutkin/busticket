using System;
using System.Diagnostics;
using System.Reflection;
using FluentMigrator.Runner;
using FluentMigrator.Runner.Announcers;
using FluentMigrator.Runner.Initialization;
using FluentMigrator.Runner.Processors.SqlServer;

namespace BusTicket.DomainModels.Migrations
{
    public class Migrator
    {
        protected readonly String ConnectionString;

        protected readonly String DBType;

        public Migrator(String connectionString, String dbType)
        {
            ConnectionString = connectionString;
            DBType = dbType;
        }

        public void Migrate(Action<IMigrationRunner> runnerAction)
        {
            var options = new MigrationOptions {Timeout = 0, PreviewOnly = false};
            var factory = new SqlServer2012ProcessorFactory();
            var announcer = new TextWriterAnnouncer(s => Debug.WriteLine(s));
            var migrationContext = new RunnerContext(announcer);
            var processor = factory.Create(ConnectionString, announcer, options);
            var runner = new MigrationRunner(Assembly.GetExecutingAssembly(), migrationContext, processor);
            runnerAction(runner);
        }
    }
}
