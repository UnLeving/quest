using Microsoft.EntityFrameworkCore.Migrations;

namespace LenaQuest.Migrations
{
    public partial class fix2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "SureName",
                table: "Profiles",
                newName: "SecondName");

            migrationBuilder.RenameColumn(
                name: "Name",
                table: "Profiles",
                newName: "PhoneNumber");

            migrationBuilder.AddColumn<string>(
                name: "FirstName",
                table: "Profiles",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "FirstName",
                table: "Profiles");

            migrationBuilder.RenameColumn(
                name: "SecondName",
                table: "Profiles",
                newName: "SureName");

            migrationBuilder.RenameColumn(
                name: "PhoneNumber",
                table: "Profiles",
                newName: "Name");
        }
    }
}
