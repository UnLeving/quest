using Microsoft.EntityFrameworkCore.Migrations;

namespace LenaQuestQuest.Data.Migrations
{
    public partial class identityviewsupd : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameIndex(
                name: "RoLenaQuestmeIndex",
                table: "AspNetRoles",
                newName: "RoleNameIndex");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles",
                newName: "RoLenaQuestmeIndex");
        }
    }
}
