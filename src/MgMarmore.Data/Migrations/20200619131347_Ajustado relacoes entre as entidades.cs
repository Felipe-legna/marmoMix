using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace MgMarmore.Data.Migrations
{
    public partial class Ajustadorelacoesentreasentidades : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Itens_Materiais_MaterialId",
                table: "Itens");

            migrationBuilder.DropIndex(
                name: "IX_Itens_MaterialId",
                table: "Itens");

            migrationBuilder.DropColumn(
                name: "MaterialId",
                table: "Itens");

            migrationBuilder.AddColumn<Guid>(
                name: "MaterialId",
                table: "Pecas",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateIndex(
                name: "IX_Pecas_MaterialId",
                table: "Pecas",
                column: "MaterialId");

            migrationBuilder.AddForeignKey(
                name: "FK_Pecas_Materiais_MaterialId",
                table: "Pecas",
                column: "MaterialId",
                principalTable: "Materiais",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Pecas_Materiais_MaterialId",
                table: "Pecas");

            migrationBuilder.DropIndex(
                name: "IX_Pecas_MaterialId",
                table: "Pecas");

            migrationBuilder.DropColumn(
                name: "MaterialId",
                table: "Pecas");

            migrationBuilder.AddColumn<Guid>(
                name: "MaterialId",
                table: "Itens",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateIndex(
                name: "IX_Itens_MaterialId",
                table: "Itens",
                column: "MaterialId");

            migrationBuilder.AddForeignKey(
                name: "FK_Itens_Materiais_MaterialId",
                table: "Itens",
                column: "MaterialId",
                principalTable: "Materiais",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
