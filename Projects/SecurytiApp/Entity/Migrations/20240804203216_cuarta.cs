using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Entity.Migrations
{
    /// <inheritdoc />
    public partial class cuarta : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "modulo_id",
                table: "vistas");

            migrationBuilder.RenameColumn(
                name: "state",
                table: "vistas",
                newName: "estado");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "estado",
                table: "vistas",
                newName: "state");

            migrationBuilder.AddColumn<int>(
                name: "modulo_id",
                table: "vistas",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
