using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace SmartSolucionesCuba.Covid19CubaInfo.Cloud.Migrations
{
    public partial class InitialSchemaMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "countries",
                columns: table => new
                {
                    id = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_countries", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "provinces",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false),
                    name = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_provinces", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "reports",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false),
                    at = table.Column<DateTime>(nullable: false),
                    riskycontactcount = table.Column<int>(nullable: false),
                    testcount = table.Column<int>(nullable: false),
                    deadcasecount = table.Column<int>(nullable: false),
                    evacuatecasecount = table.Column<int>(nullable: false),
                    gravecasecount = table.Column<int>(nullable: false),
                    criticcasecount = table.Column<int>(nullable: false),
                    recoveredcasecount = table.Column<int>(nullable: false),
                    notes = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_reports", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "traces",
                columns: table => new
                {
                    id = table.Column<long>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    type = table.Column<int>(nullable: false),
                    author = table.Column<string>(nullable: true),
                    registered = table.Column<DateTime>(nullable: false),
                    entityname = table.Column<string>(nullable: false),
                    beforedata = table.Column<string>(nullable: false),
                    afterdata = table.Column<string>(nullable: true),
                    nextid = table.Column<long>(nullable: false),
                    signature = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_traces", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "municipalities",
                columns: table => new
                {
                    id = table.Column<string>(nullable: false),
                    name = table.Column<string>(nullable: false),
                    provinceid = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_municipalities", x => x.id);
                    table.ForeignKey(
                        name: "fk_municipalities_provinces_provinceid",
                        column: x => x.provinceid,
                        principalTable: "provinces",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "diagnosticcenters",
                columns: table => new
                {
                    id = table.Column<string>(nullable: false),
                    name = table.Column<string>(nullable: false),
                    reportid = table.Column<int>(nullable: false),
                    provinceid = table.Column<int>(nullable: false),
                    geopointlatitude = table.Column<decimal>(nullable: false),
                    geopointlongitude = table.Column<decimal>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_diagnosticcenters", x => x.id);
                    table.ForeignKey(
                        name: "fk_diagnosticcenters_provinces_provinceid",
                        column: x => x.provinceid,
                        principalTable: "provinces",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_diagnosticcenters_reports_reportid",
                        column: x => x.reportid,
                        principalTable: "reports",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "isolationcenters",
                columns: table => new
                {
                    id = table.Column<string>(nullable: false),
                    name = table.Column<string>(nullable: false),
                    reportid = table.Column<int>(nullable: false),
                    provinceid = table.Column<int>(nullable: false),
                    geopointlatitude = table.Column<decimal>(nullable: false),
                    geopointlongitude = table.Column<decimal>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_isolationcenters", x => x.id);
                    table.ForeignKey(
                        name: "fk_isolationcenters_provinces_provinceid",
                        column: x => x.provinceid,
                        principalTable: "provinces",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_isolationcenters_reports_reportid",
                        column: x => x.reportid,
                        principalTable: "reports",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "events",
                columns: table => new
                {
                    id = table.Column<string>(nullable: false),
                    label = table.Column<string>(nullable: false),
                    reportid = table.Column<int>(nullable: false),
                    opened = table.Column<bool>(nullable: false),
                    @checked = table.Column<bool>(name: "checked", nullable: false),
                    municipalityid = table.Column<string>(nullable: true),
                    centergeopointlatitude = table.Column<decimal>(nullable: false),
                    centergeopointlongitude = table.Column<decimal>(nullable: false),
                    areageodata = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_events", x => x.id);
                    table.ForeignKey(
                        name: "fk_events_municipalities_municipalityid",
                        column: x => x.municipalityid,
                        principalTable: "municipalities",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "fk_events_reports_reportid",
                        column: x => x.reportid,
                        principalTable: "reports",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "cases",
                columns: table => new
                {
                    id = table.Column<long>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    reportid = table.Column<int>(nullable: false),
                    arriveat = table.Column<DateTime>(nullable: false),
                    detectat = table.Column<DateTime>(nullable: false),
                    detectionmunicipalityid = table.Column<string>(nullable: true),
                    contactcount = table.Column<int>(nullable: false),
                    countryid = table.Column<string>(nullable: true),
                    age = table.Column<int>(nullable: false),
                    sex = table.Column<int>(nullable: false),
                    kind = table.Column<int>(nullable: false),
                    diagnosticcenterid = table.Column<string>(nullable: true),
                    isolationcenterid = table.Column<string>(nullable: true),
                    about = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_cases", x => x.id);
                    table.ForeignKey(
                        name: "fk_cases_countries_countryid",
                        column: x => x.countryid,
                        principalTable: "countries",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "fk_cases_municipalities_detectionmunicipalityid",
                        column: x => x.detectionmunicipalityid,
                        principalTable: "municipalities",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "fk_cases_diagnosticcenters_diagnosticcenterid",
                        column: x => x.diagnosticcenterid,
                        principalTable: "diagnosticcenters",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "fk_cases_isolationcenters_isolationcenterid",
                        column: x => x.isolationcenterid,
                        principalTable: "isolationcenters",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "fk_cases_reports_reportid",
                        column: x => x.reportid,
                        principalTable: "reports",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "casecountrybridges",
                columns: table => new
                {
                    caseid = table.Column<long>(nullable: false),
                    countryid = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_casecountrybridges", x => new { x.caseid, x.countryid });
                    table.ForeignKey(
                        name: "fk_casecountrybridges_cases_caseid",
                        column: x => x.caseid,
                        principalTable: "cases",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_casecountrybridges_countries_countryid",
                        column: x => x.countryid,
                        principalTable: "countries",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "caseprovincebridges",
                columns: table => new
                {
                    caseid = table.Column<long>(nullable: false),
                    provinceid = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_caseprovincebridges", x => new { x.caseid, x.provinceid });
                    table.ForeignKey(
                        name: "fk_caseprovincebridges_cases_caseid",
                        column: x => x.caseid,
                        principalTable: "cases",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_caseprovincebridges_provinces_provinceid",
                        column: x => x.provinceid,
                        principalTable: "provinces",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "reportcriticcasebridges",
                columns: table => new
                {
                    caseid = table.Column<long>(nullable: false),
                    reportid = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_reportcriticcasebridges", x => new { x.reportid, x.caseid });
                    table.ForeignKey(
                        name: "fk_reportcriticcasebridges_cases_caseid",
                        column: x => x.caseid,
                        principalTable: "cases",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_reportcriticcasebridges_reports_reportid",
                        column: x => x.reportid,
                        principalTable: "reports",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "reportdeadcasebridges",
                columns: table => new
                {
                    caseid = table.Column<long>(nullable: false),
                    reportid = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_reportdeadcasebridges", x => new { x.reportid, x.caseid });
                    table.ForeignKey(
                        name: "fk_reportdeadcasebridges_cases_caseid",
                        column: x => x.caseid,
                        principalTable: "cases",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_reportdeadcasebridges_reports_reportid",
                        column: x => x.reportid,
                        principalTable: "reports",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "reportevacuatecasebridges",
                columns: table => new
                {
                    caseid = table.Column<long>(nullable: false),
                    reportid = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_reportevacuatecasebridges", x => new { x.reportid, x.caseid });
                    table.ForeignKey(
                        name: "fk_reportevacuatecasebridges_cases_caseid",
                        column: x => x.caseid,
                        principalTable: "cases",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_reportevacuatecasebridges_reports_reportid",
                        column: x => x.reportid,
                        principalTable: "reports",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "reportgravecasebridges",
                columns: table => new
                {
                    caseid = table.Column<long>(nullable: false),
                    reportid = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_reportgravecasebridges", x => new { x.reportid, x.caseid });
                    table.ForeignKey(
                        name: "fk_reportgravecasebridges_cases_caseid",
                        column: x => x.caseid,
                        principalTable: "cases",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_reportgravecasebridges_reports_reportid",
                        column: x => x.reportid,
                        principalTable: "reports",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "reportrecoveredcasebridges",
                columns: table => new
                {
                    caseid = table.Column<long>(nullable: false),
                    reportid = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_reportrecoveredcasebridges", x => new { x.reportid, x.caseid });
                    table.ForeignKey(
                        name: "fk_reportrecoveredcasebridges_cases_caseid",
                        column: x => x.caseid,
                        principalTable: "cases",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_reportrecoveredcasebridges_reports_reportid",
                        column: x => x.reportid,
                        principalTable: "reports",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "ix_casecountrybridges_countryid",
                table: "casecountrybridges",
                column: "countryid");

            migrationBuilder.CreateIndex(
                name: "ix_caseprovincebridges_provinceid",
                table: "caseprovincebridges",
                column: "provinceid");

            migrationBuilder.CreateIndex(
                name: "ix_cases_countryid",
                table: "cases",
                column: "countryid");

            migrationBuilder.CreateIndex(
                name: "ix_cases_detectionmunicipalityid",
                table: "cases",
                column: "detectionmunicipalityid");

            migrationBuilder.CreateIndex(
                name: "ix_cases_diagnosticcenterid",
                table: "cases",
                column: "diagnosticcenterid");

            migrationBuilder.CreateIndex(
                name: "ix_cases_isolationcenterid",
                table: "cases",
                column: "isolationcenterid");

            migrationBuilder.CreateIndex(
                name: "ix_cases_reportid",
                table: "cases",
                column: "reportid");

            migrationBuilder.CreateIndex(
                name: "ix_diagnosticcenters_provinceid",
                table: "diagnosticcenters",
                column: "provinceid");

            migrationBuilder.CreateIndex(
                name: "ix_diagnosticcenters_reportid",
                table: "diagnosticcenters",
                column: "reportid");

            migrationBuilder.CreateIndex(
                name: "ix_events_municipalityid",
                table: "events",
                column: "municipalityid");

            migrationBuilder.CreateIndex(
                name: "ix_events_reportid",
                table: "events",
                column: "reportid");

            migrationBuilder.CreateIndex(
                name: "ix_isolationcenters_provinceid",
                table: "isolationcenters",
                column: "provinceid");

            migrationBuilder.CreateIndex(
                name: "ix_isolationcenters_reportid",
                table: "isolationcenters",
                column: "reportid");

            migrationBuilder.CreateIndex(
                name: "ix_municipalities_provinceid",
                table: "municipalities",
                column: "provinceid");

            migrationBuilder.CreateIndex(
                name: "ix_reportcriticcasebridges_caseid",
                table: "reportcriticcasebridges",
                column: "caseid");

            migrationBuilder.CreateIndex(
                name: "ix_reportdeadcasebridges_caseid",
                table: "reportdeadcasebridges",
                column: "caseid");

            migrationBuilder.CreateIndex(
                name: "ix_reportevacuatecasebridges_caseid",
                table: "reportevacuatecasebridges",
                column: "caseid");

            migrationBuilder.CreateIndex(
                name: "ix_reportgravecasebridges_caseid",
                table: "reportgravecasebridges",
                column: "caseid");

            migrationBuilder.CreateIndex(
                name: "ix_reportrecoveredcasebridges_caseid",
                table: "reportrecoveredcasebridges",
                column: "caseid");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "casecountrybridges");

            migrationBuilder.DropTable(
                name: "caseprovincebridges");

            migrationBuilder.DropTable(
                name: "events");

            migrationBuilder.DropTable(
                name: "reportcriticcasebridges");

            migrationBuilder.DropTable(
                name: "reportdeadcasebridges");

            migrationBuilder.DropTable(
                name: "reportevacuatecasebridges");

            migrationBuilder.DropTable(
                name: "reportgravecasebridges");

            migrationBuilder.DropTable(
                name: "reportrecoveredcasebridges");

            migrationBuilder.DropTable(
                name: "traces");

            migrationBuilder.DropTable(
                name: "cases");

            migrationBuilder.DropTable(
                name: "countries");

            migrationBuilder.DropTable(
                name: "municipalities");

            migrationBuilder.DropTable(
                name: "diagnosticcenters");

            migrationBuilder.DropTable(
                name: "isolationcenters");

            migrationBuilder.DropTable(
                name: "provinces");

            migrationBuilder.DropTable(
                name: "reports");
        }
    }
}
