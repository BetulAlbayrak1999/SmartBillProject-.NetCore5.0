using Microsoft.EntityFrameworkCore.Migrations;

namespace SmartBill.DataAccessLayer.Migrations
{
    public partial class changeBillTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Tax",
                table: "Bills");


            migrationBuilder.DropColumn(
                name: "TotalAmount",
                table: "Bills");

            migrationBuilder.RenameColumn(
                name: "PaidDate",
                table: "Bills",
                newName: "BillDate");

            migrationBuilder.AddColumn<string>(
                name: "ApartmentId",
                table: "Bills",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ApartmentId",
                table: "Bills");

            migrationBuilder.RenameColumn(
                name: "BillDate",
                table: "Bills",
                newName: "PaidDate");

            migrationBuilder.AddColumn<float>(
                name: "Tax",
                table: "Bills",
                type: "real",
                nullable: false,
                defaultValue: 0f);

            migrationBuilder.AddColumn<float>(
                name: "TotalAmount",
                table: "Bills",
                type: "real",
                nullable: false,
                defaultValue: 0f);
        }
    }
}
