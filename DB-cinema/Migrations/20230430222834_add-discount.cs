using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DB_cinema.Migrations
{
    /// <inheritdoc />
    public partial class adddiscount : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsDiscount",
                table: "Aleja_Schedule",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsDiscount",
                table: "Aleja_Schedule");
        }
    }
}
