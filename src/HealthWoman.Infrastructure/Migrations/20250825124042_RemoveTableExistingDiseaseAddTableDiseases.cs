using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HealthWoman.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class RemoveTableExistingDiseaseAddTableDiseases : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ExistingDisease");

            migrationBuilder.AddColumn<bool>(
                name: "ContainsExistingDiseases",
                table: "woman",
                type: "tinyint(1)",
                nullable: false,
                defaultValue: false);

            migrationBuilder.CreateTable(
                name: "diseases",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    DiseaseName = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    WomanId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_diseases", x => x.Id);
                    table.ForeignKey(
                        name: "FK_diseases_woman_WomanId",
                        column: x => x.WomanId,
                        principalTable: "woman",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateIndex(
                name: "IX_diseases_WomanId",
                table: "diseases",
                column: "WomanId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "diseases");

            migrationBuilder.DropColumn(
                name: "ContainsExistingDiseases",
                table: "woman");

            migrationBuilder.CreateTable(
                name: "ExistingDisease",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    WomanId = table.Column<int>(type: "int", nullable: false),
                    ContainsExistingDiseases = table.Column<bool>(type: "tinyint(1)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ExistingDisease", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ExistingDisease_woman_WomanId",
                        column: x => x.WomanId,
                        principalTable: "woman",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateIndex(
                name: "IX_ExistingDisease_WomanId",
                table: "ExistingDisease",
                column: "WomanId",
                unique: true);
        }
    }
}
