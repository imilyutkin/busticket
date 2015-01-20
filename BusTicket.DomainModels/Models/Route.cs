using System;
using BusTicket.DomainModels.Constants;
using BusTicket.DomainModels.Repositories.Attributes;

namespace BusTicket.DomainModels.Models
{
    [TableName(TableConstants.RoutesTableName)]
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
