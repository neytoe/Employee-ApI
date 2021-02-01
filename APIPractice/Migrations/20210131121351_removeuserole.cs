using Microsoft.EntityFrameworkCore.Migrations;

namespace APIPractice.Migrations
{
    public partial class removeuserole : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Userrole",
                table: "Employees");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Userrole",
                table: "Employees",
                type: "TEXT",
                nullable: true);
        }
    }
}
