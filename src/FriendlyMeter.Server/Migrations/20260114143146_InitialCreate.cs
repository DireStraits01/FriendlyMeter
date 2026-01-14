using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FriendlyMeter.Server.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    Name = table.Column<string>(type: "TEXT", nullable: false),
                    Role = table.Column<int>(type: "INTEGER", nullable: false),
                    PhoneNumber = table.Column<string>(type: "TEXT", nullable: false),
                    Email = table.Column<string>(type: "TEXT", nullable: true),
                    DateCreated = table.Column<DateTime>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Tariffs",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    Name = table.Column<string>(type: "TEXT", nullable: false),
                    OwnerId = table.Column<Guid>(type: "TEXT", nullable: false),
                    ElectricityPhasesCount = table.Column<int>(type: "INTEGER", nullable: false),
                    ElectricityPricePhase1 = table.Column<decimal>(type: "TEXT", nullable: false),
                    ElectricityPricePhase2 = table.Column<decimal>(type: "TEXT", nullable: true),
                    ElectricityPricePhase3 = table.Column<decimal>(type: "TEXT", nullable: true),
                    ColdWaterPrice = table.Column<decimal>(type: "TEXT", nullable: false),
                    HotWaterPrice = table.Column<decimal>(type: "TEXT", nullable: false),
                    SeweragePrice = table.Column<decimal>(type: "TEXT", nullable: false),
                    DateCreated = table.Column<DateTime>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tariffs", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Tariffs_Users_OwnerId",
                        column: x => x.OwnerId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Flats",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    Name = table.Column<string>(type: "TEXT", nullable: false),
                    FlatTariffId = table.Column<Guid>(type: "TEXT", nullable: true),
                    OwnerId = table.Column<Guid>(type: "TEXT", nullable: false),
                    RenterId = table.Column<Guid>(type: "TEXT", nullable: true),
                    City = table.Column<string>(type: "TEXT", nullable: true),
                    Street = table.Column<string>(type: "TEXT", nullable: true),
                    Number = table.Column<string>(type: "TEXT", nullable: true),
                    ZipCode = table.Column<string>(type: "TEXT", nullable: true),
                    DateCreated = table.Column<DateTime>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Flats", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Flats_Tariffs_FlatTariffId",
                        column: x => x.FlatTariffId,
                        principalTable: "Tariffs",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Flats_Users_OwnerId",
                        column: x => x.OwnerId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Flats_Users_RenterId",
                        column: x => x.RenterId,
                        principalTable: "Users",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Metrics",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    FlatId = table.Column<Guid>(type: "TEXT", nullable: false),
                    SubmittedDate = table.Column<DateTime>(type: "TEXT", nullable: false),
                    ColdWaterValue = table.Column<int>(type: "INTEGER", nullable: false),
                    HotWaterValue = table.Column<int>(type: "INTEGER", nullable: false),
                    ElectricityPhase1 = table.Column<int>(type: "INTEGER", nullable: true),
                    ElectricityPhase2 = table.Column<int>(type: "INTEGER", nullable: true),
                    ElectricityPhase3 = table.Column<int>(type: "INTEGER", nullable: true),
                    ColdWaterPriceAtSubmission = table.Column<decimal>(type: "TEXT", nullable: false),
                    HotWaterPriceAtSubmission = table.Column<decimal>(type: "TEXT", nullable: false),
                    SeweragePriceAtSubmission = table.Column<decimal>(type: "TEXT", nullable: false),
                    ElectricityPriceAtSubmissionPhase1 = table.Column<decimal>(type: "TEXT", nullable: false),
                    ElectricityPriceAtSubmissionPhase2 = table.Column<decimal>(type: "TEXT", nullable: true),
                    ElectricityPriceAtSubmissionPhase3 = table.Column<decimal>(type: "TEXT", nullable: true),
                    DateCreated = table.Column<DateTime>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Metrics", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Metrics_Flats_FlatId",
                        column: x => x.FlatId,
                        principalTable: "Flats",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Flats_FlatTariffId",
                table: "Flats",
                column: "FlatTariffId");

            migrationBuilder.CreateIndex(
                name: "IX_Flats_OwnerId",
                table: "Flats",
                column: "OwnerId");

            migrationBuilder.CreateIndex(
                name: "IX_Flats_RenterId",
                table: "Flats",
                column: "RenterId");

            migrationBuilder.CreateIndex(
                name: "IX_Metrics_FlatId",
                table: "Metrics",
                column: "FlatId");

            migrationBuilder.CreateIndex(
                name: "IX_Tariffs_OwnerId",
                table: "Tariffs",
                column: "OwnerId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Metrics");

            migrationBuilder.DropTable(
                name: "Flats");

            migrationBuilder.DropTable(
                name: "Tariffs");

            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
