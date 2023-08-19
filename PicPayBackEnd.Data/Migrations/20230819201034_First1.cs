using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PicPayBackEnd.Data.Migrations
{
    /// <inheritdoc />
    public partial class First1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Transactions_Payees_FkPayer",
                table: "Transactions");

            migrationBuilder.CreateIndex(
                name: "IX_Transactions_FkPayee",
                table: "Transactions",
                column: "FkPayee");

            migrationBuilder.AddForeignKey(
                name: "FK_Transactions_Payees_FkPayee",
                table: "Transactions",
                column: "FkPayee",
                principalTable: "Payees",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Transactions_Payees_FkPayee",
                table: "Transactions");

            migrationBuilder.DropIndex(
                name: "IX_Transactions_FkPayee",
                table: "Transactions");

            migrationBuilder.AddForeignKey(
                name: "FK_Transactions_Payees_FkPayer",
                table: "Transactions",
                column: "FkPayer",
                principalTable: "Payees",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
