using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
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
            Connection = new SqlConnection(connectionString);
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
//            return Connection.Query<TEntity>("SELECT * FROM {0} WHERE Id = @Id", new {Id = id});
            throw new System.NotImplementedException();
        }

        public TEntity Save(TEntity entity)
        {
            throw new System.NotImplementedException();
        }

        public TEntity Update(TEntity entity)
        {
            throw new System.NotImplementedException();
        }

        public void DeletById(int id)
        {
            throw new System.NotImplementedException();
        }

        public void Delete(TEntity entity)
        {
            DeletById(entity.Id);
        }
    }
}
