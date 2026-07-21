using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace SiteWebTransactionnel.Migrations
{
    /// <inheritdoc />
    public partial class AjoutJeuxVidéos : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Produits",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Produits",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Produits",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.AddColumn<string>(
                name: "Discriminator",
                table: "Produits",
                type: "character varying(8)",
                maxLength: 8,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Développeur",
                table: "Produits",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string[]>(
                name: "Genres",
                table: "Produits",
                type: "text[]",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Éditeur",
                table: "Produits",
                type: "text",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Plateforme",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Nom = table.Column<string>(type: "text", nullable: false),
                    Manufacturier = table.Column<string>(type: "text", nullable: false),
                    JeuVidéoId = table.Column<int>(type: "integer", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Plateforme", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Plateforme_Produits_JeuVidéoId",
                        column: x => x.JeuVidéoId,
                        principalTable: "Produits",
                        principalColumn: "Id");
                });

            migrationBuilder.InsertData(
                table: "Produits",
                columns: new[] { "Id", "Description", "Discriminator", "Nom", "Prix" },
                values: new object[,]
                {
                    { 1, "description", "Produit", "nom", 10m },
                    { 2, "Ipsum", "Produit", "Lorem", 20m },
                    { 3, "Lorem", "Produit", "Ipsum", 30m }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Plateforme_JeuVidéoId",
                table: "Plateforme",
                column: "JeuVidéoId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Plateforme");

            migrationBuilder.DropColumn(
                name: "Discriminator",
                table: "Produits");

            migrationBuilder.DropColumn(
                name: "Développeur",
                table: "Produits");

            migrationBuilder.DropColumn(
                name: "Genres",
                table: "Produits");

            migrationBuilder.DropColumn(
                name: "Éditeur",
                table: "Produits");
        }
    }
}
