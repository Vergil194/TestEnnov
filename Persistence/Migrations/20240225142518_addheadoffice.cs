using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Persistence.Migrations
{
    /// <inheritdoc />
    public partial class addheadoffice : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "ModificationDate",
                table: "Companys",
                newName: "SogcDate");

            migrationBuilder.AddColumn<string>(
                name: "HeadOffice",
                table: "Companys",
                type: "TEXT",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "HeadOffice",
                table: "Companys");

            migrationBuilder.RenameColumn(
                name: "SogcDate",
                table: "Companys",
                newName: "ModificationDate");
        }
    }
}
