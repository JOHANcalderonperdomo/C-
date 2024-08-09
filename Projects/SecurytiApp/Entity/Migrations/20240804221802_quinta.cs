using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Entity.Migrations
{
    /// <inheritdoc />
    public partial class quinta : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_rol_vista_rol_rolId",
                table: "rol_vista");

            migrationBuilder.DropForeignKey(
                name: "FK_rol_vista_vistas_vistaId",
                table: "rol_vista");

            migrationBuilder.DropForeignKey(
                name: "FK_usuario_rol_rol_rolId",
                table: "usuario_rol");

            migrationBuilder.DropForeignKey(
                name: "FK_vistas_modulo_moduloId",
                table: "vistas");

            migrationBuilder.DropPrimaryKey(
                name: "PK_rol_vista",
                table: "rol_vista");

            migrationBuilder.DropPrimaryKey(
                name: "PK_rol",
                table: "rol");

            migrationBuilder.DropPrimaryKey(
                name: "PK_vistas",
                table: "vistas");

            migrationBuilder.DropColumn(
                name: "rol_id",
                table: "rol_vista");

            migrationBuilder.DropColumn(
                name: "vista_id",
                table: "rol_vista");

            migrationBuilder.RenameTable(
                name: "rol_vista",
                newName: "Rol_Vista");

            migrationBuilder.RenameTable(
                name: "rol",
                newName: "Rol");

            migrationBuilder.RenameTable(
                name: "vistas",
                newName: "Vista");

            migrationBuilder.RenameIndex(
                name: "IX_rol_vista_vistaId",
                table: "Rol_Vista",
                newName: "IX_Rol_Vista_vistaId");

            migrationBuilder.RenameIndex(
                name: "IX_rol_vista_rolId",
                table: "Rol_Vista",
                newName: "IX_Rol_Vista_rolId");

            migrationBuilder.RenameIndex(
                name: "IX_vistas_moduloId",
                table: "Vista",
                newName: "IX_Vista_moduloId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Rol_Vista",
                table: "Rol_Vista",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Rol",
                table: "Rol",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Vista",
                table: "Vista",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Rol_Vista_Rol_rolId",
                table: "Rol_Vista",
                column: "rolId",
                principalTable: "Rol",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Rol_Vista_Vista_vistaId",
                table: "Rol_Vista",
                column: "vistaId",
                principalTable: "Vista",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_usuario_rol_Rol_rolId",
                table: "usuario_rol",
                column: "rolId",
                principalTable: "Rol",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Vista_modulo_moduloId",
                table: "Vista",
                column: "moduloId",
                principalTable: "modulo",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Rol_Vista_Rol_rolId",
                table: "Rol_Vista");

            migrationBuilder.DropForeignKey(
                name: "FK_Rol_Vista_Vista_vistaId",
                table: "Rol_Vista");

            migrationBuilder.DropForeignKey(
                name: "FK_usuario_rol_Rol_rolId",
                table: "usuario_rol");

            migrationBuilder.DropForeignKey(
                name: "FK_Vista_modulo_moduloId",
                table: "Vista");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Rol_Vista",
                table: "Rol_Vista");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Rol",
                table: "Rol");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Vista",
                table: "Vista");

            migrationBuilder.RenameTable(
                name: "Rol_Vista",
                newName: "rol_vista");

            migrationBuilder.RenameTable(
                name: "Rol",
                newName: "rol");

            migrationBuilder.RenameTable(
                name: "Vista",
                newName: "vistas");

            migrationBuilder.RenameIndex(
                name: "IX_Rol_Vista_vistaId",
                table: "rol_vista",
                newName: "IX_rol_vista_vistaId");

            migrationBuilder.RenameIndex(
                name: "IX_Rol_Vista_rolId",
                table: "rol_vista",
                newName: "IX_rol_vista_rolId");

            migrationBuilder.RenameIndex(
                name: "IX_Vista_moduloId",
                table: "vistas",
                newName: "IX_vistas_moduloId");

            migrationBuilder.AddColumn<int>(
                name: "rol_id",
                table: "rol_vista",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "vista_id",
                table: "rol_vista",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddPrimaryKey(
                name: "PK_rol_vista",
                table: "rol_vista",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_rol",
                table: "rol",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_vistas",
                table: "vistas",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_rol_vista_rol_rolId",
                table: "rol_vista",
                column: "rolId",
                principalTable: "rol",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_rol_vista_vistas_vistaId",
                table: "rol_vista",
                column: "vistaId",
                principalTable: "vistas",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_usuario_rol_rol_rolId",
                table: "usuario_rol",
                column: "rolId",
                principalTable: "rol",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_vistas_modulo_moduloId",
                table: "vistas",
                column: "moduloId",
                principalTable: "modulo",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
