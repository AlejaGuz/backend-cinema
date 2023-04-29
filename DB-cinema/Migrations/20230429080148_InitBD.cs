using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DB_cinema.Migrations
{
    /// <inheritdoc />
    public partial class InitBD : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Aleja_Levels_Chair",
                columns: table => new
                {
                    LevelID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Price = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Aleja_Levels_Chair", x => x.LevelID);
                });

            migrationBuilder.CreateTable(
                name: "Aleja_Showings",
                columns: table => new
                {
                    ShowID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MovieName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    hour = table.Column<int>(type: "int", nullable: false),
                    minutes = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Aleja_Showings", x => x.ShowID);
                });

            migrationBuilder.CreateTable(
                name: "Aleja_Chairs",
                columns: table => new
                {
                    ChairID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Number = table.Column<int>(type: "int", nullable: false),
                    Row = table.Column<string>(type: "nvarchar(1)", nullable: false),
                    LevelID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Aleja_Chairs", x => x.ChairID);
                    table.ForeignKey(
                        name: "FK_Aleja_Chairs_Aleja_Levels_Chair_LevelID",
                        column: x => x.LevelID,
                        principalTable: "Aleja_Levels_Chair",
                        principalColumn: "LevelID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Aleja_Sales",
                columns: table => new
                {
                    SaleID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ShowingID = table.Column<int>(type: "int", nullable: false),
                    SaleValue = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Aleja_Sales", x => x.SaleID);
                    table.ForeignKey(
                        name: "FK_Aleja_Sales_Aleja_Showings_ShowingID",
                        column: x => x.ShowingID,
                        principalTable: "Aleja_Showings",
                        principalColumn: "ShowID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Aleja_Tickets",
                columns: table => new
                {
                    TicketId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdShowing = table.Column<int>(type: "int", nullable: false),
                    IdChair = table.Column<int>(type: "int", nullable: false),
                    SaleID = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Aleja_Tickets", x => x.TicketId);
                    table.ForeignKey(
                        name: "FK_Aleja_Tickets_Aleja_Chairs_IdChair",
                        column: x => x.IdChair,
                        principalTable: "Aleja_Chairs",
                        principalColumn: "ChairID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Aleja_Tickets_Aleja_Sales_SaleID",
                        column: x => x.SaleID,
                        principalTable: "Aleja_Sales",
                        principalColumn: "SaleID");
                    table.ForeignKey(
                        name: "FK_Aleja_Tickets_Aleja_Showings_IdShowing",
                        column: x => x.IdShowing,
                        principalTable: "Aleja_Showings",
                        principalColumn: "ShowID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Aleja_Chairs_LevelID",
                table: "Aleja_Chairs",
                column: "LevelID");

            migrationBuilder.CreateIndex(
                name: "IX_Aleja_Sales_ShowingID",
                table: "Aleja_Sales",
                column: "ShowingID");

            migrationBuilder.CreateIndex(
                name: "IX_Aleja_Tickets_IdChair",
                table: "Aleja_Tickets",
                column: "IdChair");

            migrationBuilder.CreateIndex(
                name: "IX_Aleja_Tickets_IdShowing",
                table: "Aleja_Tickets",
                column: "IdShowing");

            migrationBuilder.CreateIndex(
                name: "IX_Aleja_Tickets_SaleID",
                table: "Aleja_Tickets",
                column: "SaleID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Aleja_Tickets");

            migrationBuilder.DropTable(
                name: "Aleja_Chairs");

            migrationBuilder.DropTable(
                name: "Aleja_Sales");

            migrationBuilder.DropTable(
                name: "Aleja_Levels_Chair");

            migrationBuilder.DropTable(
                name: "Aleja_Showings");
        }
    }
}
