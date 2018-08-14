using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace RestauranteDDD.Infra.Data.Migrations
{
    public partial class tes : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Restaurantes",
                columns: table => new
                {
                    RestauranteId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Nome = table.Column<string>(maxLength: 200, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Restaurantes", x => x.RestauranteId);
                });

            migrationBuilder.CreateTable(
                name: "Pratos",
                columns: table => new
                {
                    PratoId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Nome = table.Column<string>(maxLength: 200, nullable: false),
                    Preco = table.Column<decimal>(type: "money", nullable: false),
                    RestauranteId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pratos", x => x.PratoId);
                    table.ForeignKey(
                        name: "FK_Pratos_Restaurantes_RestauranteId",
                        column: x => x.RestauranteId,
                        principalTable: "Restaurantes",
                        principalColumn: "RestauranteId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Pratos_RestauranteId",
                table: "Pratos",
                column: "RestauranteId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Pratos");

            migrationBuilder.DropTable(
                name: "Restaurantes");
        }
    }
}
