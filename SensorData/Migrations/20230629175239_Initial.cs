using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SensorData.Migrations
{
    /// <inheritdoc />
    public partial class Initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Locations",
                columns: table => new
                {
                    LocationId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    LocationName = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Locations", x => x.LocationId);
                });

            migrationBuilder.CreateTable(
                name: "Sensors",
                columns: table => new
                {
                    SensorId = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    SensorName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    LocationId = table.Column<int>(type: "int", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    ActivationDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sensors", x => x.SensorId);
                    table.ForeignKey(
                        name: "FK_Sensors_Locations_LocationId",
                        column: x => x.LocationId,
                        principalTable: "Locations",
                        principalColumn: "LocationId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Measurements",
                columns: table => new
                {
                    MeasurementId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    SensorId = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    Value1 = table.Column<int>(type: "int", nullable: false),
                    Value2 = table.Column<int>(type: "int", nullable: false),
                    Value3 = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Measurements", x => x.MeasurementId);
                    table.ForeignKey(
                        name: "FK_Measurements_Sensors_SensorId",
                        column: x => x.SensorId,
                        principalTable: "Sensors",
                        principalColumn: "SensorId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Locations_LocationId",
                table: "Locations",
                column: "LocationId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Measurements_MeasurementId",
                table: "Measurements",
                column: "MeasurementId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Measurements_SensorId",
                table: "Measurements",
                column: "SensorId");

            migrationBuilder.CreateIndex(
                name: "IX_Sensors_LocationId",
                table: "Sensors",
                column: "LocationId");

            migrationBuilder.CreateIndex(
                name: "IX_Sensors_SensorId",
                table: "Sensors",
                column: "SensorId",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Measurements");

            migrationBuilder.DropTable(
                name: "Sensors");

            migrationBuilder.DropTable(
                name: "Locations");
        }
    }
}
