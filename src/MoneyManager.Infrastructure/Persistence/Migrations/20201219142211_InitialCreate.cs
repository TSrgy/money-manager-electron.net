using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace MoneyManager.Infrastructure.Persistence.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Assets",
                columns: table => new
                {
                    Id = table.Column<long>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", nullable: true),
                    Type = table.Column<int>(type: "INTEGER", nullable: false),
                    StartDate = table.Column<DateTime>(type: "TEXT", nullable: false),
                    Value = table.Column<decimal>(type: "TEXT", nullable: false),
                    ValueChangeType = table.Column<int>(type: "INTEGER", nullable: false),
                    ValueChangeRate = table.Column<decimal>(type: "TEXT", nullable: false),
                    Notes = table.Column<string>(type: "TEXT", nullable: true),
                    Created = table.Column<DateTimeOffset>(type: "TEXT", nullable: false),
                    LastModified = table.Column<DateTimeOffset>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Assets", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Currency",
                columns: table => new
                {
                    Id = table.Column<long>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", nullable: true),
                    PfxSymbol = table.Column<string>(type: "TEXT", nullable: true),
                    SfxSymbol = table.Column<string>(type: "TEXT", nullable: true),
                    DecimalPoint = table.Column<string>(type: "TEXT", nullable: true),
                    GroupSeparator = table.Column<string>(type: "TEXT", nullable: true),
                    Scale = table.Column<int>(type: "INTEGER", nullable: false),
                    CurrencySymbol = table.Column<string>(type: "TEXT", nullable: true),
                    CurrencyType = table.Column<string>(type: "TEXT", nullable: true),
                    Historic = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Currency", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Accounts",
                columns: table => new
                {
                    Id = table.Column<long>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", nullable: true),
                    Type = table.Column<int>(type: "INTEGER", nullable: false),
                    Num = table.Column<string>(type: "TEXT", nullable: true),
                    Status = table.Column<int>(type: "INTEGER", nullable: false),
                    Notes = table.Column<string>(type: "TEXT", nullable: true),
                    Heldat = table.Column<string>(type: "TEXT", nullable: true),
                    Website = table.Column<string>(type: "TEXT", nullable: true),
                    ContactInfo = table.Column<string>(type: "TEXT", nullable: true),
                    AccessInfo = table.Column<string>(type: "TEXT", nullable: true),
                    InitialBalance = table.Column<decimal>(type: "TEXT", nullable: false),
                    FavoriteAcct = table.Column<string>(type: "TEXT", nullable: true),
                    CurrencyId = table.Column<long>(type: "INTEGER", nullable: true),
                    StatementLocked = table.Column<int>(type: "INTEGER", nullable: false),
                    StatementDate = table.Column<DateTime>(type: "TEXT", nullable: false),
                    MinBalance = table.Column<decimal>(type: "TEXT", nullable: false),
                    CreditLimit = table.Column<decimal>(type: "TEXT", nullable: false),
                    InterestRate = table.Column<decimal>(type: "TEXT", nullable: false),
                    PaymentDueDate = table.Column<DateTime>(type: "TEXT", nullable: false),
                    MinPayment = table.Column<decimal>(type: "TEXT", nullable: false),
                    Created = table.Column<DateTimeOffset>(type: "TEXT", nullable: false),
                    LastModified = table.Column<DateTimeOffset>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Accounts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Accounts_Currency_CurrencyId",
                        column: x => x.CurrencyId,
                        principalTable: "Currency",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Accounts_CurrencyId",
                table: "Accounts",
                column: "CurrencyId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Accounts");

            migrationBuilder.DropTable(
                name: "Assets");

            migrationBuilder.DropTable(
                name: "Currency");
        }
    }
}
