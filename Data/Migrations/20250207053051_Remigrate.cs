using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace VideoShopRentalMVC1.Data.Migrations
{
    /// <inheritdoc />
    public partial class Remigrate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "631b0a41-d7b2-4f3c-91fe-225372a527dc");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "76ba2c83-352c-4578-bc1d-247ac1ab257d");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "94c86b13-d5ac-42d8-ad62-c0dad5b75472");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "9e650ddf-87d8-4bc1-8eca-ed1ddbedc99e");

            migrationBuilder.DropColumn(
                name: "Movies",
                table: "RentalDetail");

            migrationBuilder.DropColumn(
                name: "Customers",
                table: "Rental");

            migrationBuilder.AlterColumn<DateTime>(
                name: "ReturnDate",
                table: "Rental",
                type: "datetime2",
                nullable: false,
                oldClrType: typeof(DateOnly),
                oldType: "date");

            migrationBuilder.AlterColumn<DateTime>(
                name: "RentedDate",
                table: "Rental",
                type: "datetime2",
                nullable: false,
                oldClrType: typeof(DateOnly),
                oldType: "date");

            migrationBuilder.AlterColumn<int>(
                name: "CustomerId",
                table: "Rental",
                type: "int",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "0eeefa2d-90fc-42dc-b23f-a4f47f652dfb", null, "Admin", "ADMIN" },
                    { "86fe6c62-8de8-4577-9fb3-747b2d90d140", null, "Guest", "GUEST" },
                    { "d0fccd75-ca41-4a10-939c-aa50830597cb", null, "Moderator", "MODERATOR" },
                    { "d2b723ee-4071-4b36-a00c-420ee2feefbb", null, "User", "USER" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_RentalDetail_MovieId",
                table: "RentalDetail",
                column: "MovieId");

            migrationBuilder.CreateIndex(
                name: "IX_Rental_CustomerId",
                table: "Rental",
                column: "CustomerId");

            migrationBuilder.AddForeignKey(
                name: "FK_Rental_Customer_CustomerId",
                table: "Rental",
                column: "CustomerId",
                principalTable: "Customer",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_RentalDetail_Movie_MovieId",
                table: "RentalDetail",
                column: "MovieId",
                principalTable: "Movie",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Rental_Customer_CustomerId",
                table: "Rental");

            migrationBuilder.DropForeignKey(
                name: "FK_RentalDetail_Movie_MovieId",
                table: "RentalDetail");

            migrationBuilder.DropIndex(
                name: "IX_RentalDetail_MovieId",
                table: "RentalDetail");

            migrationBuilder.DropIndex(
                name: "IX_Rental_CustomerId",
                table: "Rental");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "0eeefa2d-90fc-42dc-b23f-a4f47f652dfb");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "86fe6c62-8de8-4577-9fb3-747b2d90d140");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "d0fccd75-ca41-4a10-939c-aa50830597cb");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "d2b723ee-4071-4b36-a00c-420ee2feefbb");

            migrationBuilder.AddColumn<string>(
                name: "Movies",
                table: "RentalDetail",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AlterColumn<DateOnly>(
                name: "ReturnDate",
                table: "Rental",
                type: "date",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.AlterColumn<DateOnly>(
                name: "RentedDate",
                table: "Rental",
                type: "date",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.AlterColumn<string>(
                name: "CustomerId",
                table: "Rental",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<string>(
                name: "Customers",
                table: "Rental",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "631b0a41-d7b2-4f3c-91fe-225372a527dc", null, "Guest", "GUEST" },
                    { "76ba2c83-352c-4578-bc1d-247ac1ab257d", null, "Moderator", "MODERATOR" },
                    { "94c86b13-d5ac-42d8-ad62-c0dad5b75472", null, "Admin", "ADMIN" },
                    { "9e650ddf-87d8-4bc1-8eca-ed1ddbedc99e", null, "User", "USER" }
                });
        }
    }
}
