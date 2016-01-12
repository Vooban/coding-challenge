using FluentMigrator;

namespace Coding_Challenge.Migrations
{
    [Migration(20160107133806)]
    public class InitialMigration : Migration
    {
        public override void Up()
        {
            Create.Table("Cities")
                .WithColumn("id").AsInt32().PrimaryKey()
                .WithColumn("name").AsAnsiString(300).NotNullable()
                .WithColumn("lat").AsDouble().NotNullable()
                .WithColumn("long").AsDouble().NotNullable()
                .WithColumn("country").AsAnsiString(2).NotNullable()
                .WithColumn("stateprov").AsAnsiString(10).NotNullable();

            Execute.EmbeddedScript("Cities.sql");
        }

        public override void Down()
        {
            Delete.Table("Cities");
        }
    }
}