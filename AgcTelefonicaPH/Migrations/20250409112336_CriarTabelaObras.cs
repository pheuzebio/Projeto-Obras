﻿using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AgcTelefonicaPH.Migrations
{
    /// <inheritdoc />
    public partial class CriarTabelaObras : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Obras",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Descricao = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    idCliente = table.Column<int>(type: "int", nullable: false),
                    DatIni = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DatFim = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Obras", x => x.id);
                    table.ForeignKey(
                        name: "FK_Obras_Contactos_idCliente",
                        column: x => x.idCliente,
                        principalTable: "Contactos",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Obras_idCliente",
                table: "Obras",
                column: "idCliente");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Obras");
        }
    }
}
