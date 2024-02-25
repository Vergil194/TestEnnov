using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Persistence.Migrations
{
    /// <inheritdoc />
    public partial class fixeTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "LegaSeat",
                table: "Companys",
                newName: "LegalSeat");

            migrationBuilder.CreateIndex(
                name: "IX_CompanyAdresses_CompanyUid",
                table: "CompanyAdresses",
                column: "CompanyUid",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_CompanyAdresses_CompanyUid",
                table: "CompanyAdresses");

            migrationBuilder.RenameColumn(
                name: "LegalSeat",
                table: "Companys",
                newName: "LegaSeat");
        }
    }
}
