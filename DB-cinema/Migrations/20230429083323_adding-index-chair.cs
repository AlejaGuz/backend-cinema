using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DB_cinema.Migrations
{
    /// <inheritdoc />
    public partial class addingindexchair : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "Unique_NumberRow",
                table: "Aleja_Chairs",
                columns: new[] { "Number", "Row" },
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "Unique_NumberRow",
                table: "Aleja_Chairs");
        }
    }
}
