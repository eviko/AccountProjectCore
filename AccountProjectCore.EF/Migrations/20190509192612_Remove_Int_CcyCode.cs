using Microsoft.EntityFrameworkCore.Migrations;

namespace AccountProjectCore.Data.Migrations
{
    public partial class Remove_Int_CcyCode : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CurrencyCode",
                table: "Currencies");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CurrencyCode",
                table: "Currencies",
                nullable: false,
                defaultValue: 0);
        }
    }
}
