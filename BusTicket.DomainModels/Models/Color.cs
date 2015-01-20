using System;
using BusTicket.DomainModels.Constants;
using BusTicket.DomainModels.Repositories.Attributes;

namespace BusTicket.DomainModels.Models
{
    [TableName(TableConstants.ColorsTableName)]
    public class Color : EntityBase
    {
        public String Title
        {
            get;
            set;
        }

        public String Picture
        {
            get;
            set;
        }
    }
}
