using Microsoft.EntityFrameworkCore.Migrations;

namespace AnyaTravel.DAL.Migrations
{
    public partial class RemovePassportCol : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Passport",
                table: "AspNetUsers");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Passport",
                table: "AspNetUsers",
                nullable: false,
                defaultValue: "");
        }
    }
}
