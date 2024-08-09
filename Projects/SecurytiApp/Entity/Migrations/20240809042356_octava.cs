using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Entity.Migrations
{
    /// <inheritdoc />
    public partial class octava : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "continet",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    code = table.Column<int>(type: "int", nullable: false),
                    name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    createdat = table.Column<DateTime>(name: "created_at", type: "datetime2", nullable: false),
                    createdby = table.Column<DateTime>(name: "created_by", type: "datetime2", nullable: false),
                    updatedat = table.Column<DateTime>(name: "updated_at", type: "datetime2", nullable: true),
                    updatedby = table.Column<DateTime>(name: "updated_by", type: "datetime2", nullable: true),
                    deletedat = table.Column<DateTime>(name: "deleted_at", type: "datetime2", nullable: true),
                    deletedby = table.Column<DateTime>(name: "deleted_by", type: "datetime2", nullable: true),
                    estado = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_continet", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "country",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    code = table.Column<int>(type: "int", nullable: false),
                    name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Continetid = table.Column<int>(name: "Continet_id", type: "int", nullable: false),
                    createdat = table.Column<DateTime>(name: "created_at", type: "datetime2", nullable: false),
                    createdby = table.Column<DateTime>(name: "created_by", type: "datetime2", nullable: false),
                    updatedat = table.Column<DateTime>(name: "updated_at", type: "datetime2", nullable: true),
                    updatedby = table.Column<DateTime>(name: "updated_by", type: "datetime2", nullable: true),
                    deletedat = table.Column<DateTime>(name: "deleted_at", type: "datetime2", nullable: true),
                    deletedby = table.Column<DateTime>(name: "deleted_by", type: "datetime2", nullable: true),
                    estado = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_country", x => x.id);
                    table.ForeignKey(
                        name: "FK_country_continet_Continet_id",
                        column: x => x.Continetid,
                        principalTable: "continet",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "department",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    code = table.Column<int>(type: "int", nullable: false),
                    name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    countryId = table.Column<int>(type: "int", nullable: false),
                    createdat = table.Column<DateTime>(name: "created_at", type: "datetime2", nullable: false),
                    createdby = table.Column<DateTime>(name: "created_by", type: "datetime2", nullable: false),
                    updatedat = table.Column<DateTime>(name: "updated_at", type: "datetime2", nullable: true),
                    updatedby = table.Column<DateTime>(name: "updated_by", type: "datetime2", nullable: true),
                    deletedat = table.Column<DateTime>(name: "deleted_at", type: "datetime2", nullable: true),
                    deletedby = table.Column<DateTime>(name: "deleted_by", type: "datetime2", nullable: true),
                    estado = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_department", x => x.id);
                    table.ForeignKey(
                        name: "FK_department_country_countryId",
                        column: x => x.countryId,
                        principalTable: "country",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "city",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    code = table.Column<int>(type: "int", nullable: false),
                    name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    departmentId = table.Column<int>(type: "int", nullable: false),
                    createdat = table.Column<DateTime>(name: "created_at", type: "datetime2", nullable: false),
                    createdby = table.Column<DateTime>(name: "created_by", type: "datetime2", nullable: false),
                    updatedat = table.Column<DateTime>(name: "updated_at", type: "datetime2", nullable: true),
                    updatedby = table.Column<DateTime>(name: "updated_by", type: "datetime2", nullable: true),
                    deletedat = table.Column<DateTime>(name: "deleted_at", type: "datetime2", nullable: true),
                    deletedby = table.Column<DateTime>(name: "deleted_by", type: "datetime2", nullable: true),
                    estado = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_city", x => x.id);
                    table.ForeignKey(
                        name: "FK_city_department_departmentId",
                        column: x => x.departmentId,
                        principalTable: "department",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_city_departmentId",
                table: "city",
                column: "departmentId");

            migrationBuilder.CreateIndex(
                name: "IX_country_Continet_id",
                table: "country",
                column: "Continet_id");

            migrationBuilder.CreateIndex(
                name: "IX_department_countryId",
                table: "department",
                column: "countryId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "city");

            migrationBuilder.DropTable(
                name: "department");

            migrationBuilder.DropTable(
                name: "country");

            migrationBuilder.DropTable(
                name: "continet");
        }
    }
}
