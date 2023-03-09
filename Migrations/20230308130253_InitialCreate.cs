using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace L00177784_CA2_GolfApp.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "GolfMembers",
                columns: table => new
                {
                    MemberID = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    FirstName = table.Column<string>(type: "TEXT", maxLength: 100, nullable: false),
                    LastName = table.Column<string>(type: "TEXT", maxLength: 100, nullable: false),
                    Sex = table.Column<string>(type: "TEXT", maxLength: 6, nullable: false),
                    Email = table.Column<string>(type: "TEXT", nullable: false),
                    Phone = table.Column<string>(type: "TEXT", nullable: false),
                    Handicap = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GolfMembers", x => x.MemberID);
                });

            migrationBuilder.CreateTable(
                name: "TeeTimes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    RoundDate = table.Column<DateTime>(type: "TEXT", nullable: false),
                    RoundHour = table.Column<int>(type: "INTEGER", nullable: false),
                    RoundMinute = table.Column<int>(type: "INTEGER", nullable: false),
                    Player1Id = table.Column<int>(type: "INTEGER", nullable: false),
                    Player2Id = table.Column<int>(type: "INTEGER", nullable: false),
                    Player3Id = table.Column<int>(type: "INTEGER", nullable: false),
                    Player4Id = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TeeTimes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TeeTimes_GolfMembers_Player1Id",
                        column: x => x.Player1Id,
                        principalTable: "GolfMembers",
                        principalColumn: "MemberID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TeeTimes_GolfMembers_Player2Id",
                        column: x => x.Player2Id,
                        principalTable: "GolfMembers",
                        principalColumn: "MemberID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TeeTimes_GolfMembers_Player3Id",
                        column: x => x.Player3Id,
                        principalTable: "GolfMembers",
                        principalColumn: "MemberID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TeeTimes_GolfMembers_Player4Id",
                        column: x => x.Player4Id,
                        principalTable: "GolfMembers",
                        principalColumn: "MemberID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_TeeTimes_Player1Id",
                table: "TeeTimes",
                column: "Player1Id");

            migrationBuilder.CreateIndex(
                name: "IX_TeeTimes_Player2Id",
                table: "TeeTimes",
                column: "Player2Id");

            migrationBuilder.CreateIndex(
                name: "IX_TeeTimes_Player3Id",
                table: "TeeTimes",
                column: "Player3Id");

            migrationBuilder.CreateIndex(
                name: "IX_TeeTimes_Player4Id",
                table: "TeeTimes",
                column: "Player4Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TeeTimes");

            migrationBuilder.DropTable(
                name: "GolfMembers");
        }
    }
}
