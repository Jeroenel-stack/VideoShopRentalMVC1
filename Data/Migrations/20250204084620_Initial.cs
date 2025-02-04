using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace VideoShopRentalMVC1.Data.Migrations
{
    /// <inheritdoc />
    public partial class Initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Customer",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Customer", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Movie",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Genre = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Price = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Movie", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Rental",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CustomerId = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Customers = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    RentedDate = table.Column<DateOnly>(type: "date", nullable: false),
                    ReturnDate = table.Column<DateOnly>(type: "date", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Rental", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "RentalReturn",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RentalId = table.Column<int>(type: "int", nullable: false),
                    CustomerId = table.Column<int>(type: "int", nullable: false),
                    ReturnDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LateFee = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
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

            migrationBuilder.CreateTable(
                name: "RentalDetail",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RentalHeaderId = table.Column<int>(type: "int", nullable: false),
                    MovieId = table.Column<int>(type: "int", nullable: false),
                    Movies = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Price = table.Column<double>(type: "float", nullable: false),
                    RentalId = table.Column<int>(type: "int", nullable: true),
                    RentalReturnId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RentalDetail", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RentalDetail_RentalReturn_RentalReturnId",
                        column: x => x.RentalReturnId,
                        principalTable: "RentalReturn",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_RentalDetail_Rental_RentalId",
                        column: x => x.RentalId,
                        principalTable: "Rental",
                        principalColumn: "Id");
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
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Movie");

            migrationBuilder.DropTable(
                name: "RentalDetail");

            migrationBuilder.DropTable(
                name: "RentalReturn");

            migrationBuilder.DropTable(
                name: "Customer");

            migrationBuilder.DropTable(
                name: "Rental");
        }
    }
}
