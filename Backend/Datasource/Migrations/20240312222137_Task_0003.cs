using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Datasource.Migrations
{
    /// <inheritdoc />
    public partial class Task_0003 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@"
                IF NOT EXISTS (SELECT * FROM sys.fulltext_catalogs WHERE name = 'ftc_TestTable')
                BEGIN
                    CREATE FULLTEXT CATALOG ftc_TestTable 
                        WITH ACCENT_SENSITIVITY = OFF;
                END

                IF NOT EXISTS (SELECT * FROM sys.fulltext_indexes WHERE object_id = OBJECT_ID('TestTable'))
                BEGIN
                    CREATE FULLTEXT INDEX 
                        ON TestTable(TextData) KEY INDEX PK_TestTable_Id 
                        ON ftc_TestTable 
                        WITH CHANGE_TRACKING AUTO;
                END", true);

            migrationBuilder.Sql(@"
                ALTER FULLTEXT INDEX 
                    ON TestTable START FULL POPULATION;", true);

            migrationBuilder.Sql(@"
                ALTER FULLTEXT INDEX 
                    ON TestTable START INCREMENTAL POPULATION;", true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("ALTER FULLTEXT INDEX ON TestTable STOP POPULATION;");
            migrationBuilder.Sql("DROP FULLTEXT INDEX ON TestTable;", true);
            migrationBuilder.Sql("DROP FULLTEXT CATALOG ftc_TestTable;", true);
        }
    }
}
