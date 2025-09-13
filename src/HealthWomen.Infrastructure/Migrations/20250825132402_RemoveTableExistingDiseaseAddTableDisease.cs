using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HealthWoman.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class RemoveTableExistingDiseaseAddTableDisease : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "ContainsExistingDiseases",
                table: "woman",
                newName: "ContainsExistingDisease");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "ContainsExistingDisease",
                table: "woman",
                newName: "ContainsExistingDiseases");
        }
    }
}
