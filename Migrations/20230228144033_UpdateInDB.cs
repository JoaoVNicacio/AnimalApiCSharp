using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AnimalApiCSharp.Migrations
{
    /// <inheritdoc />
    public partial class UpdateInDB : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "subspecies_name",
                table: "animals",
                type: "text",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "subspecies_name",
                table: "animals");
        }
    }
}
