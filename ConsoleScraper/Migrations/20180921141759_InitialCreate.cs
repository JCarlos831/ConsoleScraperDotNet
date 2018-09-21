using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ConsoleScraper.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Stocks",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Symbol = table.Column<string>(nullable: true),
                    LastPrice = table.Column<string>(nullable: true),
                    PercentChange = table.Column<string>(nullable: true),
                    Currency = table.Column<string>(nullable: true),
                    MarketTime = table.Column<string>(nullable: true),
                    Volume = table.Column<string>(nullable: true),
                    Shares = table.Column<string>(nullable: true),
                    AvgVol3m = table.Column<string>(nullable: true),
                    MarketCap = table.Column<string>(nullable: true),
                    Date = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Stocks", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Stocks");
        }
    }
}
