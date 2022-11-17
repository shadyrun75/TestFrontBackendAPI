using FluentMigrator;

namespace shadyrun75.TestFrontBackendAPI.DB.SQLite.Migrations
{
    [Migration(20221115)]
    public class Script_001 : Migration
    {
        public override void Up()
        {
            Create.Table("Users")
                .WithColumn("Id").AsInt64().PrimaryKey().Identity()
                .WithColumn("Login").AsString().Unique()
                .WithColumn("Display").AsString()
                .WithColumn("PasswordHash").AsString()
                .WithColumn("IsActive").AsBoolean();
            Create.Table("Roots")
                .WithColumn("Id").AsInt16().PrimaryKey().Identity()
                .WithColumn("Code").AsString()
                .WithColumn("Description").AsString();
            Create.Table("UsersRoots")
                .WithColumn("UserId").AsInt64().ForeignKey("Users", "Id")
                .WithColumn("RootId").AsString().ForeignKey("Roots", "Id");
        }

        public override void Down()
        {
            Delete.Table("UsersRoots");
            Delete.Table("Users");
            Delete.Table("Roots");
        }
    }
}
