using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace VideoShopRentalMVC1.Data.Migrations
{
    /// <inheritdoc />
    public partial class FinalRemigrate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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
                name: "ThumbnailUrl",
                table: "Movie",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "0373aa2e-44b0-4ecf-88e3-b33f74148486", null, "User", "USER" },
                    { "1c1f9f59-c17f-46ca-bc3f-eebb0f0ca01b", null, "Guest", "GUEST" },
                    { "90eace50-d02f-4a06-950e-c13e74a69814", null, "Moderator", "MODERATOR" },
                    { "cbccb3d8-8579-4218-825e-44179cf17614", null, "Admin", "ADMIN" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "0373aa2e-44b0-4ecf-88e3-b33f74148486");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "1c1f9f59-c17f-46ca-bc3f-eebb0f0ca01b");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "90eace50-d02f-4a06-950e-c13e74a69814");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "cbccb3d8-8579-4218-825e-44179cf17614");

            migrationBuilder.DropColumn(
                name: "ThumbnailUrl",
                table: "Movie");

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
        }
    }
}
