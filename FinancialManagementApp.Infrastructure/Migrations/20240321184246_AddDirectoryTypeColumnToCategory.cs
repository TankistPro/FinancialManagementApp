using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FinancialManagementApp.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AddDirectoryTypeColumnToCategory : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "DirectoryType",
                table: "Categories",
                type: "nvarchar(max)",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DirectoryType",
                table: "Categories");
        }
    }
}
