using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace mathExpression.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "MathExpressions",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Expression = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MathExpressions", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Sensors",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Value = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sensors", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "MathExpressionSensors",
                columns: table => new
                {
                    MathExpressionId = table.Column<int>(type: "int", nullable: false),
                    SensorId = table.Column<int>(type: "int", nullable: false),
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MathExpressionSensors", x => new { x.MathExpressionId, x.SensorId });
                    table.ForeignKey(
                        name: "FK_MathExpressionSensors_MathExpressions_MathExpressionId",
                        column: x => x.MathExpressionId,
                        principalTable: "MathExpressions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_MathExpressionSensors_Sensors_SensorId",
                        column: x => x.SensorId,
                        principalTable: "Sensors",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Sensors",
                columns: new[] { "Id", "Name", "Value" },
                values: new object[,]
                {
                    { 1, "Sensor1", 42.5m },
                    { 2, "Sensor2", 101.3m },
                    { 3, "Sensor3", 55.7m },
                    { 4, "Sensor4", 76m },
                    { 5, "Sensor5", 89.9m }
                });

            migrationBuilder.CreateIndex(
                name: "IX_MathExpressionSensors_SensorId",
                table: "MathExpressionSensors",
                column: "SensorId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "MathExpressionSensors");

            migrationBuilder.DropTable(
                name: "MathExpressions");

            migrationBuilder.DropTable(
                name: "Sensors");
        }
    }
}
