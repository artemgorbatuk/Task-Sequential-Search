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
            migrationBuilder.Sql(@"
                IF NOT EXISTS (SELECT 1 FROM sys.databases WHERE name='SequentialSearch')
                    CREATE DATABASE SequentialSearch;
                GO");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            // можно добавить логику удаления базы
        }
    }
}
