using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AgcTelefonicaPH.Migrations
{
    /// <inheritdoc />
    public partial class AdicionarImagemContato : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<byte[]>(
                name: "Imagem",
                table: "Contactos",
                type: "varbinary(max)",
                nullable: true,
                defaultValue: new byte[0]);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Imagem",
                table: "Contactos");
        }
    }
}
