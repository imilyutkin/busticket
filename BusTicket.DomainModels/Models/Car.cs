using System;
using BusTicket.DomainModels.Constants;
using BusTicket.DomainModels.Repositories.Attributes;

namespace BusTicket.DomainModels.Models
{
    [TableName(TableConstants.CarsTableName)]
    public class Car : EntityBase
    {
        public String Number
        {
            get;
            set;
        }

        public Color Color
        {
            get;
            set;
        }

        public String Picture
        {
            get;
            set;
        }

        public CarModel CarModel
        {
            get;
            set;
        }

        public Int32 QuantityOfPassenger
        {
            get;
            set;
        }
    }
}
