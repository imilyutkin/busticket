using System;
using System.Reflection;
using FluentMigrator.Runner;
using FluentMigrator.Runner.Initialization;
using FluentMigrator.Runner.Processors;

namespace BusTicket.DomainModels.Migrations
{
    public abstract class Migrator
    {
        protected readonly String ConnectionString;

        protected readonly String DBType;

        protected Migrator(String connectionString, String dbType)
        {
            ConnectionString = connectionString;
            DBType = dbType;
        }

        protected abstract IMigrationProcessorFactory GetProcessorFactory();

        protected abstract IAnnouncer GetAnnouncer();

        public void Migrate(Action<IMigrationRunner> runnerAction)
        {
            var options = new MigrationOptions {Timeout = 0, PreviewOnly = false};
            var factory = GetProcessorFactory();
            var announcer = GetAnnouncer();
            var migrationContext = new RunnerContext(announcer);
            var processor = factory.Create(ConnectionString, announcer, options);
            var runner = new MigrationRunner(Assembly.GetExecutingAssembly(), migrationContext, processor);
            runnerAction(runner);
        }
    }
}
