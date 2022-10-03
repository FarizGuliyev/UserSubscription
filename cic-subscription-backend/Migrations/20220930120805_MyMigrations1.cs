using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace cic_subscription_backend.Migrations
{
    public partial class MyMigrations1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Address",
                table: "User");

            migrationBuilder.DropColumn(
                name: "AddressDescription",
                table: "User");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Address",
                table: "User",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "AddressDescription",
                table: "User",
                type: "text",
                nullable: false,
                defaultValue: "");
        }
    }
}
