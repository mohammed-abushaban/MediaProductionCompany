using Microsoft.EntityFrameworkCore.Migrations;

namespace MediaProductionCompany.Data.Migrations
{
    public partial class user_updated : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "InsertUser",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "InsertUser",
                table: "AspNetUsers");
        }
    }
}
