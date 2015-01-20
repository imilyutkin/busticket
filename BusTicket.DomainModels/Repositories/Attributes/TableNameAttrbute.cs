using System;

namespace BusTicket.DomainModels.Repositories.Attributes
{
    [AttributeUsage(AttributeTargets.Class)]
    public class TableNameAttribute : Attribute
    {
        public TableNameAttribute(String tableName)
        {
            Name = tableName;
        }

        public String Name
        {
            get;
            private set;
        }
    }
}
