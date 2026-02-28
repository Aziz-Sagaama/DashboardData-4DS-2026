using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DashboardData.Migrations
{
    /// <inheritdoc />
    public partial class ModifSensorValueHistory : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "SensorValueHistor",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    MeasuredValue = table.Column<double>(type: "REAL", nullable: false),
                    Timestamp = table.Column<DateTime>(type: "TEXT", nullable: false),
                    SensorDataId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SensorValueHistor", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SensorValueHistor_Sensors_SensorDataId",
                        column: x => x.SensorDataId,
                        principalTable: "Sensors",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_SensorValueHistor_SensorDataId",
                table: "SensorValueHistor",
                column: "SensorDataId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "SensorValueHistor");
        }
    }
}
