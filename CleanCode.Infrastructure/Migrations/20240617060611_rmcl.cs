using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CleanCode.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class rmcl : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "test",
                table: "data");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "test",
                table: "data",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
