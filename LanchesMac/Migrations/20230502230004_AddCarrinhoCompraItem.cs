using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LanchesMac.Migrations
{
    /// <inheritdoc />
    public partial class AddCarrinhoCompraItem : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CarrinhoCompraItens",
                columns: table => new
                {
                    CarrinhoCompraItemId = table.Column<Guid>(type: "uuid", nullable: false, defaultValueSql: "uuid_generate_v4 ()"),
                    LancheId = table.Column<Guid>(type: "uuid", nullable: true),
                    Quantidade = table.Column<int>(type: "integer", nullable: false),
                    CarrinhoCompraId = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CarrinhoCompraItens", x => x.CarrinhoCompraItemId);
                    table.ForeignKey(
                        name: "FK_CarrinhoCompraItens_Lanches_LancheId",
                        column: x => x.LancheId,
                        principalTable: "Lanches",
                        principalColumn: "LancheId");
                });

            migrationBuilder.CreateIndex(
                name: "IX_CarrinhoCompraItens_LancheId",
                table: "CarrinhoCompraItens",
                column: "LancheId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CarrinhoCompraItens");
        }
    }
}
