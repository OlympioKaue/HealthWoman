using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HealthWomen.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class NovoTesteMigrations : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_diseases_woman_WomanId",
                table: "diseases");

            migrationBuilder.DropPrimaryKey(
                name: "PK_woman",
                table: "woman");

            migrationBuilder.RenameTable(
                name: "woman",
                newName: "women");

            migrationBuilder.AddPrimaryKey(
                name: "PK_women",
                table: "women",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_diseases_women_WomanId",
                table: "diseases",
                column: "WomanId",
                principalTable: "women",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_diseases_women_WomanId",
                table: "diseases");

            migrationBuilder.DropPrimaryKey(
                name: "PK_women",
                table: "women");

            migrationBuilder.RenameTable(
                name: "women",
                newName: "woman");

            migrationBuilder.AddPrimaryKey(
                name: "PK_woman",
                table: "woman",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_diseases_woman_WomanId",
                table: "diseases",
                column: "WomanId",
                principalTable: "woman",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
