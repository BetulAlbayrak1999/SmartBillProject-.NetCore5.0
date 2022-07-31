using Microsoft.EntityFrameworkCore.Migrations;

namespace SmartBill.Data.Migrations
{
    public partial class ChangingColumnsName : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Salary",
                schema: "security",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "TC",
                schema: "security",
                table: "Users");

            migrationBuilder.RenameColumn(
                name: "WorkingTime",
                schema: "security",
                table: "Users",
                newName: "TurkishIdentity");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "TurkishIdentity",
                schema: "security",
                table: "Users",
                newName: "WorkingTime");

            migrationBuilder.AddColumn<int>(
                name: "Salary",
                schema: "security",
                table: "Users",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "TC",
                schema: "security",
                table: "Users",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
