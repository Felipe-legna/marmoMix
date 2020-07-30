using Microsoft.EntityFrameworkCore.Migrations;

namespace MgMarmore.Data.Migrations
{
    public partial class habilitandonullemcamposdositensprodutoeservicos : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<decimal>(
                name: "Tampao",
                table: "Itens",
                type: "DECIMAL(10,3)",
                nullable: true,
                oldClrType: typeof(decimal),
                oldType: "DECIMAL(10,3)");

            migrationBuilder.AlterColumn<decimal>(
                name: "Saia",
                table: "Itens",
                type: "DECIMAL(10,3)",
                nullable: true,
                oldClrType: typeof(decimal),
                oldType: "DECIMAL(10,3)");

            migrationBuilder.AlterColumn<decimal>(
                name: "RodapeTotal",
                table: "Itens",
                type: "DECIMAL(10,3)",
                nullable: true,
                oldClrType: typeof(decimal),
                oldType: "DECIMAL(10,3)");

            migrationBuilder.AlterColumn<decimal>(
                name: "RodapeComprimento",
                table: "Itens",
                type: "DECIMAL(10,3)",
                nullable: true,
                oldClrType: typeof(decimal),
                oldType: "DECIMAL(10,3)");

            migrationBuilder.AlterColumn<decimal>(
                name: "Rodape",
                table: "Itens",
                type: "DECIMAL(10,3)",
                nullable: true,
                oldClrType: typeof(decimal),
                oldType: "DECIMAL(10,3)");

            migrationBuilder.AlterColumn<decimal>(
                name: "Profundidade",
                table: "Itens",
                type: "DECIMAL(10,3)",
                nullable: true,
                oldClrType: typeof(decimal),
                oldType: "DECIMAL(10,3)");

            migrationBuilder.AlterColumn<decimal>(
                name: "Frontao",
                table: "Itens",
                type: "DECIMAL(10,3)",
                nullable: true,
                oldClrType: typeof(decimal),
                oldType: "DECIMAL(10,3)");

            migrationBuilder.AlterColumn<decimal>(
                name: "Borda",
                table: "Itens",
                type: "DECIMAL(10,3)",
                nullable: true,
                oldClrType: typeof(decimal),
                oldType: "DECIMAL(10,3)");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<decimal>(
                name: "Tampao",
                table: "Itens",
                type: "DECIMAL(10,3)",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "DECIMAL(10,3)",
                oldNullable: true);

            migrationBuilder.AlterColumn<decimal>(
                name: "Saia",
                table: "Itens",
                type: "DECIMAL(10,3)",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "DECIMAL(10,3)",
                oldNullable: true);

            migrationBuilder.AlterColumn<decimal>(
                name: "RodapeTotal",
                table: "Itens",
                type: "DECIMAL(10,3)",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "DECIMAL(10,3)",
                oldNullable: true);

            migrationBuilder.AlterColumn<decimal>(
                name: "RodapeComprimento",
                table: "Itens",
                type: "DECIMAL(10,3)",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "DECIMAL(10,3)",
                oldNullable: true);

            migrationBuilder.AlterColumn<decimal>(
                name: "Rodape",
                table: "Itens",
                type: "DECIMAL(10,3)",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "DECIMAL(10,3)",
                oldNullable: true);

            migrationBuilder.AlterColumn<decimal>(
                name: "Profundidade",
                table: "Itens",
                type: "DECIMAL(10,3)",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "DECIMAL(10,3)",
                oldNullable: true);

            migrationBuilder.AlterColumn<decimal>(
                name: "Frontao",
                table: "Itens",
                type: "DECIMAL(10,3)",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "DECIMAL(10,3)",
                oldNullable: true);

            migrationBuilder.AlterColumn<decimal>(
                name: "Borda",
                table: "Itens",
                type: "DECIMAL(10,3)",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "DECIMAL(10,3)",
                oldNullable: true);
        }
    }
}
