using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HealthWoman.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class DeleteTableRisk : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "riskFactors");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "riskFactors",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    WomanId = table.Column<int>(type: "int", nullable: false),
                    DescriptionOfRisk = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_riskFactors", x => x.Id);
                    table.ForeignKey(
                        name: "FK_riskFactors_woman_WomanId",
                        column: x => x.WomanId,
                        principalTable: "woman",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateIndex(
                name: "IX_riskFactors_WomanId",
                table: "riskFactors",
                column: "WomanId");
        }
    }
}
