using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Persistence.Migrations
{
    /// <inheritdoc />
    public partial class constraint : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_CompanyAdresses",
                table: "CompanyAdresses");

            migrationBuilder.DropIndex(
                name: "IX_CompanyAdresses_CompanyUid",
                table: "CompanyAdresses");

            migrationBuilder.DropColumn(
                name: "Uid",
                table: "CompanyAdresses");

            migrationBuilder.AddPrimaryKey(
                name: "PK_CompanyAdresses",
                table: "CompanyAdresses",
                column: "CompanyUid");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_CompanyAdresses",
                table: "CompanyAdresses");

            migrationBuilder.AddColumn<int>(
                name: "Uid",
                table: "CompanyAdresses",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0)
                .Annotation("Sqlite:Autoincrement", true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_CompanyAdresses",
                table: "CompanyAdresses",
                column: "Uid");

            migrationBuilder.CreateIndex(
                name: "IX_CompanyAdresses_CompanyUid",
                table: "CompanyAdresses",
                column: "CompanyUid",
                unique: true);
        }
    }
}
