using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Socialite.Infrastructure.Migrations.ApplicationDb
{
    /// <inheritdoc />
    public partial class visibilty : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Visibility",
                table: "Post",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Visibility",
                table: "Post");
        }
    }
}
