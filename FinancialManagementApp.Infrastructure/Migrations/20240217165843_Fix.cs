using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FinancialManagementApp.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class Fix : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Wallets_WalletHistories_WalletHistoryId",
                table: "Wallets");

            migrationBuilder.DropIndex(
                name: "IX_Wallets_WalletHistoryId",
                table: "Wallets");

            migrationBuilder.DropColumn(
                name: "WalletHistoryId",
                table: "Wallets");

            migrationBuilder.AddColumn<int>(
                name: "WalletId",
                table: "WalletHistories",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_WalletHistories_WalletId",
                table: "WalletHistories",
                column: "WalletId");

            migrationBuilder.AddForeignKey(
                name: "FK_WalletHistories_Wallets_WalletId",
                table: "WalletHistories",
                column: "WalletId",
                principalTable: "Wallets",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_WalletHistories_Wallets_WalletId",
                table: "WalletHistories");

            migrationBuilder.DropIndex(
                name: "IX_WalletHistories_WalletId",
                table: "WalletHistories");

            migrationBuilder.DropColumn(
                name: "WalletId",
                table: "WalletHistories");

            migrationBuilder.AddColumn<int>(
                name: "WalletHistoryId",
                table: "Wallets",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Wallets_WalletHistoryId",
                table: "Wallets",
                column: "WalletHistoryId");

            migrationBuilder.AddForeignKey(
                name: "FK_Wallets_WalletHistories_WalletHistoryId",
                table: "Wallets",
                column: "WalletHistoryId",
                principalTable: "WalletHistories",
                principalColumn: "Id");
        }
    }
}
