using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Entity.Migrations
{
    /// <inheritdoc />
    public partial class septima : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_usuario_rol_Rol_rolId",
                table: "usuario_rol");

            migrationBuilder.DropForeignKey(
                name: "FK_usuario_rol_usuario_usuarioId",
                table: "usuario_rol");

            migrationBuilder.DropIndex(
                name: "IX_usuario_rol_rolId",
                table: "usuario_rol");

            migrationBuilder.DropIndex(
                name: "IX_usuario_rol_usuarioId",
                table: "usuario_rol");

            migrationBuilder.DropColumn(
                name: "rolId",
                table: "usuario_rol");

            migrationBuilder.DropColumn(
                name: "usuarioId",
                table: "usuario_rol");

            migrationBuilder.AddColumn<int>(
                name: "Rol_VistaId",
                table: "Rol_Vista",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_usuario_rol_rol_id",
                table: "usuario_rol",
                column: "rol_id");

            migrationBuilder.CreateIndex(
                name: "IX_usuario_rol_usuario_id",
                table: "usuario_rol",
                column: "usuario_id");

            migrationBuilder.CreateIndex(
                name: "IX_Rol_Vista_Rol_VistaId",
                table: "Rol_Vista",
                column: "Rol_VistaId");

            migrationBuilder.AddForeignKey(
                name: "FK_Rol_Vista_Rol_Vista_Rol_VistaId",
                table: "Rol_Vista",
                column: "Rol_VistaId",
                principalTable: "Rol_Vista",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_usuario_rol_Rol_rol_id",
                table: "usuario_rol",
                column: "rol_id",
                principalTable: "Rol",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_usuario_rol_usuario_usuario_id",
                table: "usuario_rol",
                column: "usuario_id",
                principalTable: "usuario",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Rol_Vista_Rol_Vista_Rol_VistaId",
                table: "Rol_Vista");

            migrationBuilder.DropForeignKey(
                name: "FK_usuario_rol_Rol_rol_id",
                table: "usuario_rol");

            migrationBuilder.DropForeignKey(
                name: "FK_usuario_rol_usuario_usuario_id",
                table: "usuario_rol");

            migrationBuilder.DropIndex(
                name: "IX_usuario_rol_rol_id",
                table: "usuario_rol");

            migrationBuilder.DropIndex(
                name: "IX_usuario_rol_usuario_id",
                table: "usuario_rol");

            migrationBuilder.DropIndex(
                name: "IX_Rol_Vista_Rol_VistaId",
                table: "Rol_Vista");

            migrationBuilder.DropColumn(
                name: "Rol_VistaId",
                table: "Rol_Vista");

            migrationBuilder.AddColumn<int>(
                name: "rolId",
                table: "usuario_rol",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "usuarioId",
                table: "usuario_rol",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_usuario_rol_rolId",
                table: "usuario_rol",
                column: "rolId");

            migrationBuilder.CreateIndex(
                name: "IX_usuario_rol_usuarioId",
                table: "usuario_rol",
                column: "usuarioId");

            migrationBuilder.AddForeignKey(
                name: "FK_usuario_rol_Rol_rolId",
                table: "usuario_rol",
                column: "rolId",
                principalTable: "Rol",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_usuario_rol_usuario_usuarioId",
                table: "usuario_rol",
                column: "usuarioId",
                principalTable: "usuario",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
