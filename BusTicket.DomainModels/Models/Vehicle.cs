using System;
using BusTicket.DomainModels.Constants;
using BusTicket.DomainModels.Repositories.Attributes;

namespace BusTicket.DomainModels.Models
{
    [TableName(TableConstants.VehiclesTableName)]
    public class Vehicle : EntityBase
    {
        public Route Route
        {
            get;
            set;
        }

        public DateTime TimeOfDeparture
        {
            get; set;
        }

        public Car Car
        {
            get;
            set;
        }
    }
}
