using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HealthWoman.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AddTableDisiase : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ExistingDisease",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    ContainsExistingDiseases = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    WomanId = table.Column<int>(type: "int", nullable: false)
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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ExistingDisease");
        }
    }
}
