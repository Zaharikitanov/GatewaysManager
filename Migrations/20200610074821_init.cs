using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace GatewaysManager.Migrations
{
    public partial class init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Gateways",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    SerialNumber = table.Column<string>(nullable: true),
                    Name = table.Column<string>(nullable: true),
                    IPv4 = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Gateways", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Peripherals",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    UID = table.Column<int>(nullable: false),
                    Vendor = table.Column<string>(nullable: true),
                    DateCreated = table.Column<string>(nullable: true),
                    GatewayId = table.Column<Guid>(nullable: false),
                    Status = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Peripherals", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Peripherals_Gateways_GatewayId",
                        column: x => x.GatewayId,
                        principalTable: "Gateways",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Peripherals_GatewayId",
                table: "Peripherals",
                column: "GatewayId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Peripherals");

            migrationBuilder.DropTable(
                name: "Gateways");
        }
    }
}
