using Microsoft.EntityFrameworkCore.Migrations;

namespace SmartBill.DataAccessLayer.Migrations
{
    public partial class changeColumnNameInLocation : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "CityName",
                table: "Locations",
                newName: "Region");

            migrationBuilder.AddColumn<string>(
                name: "City",
                table: "Locations",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "City",
                table: "Locations");

            migrationBuilder.RenameColumn(
                name: "Region",
                table: "Locations",
                newName: "CityName");
        }
    }
}
