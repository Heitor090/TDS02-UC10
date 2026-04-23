using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ControleEstoque.API.Migrations
{
    /// <inheritdoc />
    public partial class ContaRceberCliete : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ClienteId",
                table: "ContasReceber",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_ContasReceber_ClienteId",
                table: "ContasReceber",
                column: "ClienteId");

            migrationBuilder.AddForeignKey(
                name: "FK_ContasReceber_Usuarios_ClienteId",
                table: "ContasReceber",
                column: "ClienteId",
                principalTable: "Usuarios",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ContasReceber_Usuarios_ClienteId",
                table: "ContasReceber");

            migrationBuilder.DropIndex(
                name: "IX_ContasReceber_ClienteId",
                table: "ContasReceber");

            migrationBuilder.DropColumn(
                name: "ClienteId",
                table: "ContasReceber");
        }
    }
}
