using FluentMigrator;

namespace shadyrun75.TestFrontBackendAPI.DB.SQLite.Migrations
{
    [Migration(20221117)]
    public class Script_002 : Migration
    {
        public override void Up()
        {
            Create.Table("Kaktus")
                .WithColumn("Id").AsInt64().PrimaryKey().Identity()
                .WithColumn("Title").AsString()
                .WithColumn("Category").AsString()
                .WithColumn("ImageUrl").AsString(1000)
                .WithColumn("Price").AsDouble()
                .WithColumn("Description").AsString().Nullable();
        }

        public override void Down()
        {
            Delete.Table("Kaktus");
        }
    }
}
