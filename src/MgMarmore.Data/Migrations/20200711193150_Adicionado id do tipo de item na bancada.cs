using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace MgMarmore.Data.Migrations
{
    public partial class Adicionadoiddotipodeitemnabancada : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<Guid>(
                name: "TipoItemId",
                table: "Bancadas",
                nullable: false,
                oldClrType: typeof(Guid),
                oldNullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<Guid>(
                name: "TipoItemId",
                table: "Bancadas",
                nullable: true,
                oldClrType: typeof(Guid));
        }
    }
}
