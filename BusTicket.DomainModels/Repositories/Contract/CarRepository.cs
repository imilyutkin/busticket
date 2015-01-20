using BusTicket.DomainModels.Models;
using BusTicket.DomainModels.Repositories.Impl;

namespace BusTicket.DomainModels.Repositories.Contract
{
    public class CarRepository : BaseRepository<Car>, ICarRepository
    {
    }
}
