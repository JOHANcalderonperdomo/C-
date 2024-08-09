using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Entity.Migrations
{
    /// <inheritdoc />
    public partial class inicial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "modulo",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    nombre = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    descripcion = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    birthday = table.Column<DateTime>(type: "datetime2", nullable: false),
                    createdat = table.Column<DateTime>(name: "created_at", type: "datetime2", nullable: false),
                    createdby = table.Column<DateTime>(name: "created_by", type: "datetime2", nullable: false),
                    updatedat = table.Column<DateTime>(name: "updated_at", type: "datetime2", nullable: false),
                    updatedby = table.Column<DateTime>(name: "updated_by", type: "datetime2", nullable: false),
                    deletedat = table.Column<DateTime>(name: "deleted_at", type: "datetime2", nullable: false),
                    deletedby = table.Column<DateTime>(name: "deleted_by", type: "datetime2", nullable: false),
                    state = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_modulo", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "personas",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    nombre = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    apellido = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    correo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    fechadenacimiento = table.Column<DateTime>(name: "fecha_de_nacimiento", type: "datetime2", nullable: false),
                    genero = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    direccion = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    tipodedocumento = table.Column<string>(name: "tipo_de_documento", type: "nvarchar(max)", nullable: false),
                    documento = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    numero = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    birthday = table.Column<DateTime>(type: "datetime2", nullable: false),
                    createdat = table.Column<DateTime>(name: "created_at", type: "datetime2", nullable: false),
                    createdby = table.Column<DateTime>(name: "created_by", type: "datetime2", nullable: false),
                    updatedat = table.Column<DateTime>(name: "updated_at", type: "datetime2", nullable: false),
                    updatedby = table.Column<DateTime>(name: "updated_by", type: "datetime2", nullable: false),
                    deletedat = table.Column<DateTime>(name: "deleted_at", type: "datetime2", nullable: false),
                    deletedby = table.Column<DateTime>(name: "deleted_by", type: "datetime2", nullable: false),
                    estado = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_personas", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "rol",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    nombre = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    descripcion = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    birthday = table.Column<DateTime>(type: "datetime2", nullable: false),
                    createdat = table.Column<DateTime>(name: "created_at", type: "datetime2", nullable: false),
                    createdby = table.Column<DateTime>(name: "created_by", type: "datetime2", nullable: false),
                    updatedat = table.Column<DateTime>(name: "updated_at", type: "datetime2", nullable: false),
                    updatedby = table.Column<DateTime>(name: "updated_by", type: "datetime2", nullable: false),
                    deletedat = table.Column<DateTime>(name: "deleted_at", type: "datetime2", nullable: false),
                    deletedby = table.Column<DateTime>(name: "deleted_by", type: "datetime2", nullable: false),
                    estado = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_rol", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "vistas",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    nombre = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    descripcion = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ruta = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    moduloid = table.Column<int>(name: "modulo_id", type: "int", nullable: false),
                    moduloId = table.Column<int>(type: "int", nullable: false),
                    createdat = table.Column<DateTime>(name: "created_at", type: "datetime2", nullable: false),
                    createdby = table.Column<DateTime>(name: "created_by", type: "datetime2", nullable: false),
                    updatedat = table.Column<DateTime>(name: "updated_at", type: "datetime2", nullable: false),
                    updatedby = table.Column<DateTime>(name: "updated_by", type: "datetime2", nullable: false),
                    deletedat = table.Column<DateTime>(name: "deleted_at", type: "datetime2", nullable: false),
                    deletedby = table.Column<DateTime>(name: "deleted_by", type: "datetime2", nullable: false),
                    state = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_vistas", x => x.Id);
                    table.ForeignKey(
                        name: "FK_vistas_modulo_moduloId",
                        column: x => x.moduloId,
                        principalTable: "modulo",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "usuario",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    nombredeusuario = table.Column<string>(name: "nombre_de_usuario", type: "nvarchar(max)", nullable: false),
                    contraseña = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    personaid = table.Column<int>(name: "persona_id", type: "int", nullable: false),
                    personaId = table.Column<int>(type: "int", nullable: false),
                    createdat = table.Column<DateTime>(name: "created_at", type: "datetime2", nullable: false),
                    createdby = table.Column<DateTime>(name: "created_by", type: "datetime2", nullable: false),
                    updatedat = table.Column<DateTime>(name: "updated_at", type: "datetime2", nullable: false),
                    updatedby = table.Column<DateTime>(name: "updated_by", type: "datetime2", nullable: false),
                    deletedat = table.Column<DateTime>(name: "deleted_at", type: "datetime2", nullable: false),
                    deletedby = table.Column<DateTime>(name: "deleted_by", type: "datetime2", nullable: false),
                    estado = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_usuario", x => x.Id);
                    table.ForeignKey(
                        name: "FK_usuario_personas_personaId",
                        column: x => x.personaId,
                        principalTable: "personas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "rol_vista",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    rolid = table.Column<int>(name: "rol_id", type: "int", nullable: false),
                    vistaid = table.Column<int>(name: "vista_id", type: "int", nullable: false),
                    rolId = table.Column<int>(type: "int", nullable: false),
                    vistaId = table.Column<int>(type: "int", nullable: false),
                    birthday = table.Column<DateTime>(type: "datetime2", nullable: false),
                    createdat = table.Column<DateTime>(name: "created_at", type: "datetime2", nullable: false),
                    createdby = table.Column<DateTime>(name: "created_by", type: "datetime2", nullable: false),
                    updatedat = table.Column<DateTime>(name: "updated_at", type: "datetime2", nullable: false),
                    updatedby = table.Column<DateTime>(name: "updated_by", type: "datetime2", nullable: false),
                    deletedat = table.Column<DateTime>(name: "deleted_at", type: "datetime2", nullable: false),
                    deletedby = table.Column<DateTime>(name: "deleted_by", type: "datetime2", nullable: false),
                    state = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_rol_vista", x => x.Id);
                    table.ForeignKey(
                        name: "FK_rol_vista_rol_rolId",
                        column: x => x.rolId,
                        principalTable: "rol",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_rol_vista_vistas_vistaId",
                        column: x => x.vistaId,
                        principalTable: "vistas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "usuario_rol",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    usuarioid = table.Column<int>(name: "usuario_id", type: "int", nullable: false),
                    rolid = table.Column<int>(name: "rol_id", type: "int", nullable: false),
                    usuarioId = table.Column<int>(type: "int", nullable: false),
                    rolId = table.Column<int>(type: "int", nullable: false),
                    birthday = table.Column<DateTime>(type: "datetime2", nullable: false),
                    createdat = table.Column<DateTime>(name: "created_at", type: "datetime2", nullable: false),
                    createdby = table.Column<DateTime>(name: "created_by", type: "datetime2", nullable: false),
                    updatedat = table.Column<DateTime>(name: "updated_at", type: "datetime2", nullable: false),
                    updatedby = table.Column<DateTime>(name: "updated_by", type: "datetime2", nullable: false),
                    deletedat = table.Column<DateTime>(name: "deleted_at", type: "datetime2", nullable: false),
                    deletedby = table.Column<DateTime>(name: "deleted_by", type: "datetime2", nullable: false),
                    state = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_usuario_rol", x => x.Id);
                    table.ForeignKey(
                        name: "FK_usuario_rol_rol_rolId",
                        column: x => x.rolId,
                        principalTable: "rol",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_usuario_rol_usuario_usuarioId",
                        column: x => x.usuarioId,
                        principalTable: "usuario",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_rol_vista_rolId",
                table: "rol_vista",
                column: "rolId");

            migrationBuilder.CreateIndex(
                name: "IX_rol_vista_vistaId",
                table: "rol_vista",
                column: "vistaId");

            migrationBuilder.CreateIndex(
                name: "IX_usuario_personaId",
                table: "usuario",
                column: "personaId");

            migrationBuilder.CreateIndex(
                name: "IX_usuario_rol_rolId",
                table: "usuario_rol",
                column: "rolId");

            migrationBuilder.CreateIndex(
                name: "IX_usuario_rol_usuarioId",
                table: "usuario_rol",
                column: "usuarioId");

            migrationBuilder.CreateIndex(
                name: "IX_vistas_moduloId",
                table: "vistas",
                column: "moduloId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "rol_vista");

            migrationBuilder.DropTable(
                name: "usuario_rol");

            migrationBuilder.DropTable(
                name: "vistas");

            migrationBuilder.DropTable(
                name: "rol");

            migrationBuilder.DropTable(
                name: "usuario");

            migrationBuilder.DropTable(
                name: "modulo");

            migrationBuilder.DropTable(
                name: "personas");
        }
    }
}
