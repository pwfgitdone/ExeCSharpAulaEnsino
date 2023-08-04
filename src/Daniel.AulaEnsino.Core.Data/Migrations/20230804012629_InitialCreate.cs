using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Daniel.AulaEnsino.Core.Data.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "dbo");

            migrationBuilder.CreateTable(
                name: "cliente",
                schema: "dbo",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    documento = table.Column<string>(type: "varchar(14)", maxLength: 14, nullable: false),
                    tipo_pessoa = table.Column<string>(type: "varchar(1)", maxLength: 1, nullable: false),
                    nome = table.Column<string>(type: "varchar(255)", nullable: false),
                    dt_inclusao = table.Column<DateTime>(type: "datetime2", nullable: false),
                    dt_alteracao = table.Column<DateTime>(type: "datetime2", nullable: true),
                    dt_exclusao = table.Column<DateTime>(type: "datetime2", nullable: true),
                    status = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_cliente", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "endereco",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Logradouro = table.Column<string>(type: "varchar(200)", nullable: false),
                    Numero = table.Column<string>(type: "varchar(50)", nullable: false),
                    Complemento = table.Column<string>(type: "varchar(250)", nullable: false),
                    Cep = table.Column<string>(type: "varchar(8)", nullable: false),
                    Bairro = table.Column<string>(type: "varchar(100)", nullable: false),
                    Cidade = table.Column<string>(type: "varchar(100)", nullable: false),
                    Estado = table.Column<string>(type: "varchar(50)", nullable: false),
                    idCliente = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_endereco", x => x.id);
                    table.ForeignKey(
                        name: "FK_endereco_cliente_idCliente",
                        column: x => x.idCliente,
                        principalSchema: "dbo",
                        principalTable: "cliente",
                        principalColumn: "id");
                });

            migrationBuilder.CreateTable(
                name: "produto",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Descricao = table.Column<string>(type: "varchar(1000)", nullable: false),
                    Imagem = table.Column<string>(type: "varchar(100)", nullable: false),
                    valor = table.Column<decimal>(type: "decimal (10,2)", nullable: true),
                    idCliente = table.Column<int>(type: "int", nullable: true),
                    Nome = table.Column<string>(type: "varchar(200)", nullable: false),
                    dt_inclusao = table.Column<DateTime>(type: "datetime2", nullable: false),
                    dt_alteracao = table.Column<DateTime>(type: "datetime2", nullable: true),
                    dt_exclusao = table.Column<DateTime>(type: "datetime2", nullable: true),
                    status = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_produto", x => x.id);
                    table.ForeignKey(
                        name: "FK_produto_cliente_idCliente",
                        column: x => x.idCliente,
                        principalSchema: "dbo",
                        principalTable: "cliente",
                        principalColumn: "id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_endereco_idCliente",
                table: "endereco",
                column: "idCliente",
                unique: true,
                filter: "[idCliente] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_produto_idCliente",
                table: "produto",
                column: "idCliente");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "endereco");

            migrationBuilder.DropTable(
                name: "produto");

            migrationBuilder.DropTable(
                name: "cliente",
                schema: "dbo");
        }
    }
}
