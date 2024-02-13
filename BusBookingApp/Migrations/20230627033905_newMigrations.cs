using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BusBookingApp.Migrations
{
    /// <inheritdoc />
    public partial class newMigrations : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "busDetails",
                columns: table => new
                {
                    serialNo = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    registrationNo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    source = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    destination = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    pickupDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    pickuptime = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    droptime = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_busDetails", x => x.serialNo);
                });

            migrationBuilder.CreateTable(
                name: "busNames",
                columns: table => new
                {
                    serialno = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    busName = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    busNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    pickupplace = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    dropplace = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    pickuptime = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    droptime = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    pickupDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    _1 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    _2 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    _3 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    _4 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    _5 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    _6 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    _7 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    _8 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    _9 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    _10 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    _11 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    _12 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    _13 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    _14 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    _15 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    _16 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    _17 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    _18 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    _19 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    _20 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    _21 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    _22 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    _23 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    _24 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    _25 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    _26 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    _27 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    _28 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    _29 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    _30 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    _31 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    _32 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    _33 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    _34 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    _35 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    _36 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    _37 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    _38 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    _39 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    _40 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    _41 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    _42 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    _43 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    _44 = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_busNames", x => x.serialno);
                });

            migrationBuilder.CreateTable(
                name: "busRatting",
                columns: table => new
                {
                    sno = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    username = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    rattings = table.Column<int>(type: "int", nullable: false),
                    command = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    busname = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_busRatting", x => x.sno);
                });

            migrationBuilder.CreateTable(
                name: "logins",
                columns: table => new
                {
                    serialNo = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    userName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    phonenumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    password = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_logins", x => x.serialNo);
                });

            migrationBuilder.CreateTable(
                name: "user",
                columns: table => new
                {
                    sno = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    userName = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    busname = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    registrationno = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    seatno = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    source = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    destination = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    pickupDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    pickuptime = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    droptime = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_user", x => x.sno);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "busDetails");

            migrationBuilder.DropTable(
                name: "busNames");

            migrationBuilder.DropTable(
                name: "busRatting");

            migrationBuilder.DropTable(
                name: "logins");

            migrationBuilder.DropTable(
                name: "user");
        }
    }
}
