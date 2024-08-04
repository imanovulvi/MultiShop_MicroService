using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MultiShop.Order.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class mig2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Detail",
                table: "Adreses",
                newName: "ZipCode");

            migrationBuilder.AddColumn<string>(
                name: "Country",
                table: "Adreses",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Detail1",
                table: "Adreses",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Detail2",
                table: "Adreses",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Country",
                table: "Adreses");

            migrationBuilder.DropColumn(
                name: "Detail1",
                table: "Adreses");

            migrationBuilder.DropColumn(
                name: "Detail2",
                table: "Adreses");

            migrationBuilder.RenameColumn(
                name: "ZipCode",
                table: "Adreses",
                newName: "Detail");
        }
    }
}
