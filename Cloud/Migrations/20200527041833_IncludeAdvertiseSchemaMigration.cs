using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace SmartSolucionesCuba.Covid19CubaInfo.Cloud.Migrations
{
    public partial class IncludeAdvertiseSchemaMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "appupdateadvises",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    version = table.Column<string>(nullable: false),
                    releasedat = table.Column<DateTime>(nullable: false),
                    accesslink = table.Column<string>(nullable: false),
                    pushday = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_appupdateadvises", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "vendoradvises",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    title = table.Column<string>(nullable: false),
                    description = table.Column<string>(nullable: false),
                    accesslink = table.Column<string>(nullable: false),
                    thumbnailimagelink = table.Column<string>(nullable: true),
                    pushday = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_vendoradvises", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "appupdatefeatures",
                columns: table => new
                {
                    id = table.Column<long>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    adviseid = table.Column<int>(nullable: false),
                    description = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_appupdatefeatures", x => x.id);
                    table.ForeignKey(
                        name: "fk_appupdatefeatures_appupdateadvises_adviseid",
                        column: x => x.adviseid,
                        principalTable: "appupdateadvises",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "vendoradvisefeatures",
                columns: table => new
                {
                    id = table.Column<long>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    adviseid = table.Column<int>(nullable: false),
                    description = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_vendoradvisefeatures", x => x.id);
                    table.ForeignKey(
                        name: "fk_vendoradvisefeatures_vendoradvises_adviseid",
                        column: x => x.adviseid,
                        principalTable: "vendoradvises",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "ix_appupdatefeatures_adviseid",
                table: "appupdatefeatures",
                column: "adviseid");

            migrationBuilder.CreateIndex(
                name: "ix_vendoradvisefeatures_adviseid",
                table: "vendoradvisefeatures",
                column: "adviseid");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "appupdatefeatures");

            migrationBuilder.DropTable(
                name: "vendoradvisefeatures");

            migrationBuilder.DropTable(
                name: "appupdateadvises");

            migrationBuilder.DropTable(
                name: "vendoradvises");
        }
    }
}
