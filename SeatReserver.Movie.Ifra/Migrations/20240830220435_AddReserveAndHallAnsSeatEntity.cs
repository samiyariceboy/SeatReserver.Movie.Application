using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SeatReserver.Movie.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AddReserveAndHallAnsSeatEntity : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "HallId",
                table: "MovieSans",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateTable(
                name: "Halls",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false, defaultValueSql: "NEWSEQUENTIALID()"),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    LocationName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastUpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Halls", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Seats",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false, defaultValueSql: "NEWSEQUENTIALID()"),
                    SeatNumber = table.Column<int>(type: "int", maxLength: 100, nullable: false),
                    HallId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastUpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Seats", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Seats_Halls_HallId",
                        column: x => x.HallId,
                        principalTable: "Halls",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ReserveSeats",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false, defaultValueSql: "NEWSEQUENTIALID()"),
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    SeatId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    MovieSancId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ReserveStatus = table.Column<int>(type: "int", nullable: false),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastUpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ReserveSeats", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ReserveSeats_MovieSans_MovieSancId",
                        column: x => x.MovieSancId,
                        principalTable: "MovieSans",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ReserveSeats_Seats_SeatId",
                        column: x => x.SeatId,
                        principalTable: "Seats",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ReserveSeats_MovieSancId",
                table: "ReserveSeats",
                column: "MovieSancId");

            migrationBuilder.CreateIndex(
                name: "IX_ReserveSeats_SeatId",
                table: "ReserveSeats",
                column: "SeatId");

            migrationBuilder.CreateIndex(
                name: "IX_Seats_HallId",
                table: "Seats",
                column: "HallId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ReserveSeats");

            migrationBuilder.DropTable(
                name: "Seats");

            migrationBuilder.DropTable(
                name: "Halls");

            migrationBuilder.DropColumn(
                name: "HallId",
                table: "MovieSans");
        }
    }
}
