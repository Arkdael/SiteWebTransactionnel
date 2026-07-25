using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SiteWebTransactionnel.Migrations
{
    /// <inheritdoc />
    public partial class AjoutTypeMediaImages : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "TypeMédia",
                table: "Images",
                type: "text",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "TypeMédia",
                table: "Images");
        }
    }
}
