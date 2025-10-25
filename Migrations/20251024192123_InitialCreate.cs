using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace isgasoir.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "filieres",
                columns: table => new
                {
                    Id = table.Column<long>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", nullable: false),
                    Description = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_filieres", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "products",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Desg = table.Column<string>(type: "TEXT", nullable: false),
                    Qte = table.Column<double>(type: "REAL", nullable: false),
                    Pu = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_products", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "studants",
                columns: table => new
                {
                    Id = table.Column<long>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Nom = table.Column<string>(type: "TEXT", nullable: false),
                    Prenom = table.Column<string>(type: "TEXT", nullable: false),
                    Date = table.Column<DateTime>(type: "TEXT", nullable: false),
                    Gender = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_studants", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "semestrees",
                columns: table => new
                {
                    Id = table.Column<long>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", nullable: false),
                    FiliereId = table.Column<long>(type: "INTEGER", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_semestrees", x => x.Id);
                    table.ForeignKey(
                        name: "FK_semestrees_filieres_FiliereId",
                        column: x => x.FiliereId,
                        principalTable: "filieres",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "modules",
                columns: table => new
                {
                    Id = table.Column<long>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", nullable: false),
                    Coiff = table.Column<double>(type: "REAL", nullable: false),
                    SemId = table.Column<long>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_modules", x => x.Id);
                    table.ForeignKey(
                        name: "FK_modules_semestrees_SemId",
                        column: x => x.SemId,
                        principalTable: "semestrees",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "chapitres",
                columns: table => new
                {
                    Id = table.Column<long>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Duree = table.Column<double>(type: "REAL", nullable: false),
                    Title = table.Column<string>(type: "TEXT", nullable: false),
                    Content = table.Column<string>(type: "TEXT", nullable: false),
                    ModuleId = table.Column<long>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_chapitres", x => x.Id);
                    table.ForeignKey(
                        name: "FK_chapitres_modules_ModuleId",
                        column: x => x.ModuleId,
                        principalTable: "modules",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ModuleStudant",
                columns: table => new
                {
                    ModulesId = table.Column<long>(type: "INTEGER", nullable: false),
                    StudantsId = table.Column<long>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ModuleStudant", x => new { x.ModulesId, x.StudantsId });
                    table.ForeignKey(
                        name: "FK_ModuleStudant_modules_ModulesId",
                        column: x => x.ModulesId,
                        principalTable: "modules",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ModuleStudant_studants_StudantsId",
                        column: x => x.StudantsId,
                        principalTable: "studants",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "activities",
                columns: table => new
                {
                    Id = table.Column<long>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Title = table.Column<string>(type: "TEXT", nullable: false),
                    Description = table.Column<string>(type: "TEXT", nullable: false),
                    Type = table.Column<string>(type: "TEXT", nullable: false),
                    DueDate = table.Column<DateTime>(type: "TEXT", nullable: true),
                    Duration = table.Column<int>(type: "INTEGER", nullable: false),
                    Instructions = table.Column<string>(type: "TEXT", nullable: false),
                    ChapitreId = table.Column<long>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_activities", x => x.Id);
                    table.ForeignKey(
                        name: "FK_activities_chapitres_ChapitreId",
                        column: x => x.ChapitreId,
                        principalTable: "chapitres",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_activities_ChapitreId",
                table: "activities",
                column: "ChapitreId");

            migrationBuilder.CreateIndex(
                name: "IX_chapitres_ModuleId",
                table: "chapitres",
                column: "ModuleId");

            migrationBuilder.CreateIndex(
                name: "IX_modules_SemId",
                table: "modules",
                column: "SemId");

            migrationBuilder.CreateIndex(
                name: "IX_ModuleStudant_StudantsId",
                table: "ModuleStudant",
                column: "StudantsId");

            migrationBuilder.CreateIndex(
                name: "IX_semestrees_FiliereId",
                table: "semestrees",
                column: "FiliereId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "activities");

            migrationBuilder.DropTable(
                name: "ModuleStudant");

            migrationBuilder.DropTable(
                name: "products");

            migrationBuilder.DropTable(
                name: "chapitres");

            migrationBuilder.DropTable(
                name: "studants");

            migrationBuilder.DropTable(
                name: "modules");

            migrationBuilder.DropTable(
                name: "semestrees");

            migrationBuilder.DropTable(
                name: "filieres");
        }
    }
}
