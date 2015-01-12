using System;

namespace BusTicket.DomainModels.Models
{
    public class Route : EntityBase
    {
        public String StartPoint
        {
            get;
            set;
        }

        public String DestinationPoint
        {
            get;
            set;
        }
    }
}
