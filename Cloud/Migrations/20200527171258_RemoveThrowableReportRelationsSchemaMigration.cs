using Microsoft.EntityFrameworkCore.Migrations;

namespace SmartSolucionesCuba.Covid19CubaInfo.Cloud.Migrations
{
    public partial class RemoveThrowableReportRelationsSchemaMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "fk_diagnosticcenters_reports_reportid",
                table: "diagnosticcenters");

            migrationBuilder.DropForeignKey(
                name: "fk_events_reports_reportid",
                table: "events");

            migrationBuilder.DropForeignKey(
                name: "fk_isolationcenters_reports_reportid",
                table: "isolationcenters");

            migrationBuilder.DropIndex(
                name: "ix_isolationcenters_reportid",
                table: "isolationcenters");

            migrationBuilder.DropIndex(
                name: "ix_events_reportid",
                table: "events");

            migrationBuilder.DropIndex(
                name: "ix_diagnosticcenters_reportid",
                table: "diagnosticcenters");

            migrationBuilder.RenameColumn(
                name: "reportid",
                table: "isolationcenters",
                newName: "pushday");

            migrationBuilder.RenameColumn(
                name: "reportid",
                table: "events",
                newName: "pushday");

            migrationBuilder.RenameColumn(
                name: "reportid",
                table: "diagnosticcenters",
                newName: "pushday");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "pushday",
                table: "isolationcenters",
                newName: "reportid");

            migrationBuilder.RenameColumn(
                name: "pushday",
                table: "events",
                newName: "reportid");

            migrationBuilder.RenameColumn(
                name: "pushday",
                table: "diagnosticcenters",
                newName: "reportid");

            migrationBuilder.CreateIndex(
                name: "ix_isolationcenters_reportid",
                table: "isolationcenters",
                column: "reportid");

            migrationBuilder.CreateIndex(
                name: "ix_events_reportid",
                table: "events",
                column: "reportid");

            migrationBuilder.CreateIndex(
                name: "ix_diagnosticcenters_reportid",
                table: "diagnosticcenters",
                column: "reportid");

            migrationBuilder.AddForeignKey(
                name: "fk_diagnosticcenters_reports_reportid",
                table: "diagnosticcenters",
                column: "reportid",
                principalTable: "reports",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "fk_events_reports_reportid",
                table: "events",
                column: "reportid",
                principalTable: "reports",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "fk_isolationcenters_reports_reportid",
                table: "isolationcenters",
                column: "reportid",
                principalTable: "reports",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
