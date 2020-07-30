using Microsoft.EntityFrameworkCore.Migrations;

namespace MgMarmore.Data.Migrations
{
    public partial class adicionadoimagememmaterial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Imagem",
                table: "Materiais",
                type: "VARCHAR(100)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Imagem",
                table: "Materiais");
        }
    }
}
