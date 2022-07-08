using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RepairItBack.Data.Migrations
{
    public partial class CommandeMigrationCorrection : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CleintId",
                table: "Commandes");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CleintId",
                table: "Commandes",
                type: "integer",
                nullable: false,
                defaultValue: 0);
        }
    }
}
