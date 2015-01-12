using System;

namespace BusTicket.DomainModels.Models
{
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
