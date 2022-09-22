using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace cic_subscription_backend.Migrations
{
    public partial class MyMigrations234 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Date",
                table: "Payment",
                newName: "PayDate");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "PayDate",
                table: "Payment",
                newName: "Date");
        }
    }
}
