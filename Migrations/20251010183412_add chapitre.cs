using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace isgasoir.Migrations
{
    /// <inheritdoc />
    public partial class addchapitre : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<long>(
                name: "FiliereId",
                table: "semestrees",
                type: "bigint",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "chapitres",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Duree = table.Column<double>(type: "float", nullable: false),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Content = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ModuleId = table.Column<long>(type: "bigint", nullable: false)
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
                name: "filieres",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_filieres", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_semestrees_FiliereId",
                table: "semestrees",
                column: "FiliereId");

            migrationBuilder.CreateIndex(
                name: "IX_chapitres_ModuleId",
                table: "chapitres",
                column: "ModuleId");

            migrationBuilder.AddForeignKey(
                name: "FK_semestrees_filieres_FiliereId",
                table: "semestrees",
                column: "FiliereId",
                principalTable: "filieres",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_semestrees_filieres_FiliereId",
                table: "semestrees");

            migrationBuilder.DropTable(
                name: "chapitres");

            migrationBuilder.DropTable(
                name: "filieres");

            migrationBuilder.DropIndex(
                name: "IX_semestrees_FiliereId",
                table: "semestrees");

            migrationBuilder.DropColumn(
                name: "FiliereId",
                table: "semestrees");
        }
    }
}
