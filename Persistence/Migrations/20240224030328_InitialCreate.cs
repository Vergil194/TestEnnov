using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Persistence.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Companys",
                columns: table => new
                {
                    Uid = table.Column<string>(type: "TEXT", nullable: false),
                    Name = table.Column<string>(type: "TEXT", nullable: false),
                    LegaSeat = table.Column<string>(type: "TEXT", nullable: true),
                    ModificationDate = table.Column<DateTime>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Companys", x => x.Uid);
                });

            migrationBuilder.CreateTable(
                name: "CompanyAdresses",
                columns: table => new
                {
                    CompanyUid = table.Column<string>(type: "TEXT", nullable: false),
                    Adress = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CompanyAdresses", x => new { x.CompanyUid, x.Adress });
                    table.ForeignKey(
                        name: "FK_CompanyAdresses_Companys_CompanyUid",
                        column: x => x.CompanyUid,
                        principalTable: "Companys",
                        principalColumn: "Uid",
                        onDelete: ReferentialAction.Cascade);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CompanyAdresses");

            migrationBuilder.DropTable(
                name: "Companys");
        }
    }
}
