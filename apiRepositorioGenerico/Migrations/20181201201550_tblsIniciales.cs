using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace apiRepositorioGenerico.Migrations
{
    public partial class tblsIniciales : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "TipoRepositorio",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    fechaIng = table.Column<DateTime>(nullable: false),
                    descripcion = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TipoRepositorio", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "Repositorio",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    fechaIng = table.Column<DateTime>(nullable: false),
                    usuario = table.Column<int>(nullable: false),
                    tipoID = table.Column<int>(nullable: false),
                    descripcion = table.Column<string>(nullable: true),
                    TipoRepositorioid = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Repositorio", x => x.id);
                    table.ForeignKey(
                        name: "FK_Repositorio_TipoRepositorio_TipoRepositorioid",
                        column: x => x.TipoRepositorioid,
                        principalTable: "TipoRepositorio",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "TelefonoRepositorio",
                columns: table => new
                {
                    idRepositorio = table.Column<int>(nullable: false),
                    telefono = table.Column<string>(maxLength: 20, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TelefonoRepositorio", x => x.idRepositorio);
                    table.ForeignKey(
                        name: "FK_TelefonoRepositorio_Repositorio_idRepositorio",
                        column: x => x.idRepositorio,
                        principalTable: "Repositorio",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Repositorio_TipoRepositorioid",
                table: "Repositorio",
                column: "TipoRepositorioid");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TelefonoRepositorio");

            migrationBuilder.DropTable(
                name: "Repositorio");

            migrationBuilder.DropTable(
                name: "TipoRepositorio");
        }
    }
}
