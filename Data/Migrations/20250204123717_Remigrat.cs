using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace VideoShopRentalMVC1.Data.Migrations
{
    /// <inheritdoc />
    public partial class Remigrat : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_RentalDetail_RentalReturn_RentalReturnId",
                table: "RentalDetail");

            migrationBuilder.DropForeignKey(
                name: "FK_RentalDetail_Rental_RentalId",
                table: "RentalDetail");

            migrationBuilder.DropTable(
                name: "RentalReturn");

            migrationBuilder.DropIndex(
                name: "IX_RentalDetail_RentalId",
                table: "RentalDetail");

            migrationBuilder.DropIndex(
                name: "IX_RentalDetail_RentalReturnId",
                table: "RentalDetail");

            migrationBuilder.DropColumn(
                name: "RentalId",
                table: "RentalDetail");

            migrationBuilder.DropColumn(
                name: "RentalReturnId",
                table: "RentalDetail");

            migrationBuilder.AddColumn<DateTime>(
                name: "ReleaseDate",
                table: "Movie",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AlterColumn<string>(
                name: "Email",
                table: "Customer",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "Address",
                table: "Customer",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddColumn<string>(
                name: "Phone",
                table: "Customer",
                type: "nvarchar(max)",
                nullable: true);

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

            migrationBuilder.CreateIndex(
                name: "IX_RentalDetail_RentalHeaderId",
                table: "RentalDetail",
                column: "RentalHeaderId");

            migrationBuilder.AddForeignKey(
                name: "FK_RentalDetail_Rental_RentalHeaderId",
                table: "RentalDetail",
                column: "RentalHeaderId",
                principalTable: "Rental",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_RentalDetail_Rental_RentalHeaderId",
                table: "RentalDetail");

            migrationBuilder.DropIndex(
                name: "IX_RentalDetail_RentalHeaderId",
                table: "RentalDetail");

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
                name: "ReleaseDate",
                table: "Movie");

            migrationBuilder.DropColumn(
                name: "Phone",
                table: "Customer");

            migrationBuilder.AddColumn<int>(
                name: "RentalId",
                table: "RentalDetail",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "RentalReturnId",
                table: "RentalDetail",
                type: "int",
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Email",
                table: "Customer",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Address",
                table: "Customer",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.CreateTable(
                name: "RentalReturn",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CustomerId = table.Column<int>(type: "int", nullable: false),
                    RentalId = table.Column<int>(type: "int", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LateFee = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    ReturnDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RentalReturn", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RentalReturn_Customer_CustomerId",
                        column: x => x.CustomerId,
                        principalTable: "Customer",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_RentalReturn_Rental_RentalId",
                        column: x => x.RentalId,
                        principalTable: "Rental",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_RentalDetail_RentalId",
                table: "RentalDetail",
                column: "RentalId");

            migrationBuilder.CreateIndex(
                name: "IX_RentalDetail_RentalReturnId",
                table: "RentalDetail",
                column: "RentalReturnId");

            migrationBuilder.CreateIndex(
                name: "IX_RentalReturn_CustomerId",
                table: "RentalReturn",
                column: "CustomerId");

            migrationBuilder.CreateIndex(
                name: "IX_RentalReturn_RentalId",
                table: "RentalReturn",
                column: "RentalId");

            migrationBuilder.AddForeignKey(
                name: "FK_RentalDetail_RentalReturn_RentalReturnId",
                table: "RentalDetail",
                column: "RentalReturnId",
                principalTable: "RentalReturn",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_RentalDetail_Rental_RentalId",
                table: "RentalDetail",
                column: "RentalId",
                principalTable: "Rental",
                principalColumn: "Id");
        }
    }
}
