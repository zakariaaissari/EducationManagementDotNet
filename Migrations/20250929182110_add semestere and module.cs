using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace isgasoir.Migrations
{
    /// <inheritdoc />
    public partial class addsemestereandmodule : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "semestrees",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_semestrees", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "modules",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Coiff = table.Column<double>(type: "float", nullable: false),
                    SemId = table.Column<long>(type: "bigint", nullable: false)
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
                name: "ModuleStudant",
                columns: table => new
                {
                    ModulesId = table.Column<long>(type: "bigint", nullable: false),
                    StudantsId = table.Column<long>(type: "bigint", nullable: false)
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

            migrationBuilder.CreateIndex(
                name: "IX_modules_SemId",
                table: "modules",
                column: "SemId");

            migrationBuilder.CreateIndex(
                name: "IX_ModuleStudant_StudantsId",
                table: "ModuleStudant",
                column: "StudantsId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ModuleStudant");

            migrationBuilder.DropTable(
                name: "modules");

            migrationBuilder.DropTable(
                name: "semestrees");
        }
    }
}
