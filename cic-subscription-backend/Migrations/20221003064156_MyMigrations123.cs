using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace cic_subscription_backend.Migrations
{
    public partial class MyMigrations123 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Floor_Entrance_EntranceId",
                table: "Floor");

            migrationBuilder.DropForeignKey(
                name: "FK_User_Floor_FloorId",
                table: "User");

            migrationBuilder.DropForeignKey(
                name: "FK_User_Street_StreetId",
                table: "User");

            migrationBuilder.DropForeignKey(
                name: "FK_Village_District_DistrictId",
                table: "Village");

            migrationBuilder.DropTable(
                name: "District");

            migrationBuilder.DropTable(
                name: "Entrance");

            migrationBuilder.DropIndex(
                name: "IX_Village_DistrictId",
                table: "Village");

            migrationBuilder.DropColumn(
                name: "Address",
                table: "User");

            migrationBuilder.DropColumn(
                name: "Discriminator",
                table: "User");

            migrationBuilder.DropColumn(
                name: "Flat_Address",
                table: "User");

            migrationBuilder.RenameColumn(
                name: "EntranceId",
                table: "Floor",
                newName: "ApartmentId");

            migrationBuilder.RenameIndex(
                name: "IX_Floor_EntranceId",
                table: "Floor",
                newName: "IX_Floor_ApartmentId");

            migrationBuilder.AddColumn<long>(
                name: "fkCityId",
                table: "Village",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.AddColumn<long>(
                name: "ApartmentId",
                table: "User",
                type: "bigint",
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "CityId",
                table: "User",
                type: "bigint",
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "FlatId",
                table: "User",
                type: "bigint",
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "HouseAddressId",
                table: "User",
                type: "bigint",
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "RegionId",
                table: "User",
                type: "bigint",
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "VillageId",
                table: "User",
                type: "bigint",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "City",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    RegionId = table.Column<long>(type: "bigint", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_City", x => x.Id);
                    table.ForeignKey(
                        name: "FK_City_Region_RegionId",
                        column: x => x.RegionId,
                        principalTable: "Region",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Flat",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    FloorId = table.Column<long>(type: "bigint", nullable: false),
                    Address = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Flat", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Flat_Floor_FloorId",
                        column: x => x.FloorId,
                        principalTable: "Floor",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "HouseAddress",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    StreetId = table.Column<long>(type: "bigint", nullable: false),
                    Address = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HouseAddress", x => x.Id);
                    table.ForeignKey(
                        name: "FK_HouseAddress_Street_StreetId",
                        column: x => x.StreetId,
                        principalTable: "Street",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Village_fkCityId",
                table: "Village",
                column: "fkCityId");

            migrationBuilder.CreateIndex(
                name: "IX_User_ApartmentId",
                table: "User",
                column: "ApartmentId");

            migrationBuilder.CreateIndex(
                name: "IX_User_CityId",
                table: "User",
                column: "CityId");

            migrationBuilder.CreateIndex(
                name: "IX_User_FlatId",
                table: "User",
                column: "FlatId");

            migrationBuilder.CreateIndex(
                name: "IX_User_HouseAddressId",
                table: "User",
                column: "HouseAddressId");

            migrationBuilder.CreateIndex(
                name: "IX_User_RegionId",
                table: "User",
                column: "RegionId");

            migrationBuilder.CreateIndex(
                name: "IX_User_VillageId",
                table: "User",
                column: "VillageId");

            migrationBuilder.CreateIndex(
                name: "IX_City_RegionId",
                table: "City",
                column: "RegionId");

            migrationBuilder.CreateIndex(
                name: "IX_Flat_FloorId",
                table: "Flat",
                column: "FloorId");

            migrationBuilder.CreateIndex(
                name: "IX_HouseAddress_StreetId",
                table: "HouseAddress",
                column: "StreetId");

            migrationBuilder.AddForeignKey(
                name: "FK_Floor_Apartment_ApartmentId",
                table: "Floor",
                column: "ApartmentId",
                principalTable: "Apartment",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_User_Apartment_ApartmentId",
                table: "User",
                column: "ApartmentId",
                principalTable: "Apartment",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_User_City_CityId",
                table: "User",
                column: "CityId",
                principalTable: "City",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_User_Flat_FlatId",
                table: "User",
                column: "FlatId",
                principalTable: "Flat",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_User_Floor_FloorId",
                table: "User",
                column: "FloorId",
                principalTable: "Floor",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_User_HouseAddress_HouseAddressId",
                table: "User",
                column: "HouseAddressId",
                principalTable: "HouseAddress",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_User_Region_RegionId",
                table: "User",
                column: "RegionId",
                principalTable: "Region",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_User_Street_StreetId",
                table: "User",
                column: "StreetId",
                principalTable: "Street",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_User_Village_VillageId",
                table: "User",
                column: "VillageId",
                principalTable: "Village",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Village_City_fkCityId",
                table: "Village",
                column: "fkCityId",
                principalTable: "City",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Floor_Apartment_ApartmentId",
                table: "Floor");

            migrationBuilder.DropForeignKey(
                name: "FK_User_Apartment_ApartmentId",
                table: "User");

            migrationBuilder.DropForeignKey(
                name: "FK_User_City_CityId",
                table: "User");

            migrationBuilder.DropForeignKey(
                name: "FK_User_Flat_FlatId",
                table: "User");

            migrationBuilder.DropForeignKey(
                name: "FK_User_Floor_FloorId",
                table: "User");

            migrationBuilder.DropForeignKey(
                name: "FK_User_HouseAddress_HouseAddressId",
                table: "User");

            migrationBuilder.DropForeignKey(
                name: "FK_User_Region_RegionId",
                table: "User");

            migrationBuilder.DropForeignKey(
                name: "FK_User_Street_StreetId",
                table: "User");

            migrationBuilder.DropForeignKey(
                name: "FK_User_Village_VillageId",
                table: "User");

            migrationBuilder.DropForeignKey(
                name: "FK_Village_City_fkCityId",
                table: "Village");

            migrationBuilder.DropTable(
                name: "City");

            migrationBuilder.DropTable(
                name: "Flat");

            migrationBuilder.DropTable(
                name: "HouseAddress");

            migrationBuilder.DropIndex(
                name: "IX_Village_fkCityId",
                table: "Village");

            migrationBuilder.DropIndex(
                name: "IX_User_ApartmentId",
                table: "User");

            migrationBuilder.DropIndex(
                name: "IX_User_CityId",
                table: "User");

            migrationBuilder.DropIndex(
                name: "IX_User_FlatId",
                table: "User");

            migrationBuilder.DropIndex(
                name: "IX_User_HouseAddressId",
                table: "User");

            migrationBuilder.DropIndex(
                name: "IX_User_RegionId",
                table: "User");

            migrationBuilder.DropIndex(
                name: "IX_User_VillageId",
                table: "User");

            migrationBuilder.DropColumn(
                name: "fkCityId",
                table: "Village");

            migrationBuilder.DropColumn(
                name: "ApartmentId",
                table: "User");

            migrationBuilder.DropColumn(
                name: "CityId",
                table: "User");

            migrationBuilder.DropColumn(
                name: "FlatId",
                table: "User");

            migrationBuilder.DropColumn(
                name: "HouseAddressId",
                table: "User");

            migrationBuilder.DropColumn(
                name: "RegionId",
                table: "User");

            migrationBuilder.DropColumn(
                name: "VillageId",
                table: "User");

            migrationBuilder.RenameColumn(
                name: "ApartmentId",
                table: "Floor",
                newName: "EntranceId");

            migrationBuilder.RenameIndex(
                name: "IX_Floor_ApartmentId",
                table: "Floor",
                newName: "IX_Floor_EntranceId");

            migrationBuilder.AddColumn<string>(
                name: "Address",
                table: "User",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Discriminator",
                table: "User",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Flat_Address",
                table: "User",
                type: "text",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "District",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    RegionId = table.Column<long>(type: "bigint", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_District", x => x.Id);
                    table.ForeignKey(
                        name: "FK_District_Region_RegionId",
                        column: x => x.RegionId,
                        principalTable: "Region",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Entrance",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    fkApartmentId = table.Column<long>(type: "bigint", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: false),
                    StreetId = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Entrance", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Entrance_Apartment_fkApartmentId",
                        column: x => x.fkApartmentId,
                        principalTable: "Apartment",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Village_DistrictId",
                table: "Village",
                column: "DistrictId");

            migrationBuilder.CreateIndex(
                name: "IX_District_RegionId",
                table: "District",
                column: "RegionId");

            migrationBuilder.CreateIndex(
                name: "IX_Entrance_fkApartmentId",
                table: "Entrance",
                column: "fkApartmentId");

            migrationBuilder.AddForeignKey(
                name: "FK_Floor_Entrance_EntranceId",
                table: "Floor",
                column: "EntranceId",
                principalTable: "Entrance",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_User_Floor_FloorId",
                table: "User",
                column: "FloorId",
                principalTable: "Floor",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_User_Street_StreetId",
                table: "User",
                column: "StreetId",
                principalTable: "Street",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Village_District_DistrictId",
                table: "Village",
                column: "DistrictId",
                principalTable: "District",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
