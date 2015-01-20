using BusTicket.DomainModels.Models;
using BusTicket.DomainModels.Repositories.Impl;

namespace BusTicket.DomainModels.Repositories.Contract
{
    public class VehicleRepository : BaseRepository<Vehicle>, IVehicleRepository
    {
    }
}
