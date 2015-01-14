using FluentMigrator;

namespace BusTicket.DomainModels.Migrations
{
    [Migration(1)]
    public class CreateTablesMigration : Migration
    {
        public override void Up()
        {
            Create.Table("Colors")
                .WithColumn("Id").AsInt32().NotNullable().PrimaryKey().Identity()
                .WithColumn("Title").AsString().NotNullable().Unique()
                .WithColumn("Picture").AsString();

            Create.Table("CarModels")
                .WithColumn("Id").AsInt32().NotNullable().PrimaryKey().Identity()
                .WithColumn("Title").AsString().NotNullable().Unique()
                .WithColumn("Picture").AsString();

            Create.Table("Cars")
                .WithColumn("Id").AsInt32().NotNullable().PrimaryKey().Identity()
                .WithColumn("Number").AsString().NotNullable().Unique()
                .WithColumn("Color_Id").AsInt32().NotNullable().ForeignKey("Colors","Id")
                .WithColumn("Picture").AsString().NotNullable()
                .WithColumn("CarModel").AsInt32().NotNullable().ForeignKey("CarModels", "Id")
                .WithColumn("QuantityOfPassenger").AsInt32().NotNullable().WithDefaultValue(0);
            
            Create.Table("Routes")
                .WithColumn("Id").AsInt32().NotNullable().PrimaryKey().Identity()
                .WithColumn("StartPoint").AsString().NotNullable()
                .WithColumn("DestinationPoint").AsString().NotNullable();

            Create.Table("Vehicles")
                .WithColumn("Id").AsInt32().NotNullable().PrimaryKey().Identity()
                .WithColumn("Route_Id").AsInt32().ForeignKey().NotNullable().ForeignKey("Routes", "Id")
                .WithColumn("TimeOfDeparture").AsDateTime().NotNullable()
                .WithColumn("Car_Id").AsInt32().NotNullable().ForeignKey("Cars", "Id");
        }

        public override void Down()
        {
            Delete.Table("Colors");
            Delete.Table("CarModels");
            Delete.Table("Cars");
            Delete.Table("Routes");
            Delete.Table("Vehicles");
        }
    }
}
