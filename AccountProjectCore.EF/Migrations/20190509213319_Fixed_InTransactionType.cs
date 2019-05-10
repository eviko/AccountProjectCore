using Microsoft.EntityFrameworkCore.Migrations;

namespace AccountProjectCore.Data.Migrations
{
    public partial class Fixed_InTransactionType : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Transactions_TransactionTypes_InTransctionTypeId",
                table: "Transactions");

            migrationBuilder.DropIndex(
                name: "IX_Transactions_InTransctionTypeId",
                table: "Transactions");

            migrationBuilder.DropColumn(
                name: "InTransctionTypeId",
                table: "Transactions");

            migrationBuilder.CreateIndex(
                name: "IX_Transactions_InTransactionTypeId",
                table: "Transactions",
                column: "InTransactionTypeId");

            migrationBuilder.AddForeignKey(
                name: "FK_Transactions_TransactionTypes_InTransactionTypeId",
                table: "Transactions",
                column: "InTransactionTypeId",
                principalTable: "TransactionTypes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Transactions_TransactionTypes_InTransactionTypeId",
                table: "Transactions");

            migrationBuilder.DropIndex(
                name: "IX_Transactions_InTransactionTypeId",
                table: "Transactions");

            migrationBuilder.AddColumn<int>(
                name: "InTransctionTypeId",
                table: "Transactions",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Transactions_InTransctionTypeId",
                table: "Transactions",
                column: "InTransctionTypeId");

            migrationBuilder.AddForeignKey(
                name: "FK_Transactions_TransactionTypes_InTransctionTypeId",
                table: "Transactions",
                column: "InTransctionTypeId",
                principalTable: "TransactionTypes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
