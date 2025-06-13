using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RotasViagem.Infra.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "rota",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Origem = table.Column<string>(type: "TEXT", maxLength: 3, nullable: false),
                    Conexao = table.Column<string>(type: "TEXT", nullable: false),
                    Destino = table.Column<string>(type: "TEXT", maxLength: 3, nullable: false),
                    Valor = table.Column<decimal>(type: "decimal(6,2)", nullable: false),
                    RotaId = table.Column<int>(type: "INTEGER", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_rota", x => x.Id);
                    table.ForeignKey(
                        name: "FK_rota_rota_RotaId",
                        column: x => x.RotaId,
                        principalTable: "rota",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "trecho",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Origem = table.Column<string>(type: "TEXT", maxLength: 3, nullable: false),
                    Destino = table.Column<string>(type: "TEXT", maxLength: 3, nullable: false),
                    Valor = table.Column<decimal>(type: "decimal(6,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_trecho", x => x.Id);
                    table.UniqueConstraint("AK_trecho_Origem_Destino", x => new { x.Origem, x.Destino });
                });

            migrationBuilder.CreateIndex(
                name: "IX_rota_RotaId",
                table: "rota",
                column: "RotaId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "rota");

            migrationBuilder.DropTable(
                name: "trecho");
        }
    }
}
