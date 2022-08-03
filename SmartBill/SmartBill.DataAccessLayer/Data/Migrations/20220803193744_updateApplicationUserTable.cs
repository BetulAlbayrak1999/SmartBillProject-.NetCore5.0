using Microsoft.EntityFrameworkCore.Migrations;

namespace SmartBill.Data.Migrations
{
    public partial class updateApplicationUserTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Apartments_Users_CustomerId",
                table: "Apartments");

            migrationBuilder.DropForeignKey(
                name: "FK_Bills_Users_CustomerId",
                table: "Bills");

            migrationBuilder.DropForeignKey(
                name: "FK_CreditCard_Users_CustomerId",
                table: "CreditCard");

            migrationBuilder.DropForeignKey(
                name: "FK_Payment_Users_CustomerId",
                table: "Payment");

            migrationBuilder.DropIndex(
                name: "IX_Apartments_CustomerId",
                table: "Apartments");

            migrationBuilder.DropColumn(
                name: "Discriminator",
                schema: "security",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "CustomerId",
                table: "Apartments");

            migrationBuilder.RenameColumn(
                name: "CustomerId",
                table: "Payment",
                newName: "ApplicationUserId");

            migrationBuilder.RenameIndex(
                name: "IX_Payment_CustomerId",
                table: "Payment",
                newName: "IX_Payment_ApplicationUserId");

            migrationBuilder.RenameColumn(
                name: "CustomerId",
                table: "CreditCard",
                newName: "ApplicationUserId");

            migrationBuilder.RenameIndex(
                name: "IX_CreditCard_CustomerId",
                table: "CreditCard",
                newName: "IX_CreditCard_ApplicationUserId");

            migrationBuilder.RenameColumn(
                name: "CustomerId",
                table: "Bills",
                newName: "ApplicationUserId");

            migrationBuilder.RenameIndex(
                name: "IX_Bills_CustomerId",
                table: "Bills",
                newName: "IX_Bills_ApplicationUserId");

            migrationBuilder.AddColumn<string>(
                name: "ApartmentId",
                schema: "security",
                table: "Users",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Users_ApartmentId",
                schema: "security",
                table: "Users",
                column: "ApartmentId");

            migrationBuilder.AddForeignKey(
                name: "FK_Bills_Users_ApplicationUserId",
                table: "Bills",
                column: "ApplicationUserId",
                principalSchema: "security",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_CreditCard_Users_ApplicationUserId",
                table: "CreditCard",
                column: "ApplicationUserId",
                principalSchema: "security",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Payment_Users_ApplicationUserId",
                table: "Payment",
                column: "ApplicationUserId",
                principalSchema: "security",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Users_Apartments_ApartmentId",
                schema: "security",
                table: "Users",
                column: "ApartmentId",
                principalTable: "Apartments",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Bills_Users_ApplicationUserId",
                table: "Bills");

            migrationBuilder.DropForeignKey(
                name: "FK_CreditCard_Users_ApplicationUserId",
                table: "CreditCard");

            migrationBuilder.DropForeignKey(
                name: "FK_Payment_Users_ApplicationUserId",
                table: "Payment");

            migrationBuilder.DropForeignKey(
                name: "FK_Users_Apartments_ApartmentId",
                schema: "security",
                table: "Users");

            migrationBuilder.DropIndex(
                name: "IX_Users_ApartmentId",
                schema: "security",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "ApartmentId",
                schema: "security",
                table: "Users");

            migrationBuilder.RenameColumn(
                name: "ApplicationUserId",
                table: "Payment",
                newName: "CustomerId");

            migrationBuilder.RenameIndex(
                name: "IX_Payment_ApplicationUserId",
                table: "Payment",
                newName: "IX_Payment_CustomerId");

            migrationBuilder.RenameColumn(
                name: "ApplicationUserId",
                table: "CreditCard",
                newName: "CustomerId");

            migrationBuilder.RenameIndex(
                name: "IX_CreditCard_ApplicationUserId",
                table: "CreditCard",
                newName: "IX_CreditCard_CustomerId");

            migrationBuilder.RenameColumn(
                name: "ApplicationUserId",
                table: "Bills",
                newName: "CustomerId");

            migrationBuilder.RenameIndex(
                name: "IX_Bills_ApplicationUserId",
                table: "Bills",
                newName: "IX_Bills_CustomerId");

            migrationBuilder.AddColumn<string>(
                name: "Discriminator",
                schema: "security",
                table: "Users",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "CustomerId",
                table: "Apartments",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Apartments_CustomerId",
                table: "Apartments",
                column: "CustomerId");

            migrationBuilder.AddForeignKey(
                name: "FK_Apartments_Users_CustomerId",
                table: "Apartments",
                column: "CustomerId",
                principalSchema: "security",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Bills_Users_CustomerId",
                table: "Bills",
                column: "CustomerId",
                principalSchema: "security",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_CreditCard_Users_CustomerId",
                table: "CreditCard",
                column: "CustomerId",
                principalSchema: "security",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Payment_Users_CustomerId",
                table: "Payment",
                column: "CustomerId",
                principalSchema: "security",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
