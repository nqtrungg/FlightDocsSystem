using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FlightDocsSystem.Migrations
{
    /// <inheritdoc />
    public partial class Migrations : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Aircraft",
                columns: table => new
                {
                    AircraftId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AircraftType = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Manufacturer = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Model = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    RegistrationNumber = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Aircraft", x => x.AircraftId);
                });

            migrationBuilder.CreateTable(
                name: "Document",
                columns: table => new
                {
                    document_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    document_name = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    document_type = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    version = table.Column<int>(type: "int", nullable: false),
                    departure_date = table.Column<DateTime>(type: "datetime2", nullable: true),
                    updated_date = table.Column<DateTime>(type: "datetime2", nullable: true),
                    creator = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    description = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Document", x => x.document_id);
                });

            migrationBuilder.CreateTable(
                name: "FlightDocServer",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ServerName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    ServerAddress = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FlightDocServer", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserType = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Username = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Password = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    FullName = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    Email = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    PhoneNumber = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    UserRole = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Flight",
                columns: table => new
                {
                    FlightId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FlightNumber = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    DepartureDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ArrivalDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Origin = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Destination = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    AircraftId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Flight", x => x.FlightId);
                    table.ForeignKey(
                        name: "FK_Flight_Aircraft_AircraftId",
                        column: x => x.AircraftId,
                        principalTable: "Aircraft",
                        principalColumn: "AircraftId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ServerDocument",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ServerId = table.Column<int>(type: "int", nullable: false),
                    DocumentId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ServerDocument", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ServerDocument_Document_DocumentId",
                        column: x => x.DocumentId,
                        principalTable: "Document",
                        principalColumn: "document_id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ServerDocument_FlightDocServer_ServerId",
                        column: x => x.ServerId,
                        principalTable: "FlightDocServer",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UserDocument",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    DocumentId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserDocument", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UserDocument_Document_DocumentId",
                        column: x => x.DocumentId,
                        principalTable: "Document",
                        principalColumn: "document_id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UserDocument_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Document_Flight",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DocumentId = table.Column<int>(type: "int", nullable: false),
                    FlightId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Document_Flight", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Document_Flight_Document_DocumentId",
                        column: x => x.DocumentId,
                        principalTable: "Document",
                        principalColumn: "document_id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Document_Flight_Flight_FlightId",
                        column: x => x.FlightId,
                        principalTable: "Flight",
                        principalColumn: "FlightId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Document_Flight_DocumentId",
                table: "Document_Flight",
                column: "DocumentId");

            migrationBuilder.CreateIndex(
                name: "IX_Document_Flight_FlightId",
                table: "Document_Flight",
                column: "FlightId");

            migrationBuilder.CreateIndex(
                name: "IX_Flight_AircraftId",
                table: "Flight",
                column: "AircraftId");

            migrationBuilder.CreateIndex(
                name: "IX_ServerDocument_DocumentId",
                table: "ServerDocument",
                column: "DocumentId");

            migrationBuilder.CreateIndex(
                name: "IX_ServerDocument_ServerId",
                table: "ServerDocument",
                column: "ServerId");

            migrationBuilder.CreateIndex(
                name: "IX_UserDocument_DocumentId",
                table: "UserDocument",
                column: "DocumentId");

            migrationBuilder.CreateIndex(
                name: "IX_UserDocument_UserId",
                table: "UserDocument",
                column: "UserId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Document_Flight");

            migrationBuilder.DropTable(
                name: "ServerDocument");

            migrationBuilder.DropTable(
                name: "UserDocument");

            migrationBuilder.DropTable(
                name: "Flight");

            migrationBuilder.DropTable(
                name: "FlightDocServer");

            migrationBuilder.DropTable(
                name: "Document");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "Aircraft");
        }
    }
}
