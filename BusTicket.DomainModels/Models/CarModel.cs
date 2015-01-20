using BusTicket.DomainModels.Constants;
using BusTicket.DomainModels.Repositories.Attributes;

namespace BusTicket.DomainModels.Models
{
    [TableName(TableConstants.CarModelsTableName)]
    public class CarModel : EntityBase
    {
        public string Title
        {
            get;
            set;
        }
    }
}
