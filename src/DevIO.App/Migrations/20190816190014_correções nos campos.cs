using Microsoft.EntityFrameworkCore.Migrations;

namespace DevIO.App.Migrations
{
    public partial class correçõesnoscampos : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Produtos_Fornecedor_FornecedorId",
                table: "Produtos");

            migrationBuilder.RenameColumn(
                name: "FornecedorId",
                table: "Produtos",
                newName: "FornecedorID");

            migrationBuilder.RenameIndex(
                name: "IX_Produtos_FornecedorId",
                table: "Produtos",
                newName: "IX_Produtos_FornecedorID");

            migrationBuilder.AddForeignKey(
                name: "FK_Produtos_Fornecedor_FornecedorID",
                table: "Produtos",
                column: "FornecedorID",
                principalTable: "Fornecedor",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Produtos_Fornecedor_FornecedorID",
                table: "Produtos");

            migrationBuilder.RenameColumn(
                name: "FornecedorID",
                table: "Produtos",
                newName: "FornecedorId");

            migrationBuilder.RenameIndex(
                name: "IX_Produtos_FornecedorID",
                table: "Produtos",
                newName: "IX_Produtos_FornecedorId");

            migrationBuilder.AddForeignKey(
                name: "FK_Produtos_Fornecedor_FornecedorId",
                table: "Produtos",
                column: "FornecedorId",
                principalTable: "Fornecedor",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
