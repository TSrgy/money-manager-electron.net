using Microsoft.EntityFrameworkCore.Migrations;

namespace MoneyManager.Infrastructure.Persistence.Migrations
{
    public partial class FixAccount : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AccessInfo",
                table: "Accounts");

            migrationBuilder.DropColumn(
                name: "FavoriteAcct",
                table: "Accounts");

            migrationBuilder.RenameColumn(
                name: "Heldat",
                table: "Accounts",
                newName: "HeldAt");

            migrationBuilder.RenameColumn(
                name: "Num",
                table: "Accounts",
                newName: "Number");

            migrationBuilder.AddColumn<bool>(
                name: "IsFavorite",
                table: "Accounts",
                type: "INTEGER",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsFavorite",
                table: "Accounts");

            migrationBuilder.RenameColumn(
                name: "HeldAt",
                table: "Accounts",
                newName: "Heldat");

            migrationBuilder.RenameColumn(
                name: "Number",
                table: "Accounts",
                newName: "Num");

            migrationBuilder.AddColumn<string>(
                name: "AccessInfo",
                table: "Accounts",
                type: "TEXT",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "FavoriteAcct",
                table: "Accounts",
                type: "TEXT",
                nullable: true);
        }
    }
}
