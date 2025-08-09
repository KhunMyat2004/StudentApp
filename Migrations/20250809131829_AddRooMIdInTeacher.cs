using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace StudentApp.Migrations
{
    /// <inheritdoc />
    public partial class AddRooMIdInTeacher : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "RoomId",
                table: "Teachers",
                type: "integer",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "RoomId",
                table: "Teachers");
        }
    }
}
