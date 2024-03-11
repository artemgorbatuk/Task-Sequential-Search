using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Datasource.Migrations
{
    /// <inheritdoc />
    public partial class Task_0001 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@"create table TestTable(
                                    ID int primary key identity(1,1),
                                    TextData nvarchar(128) not null);");

            migrationBuilder.Sql(@"go
                                    declare @totalAdded int = 0
                                    while @totalAdded < 100000
                                    begin
                                    insert into TestTable (TextData)
                                    values (
                                    replace(newID(), '-', '')
                                    + replace(newID(), '-', '')
                                    + replace(newID(), '-', '')
                                    + replace(newID(), '-', ''))
                                    set @totalAdded = @totalAdded + 1
                                    end");

            //migrationBuilder.EnsureSchema(
            //    name: "dbo");

            //migrationBuilder.CreateTable(
            //    name: "TestTable",
            //    schema: "dbo",
            //    columns: table => new
            //    {
            //        Id = table.Column<int>(type: "int", nullable: false)
            //            .Annotation("SqlServer:Identity", "1, 1"),
            //        TextData = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false)
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK_TestTable", x => x.Id);
            //    });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("DROP TABLE TestTable;");

            //migrationBuilder.DropTable(
            //    name: "TestTable",
            //    schema: "dbo");
        }
    }
}
