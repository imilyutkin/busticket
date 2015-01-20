using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Reflection;
using BusTicket.DomainModels.Models;
using BusTicket.DomainModels.Repositories.Attributes;
using BusTicket.DomainModels.Repositories.Configurations;
using BusTicket.DomainModels.Repositories.Contract;
using Dapper;

namespace BusTicket.DomainModels.Repositories.Impl
{
    public abstract class BaseRepository<TEntity> : IBaseRepository<TEntity> where TEntity : EntityBase
    {
        private String connectionString;

        protected String ConnectionString
        {
            get
            {
                return
                    connectionString =
                        connectionString ??
                        ConfigurationManager.ConnectionStrings[
                            ConfigurationManager.AppSettings["DBConnectionStringName"]]
                            .ConnectionString;
            }
        }

        private Type currentEntityType;

        protected Type CurrentEntityType
        {
            get
            {
                return currentEntityType = currentEntityType ?? typeof (TEntity);
            }
        }
        
        protected String CurrentTableName
        {
            get
            {
                return Configurations[CurrentEntityType].TableName;
            }
        }

        public SqlConnection Connection
        {
            get;
            set;
        }

        protected Dictionary<Type, EntityConfiguration> Configurations
        {
            get;
            set;
        }

        protected BaseRepository()
        {
            Connection = new SqlConnection(ConnectionString);
            Configurations = new Dictionary<Type, EntityConfiguration>();
            if (!Configurations.ContainsKey(typeof(TEntity)))
            {
                var type = typeof (TEntity);
                Configurations.Add(typeof(TEntity), new EntityConfiguration
                {
                    TableName = type.GetCustomAttribute<TableNameAttribute>().Name
                });
            }
        }

        public TEntity GetById(int id)
        {
            return Connection.Query<TEntity>(String.Format("SELECT * FROM {0} WHERE Id = @Id", CurrentTableName), new {Id = id}).SingleOrDefault();
        }

        public TEntity Save(TEntity entity)
        {
            throw new NotImplementedException();
        }

        public TEntity Update(TEntity entity)
        {
            throw new NotImplementedException();
        }

        public void DeletById(int id)
        {
            throw new NotImplementedException();
        }

        public void Delete(TEntity entity)
        {
            DeletById(entity.Id);
        }

        public IEnumerable<TEntity> GetAll()
        {
            return Connection.Query<TEntity>(String.Format("SELECT * FROM {0}", CurrentTableName));
        }
    }
}
