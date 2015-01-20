using System.Collections;
using System.Collections.Generic;
using BusTicket.DomainModels.Models;

namespace BusTicket.DomainModels.Repositories.Contract
{
    public interface IBaseRepository<TEntity> where TEntity : EntityBase
    {
        TEntity GetById(int id);

        TEntity Save(TEntity entity);

        TEntity Update(TEntity entity);

        void DeletById(int id);

        void Delete(TEntity entity);

        IEnumerable<TEntity> GetAll();
    }
}
