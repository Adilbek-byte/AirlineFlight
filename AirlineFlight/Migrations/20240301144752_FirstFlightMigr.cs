using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AirlineFlight.Migrations
{
    /// <inheritdoc />
    public partial class FirstFlightMigr : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "FlightSchedules",
                columns: table => new
                {
                    FlightId = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Departure = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Return = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FlightSchedules", x => x.FlightId);
                });

            migrationBuilder.CreateTable(
                name: "LocationPaths",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FromWhere = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ToWhere = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    HotFlightId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LocationPaths", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Passengers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Adult = table.Column<int>(type: "int", nullable: false),
                    Child = table.Column<int>(type: "int", nullable: false),
                    TotalPeople = table.Column<int>(type: "int", nullable: false),
                    TotalSum = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FreeTaxi = table.Column<bool>(type: "bit", nullable: false),
                    FlightId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Passengers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "HotFlights",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AviaName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CountOfTicket = table.Column<int>(type: "int", nullable: false),
                    TypeOfPrice = table.Column<int>(type: "int", nullable: false),
                    DateTimeOfTicket = table.Column<DateTime>(type: "datetime2", nullable: false),
                    PathId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HotFlights", x => x.Id);
                    table.ForeignKey(
                        name: "FK_HotFlights_LocationPaths_PathId",
                        column: x => x.PathId,
                        principalTable: "LocationPaths",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Tickets",
                columns: table => new
                {
                    PassengerId = table.Column<int>(type: "int", nullable: false),
                    FlightClassId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tickets", x => x.PassengerId);
                    table.ForeignKey(
                        name: "FK_Tickets_Passengers_PassengerId",
                        column: x => x.PassengerId,
                        principalTable: "Passengers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "FlightClass",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TypeOfPricesId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FlightClass", x => x.Id);
                    table.ForeignKey(
                        name: "FK_FlightClass_Tickets_TypeOfPricesId",
                        column: x => x.TypeOfPricesId,
                        principalTable: "Tickets",
                        principalColumn: "PassengerId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Flights",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AviaName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsAvailable = table.Column<bool>(type: "bit", nullable: false),
                    Type = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DirectionId = table.Column<int>(type: "int", nullable: false),
                    DateId = table.Column<int>(type: "int", nullable: false),
                    DateFlightId = table.Column<long>(type: "bigint", nullable: false),
                    TypeOfPricesId = table.Column<int>(type: "int", nullable: false),
                    PassengerId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Flights", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Flights_FlightSchedules_DateFlightId",
                        column: x => x.DateFlightId,
                        principalTable: "FlightSchedules",
                        principalColumn: "FlightId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Flights_LocationPaths_DirectionId",
                        column: x => x.DirectionId,
                        principalTable: "LocationPaths",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Flights_Passengers_PassengerId",
                        column: x => x.PassengerId,
                        principalTable: "Passengers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Flights_Tickets_TypeOfPricesId",
                        column: x => x.TypeOfPricesId,
                        principalTable: "Tickets",
                        principalColumn: "PassengerId");
                });

            migrationBuilder.CreateIndex(
                name: "IX_FlightClass_TypeOfPricesId",
                table: "FlightClass",
                column: "TypeOfPricesId");

            migrationBuilder.CreateIndex(
                name: "IX_Flights_DateFlightId",
                table: "Flights",
                column: "DateFlightId");

            migrationBuilder.CreateIndex(
                name: "IX_Flights_DirectionId",
                table: "Flights",
                column: "DirectionId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Flights_PassengerId",
                table: "Flights",
                column: "PassengerId");

            migrationBuilder.CreateIndex(
                name: "IX_Flights_TypeOfPricesId",
                table: "Flights",
                column: "TypeOfPricesId");

            migrationBuilder.CreateIndex(
                name: "IX_HotFlights_PathId",
                table: "HotFlights",
                column: "PathId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "FlightClass");

            migrationBuilder.DropTable(
                name: "Flights");

            migrationBuilder.DropTable(
                name: "HotFlights");

            migrationBuilder.DropTable(
                name: "FlightSchedules");

            migrationBuilder.DropTable(
                name: "Tickets");

            migrationBuilder.DropTable(
                name: "LocationPaths");

            migrationBuilder.DropTable(
                name: "Passengers");
        }
    }
}
