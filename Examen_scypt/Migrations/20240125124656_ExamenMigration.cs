using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Examen_scypt.Migrations
{
    /// <inheritdoc />
    public partial class ExamenMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Examene",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.CreateTable(
                name: "Produse",
                columns: table => new
                {
                    ProdusId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Produse", x => x.ProdusId);
                });

            migrationBuilder.CreateTable(
                name: "Utilizators",
                columns: table => new
                {
                    UtilizatorId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Utilizators", x => x.UtilizatorId);
                });

            migrationBuilder.CreateTable(
                name: "Comenzii",
                columns: table => new
                {
                    ComenziId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UtilizatorId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Comenzii", x => x.ComenziId);
                    table.ForeignKey(
                        name: "FK_Comenzii_Utilizators_UtilizatorId",
                        column: x => x.UtilizatorId,
                        principalTable: "Utilizators",
                        principalColumn: "UtilizatorId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ComenziProduse",
                columns: table => new
                {
                    ProdusId = table.Column<int>(type: "int", nullable: false),
                    ComenziId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ComenziProduse", x => new { x.ComenziId, x.ProdusId });
                    table.ForeignKey(
                        name: "FK_ComenziProduse_Comenzii_ComenziId",
                        column: x => x.ComenziId,
                        principalTable: "Comenzii",
                        principalColumn: "ComenziId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ComenziProduse_Produse_ComenziId",
                        column: x => x.ComenziId,
                        principalTable: "Produse",
                        principalColumn: "ProdusId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Comenzii_UtilizatorId",
                table: "Comenzii",
                column: "UtilizatorId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ComenziProduse");

            migrationBuilder.DropTable(
                name: "Comenzii");

            migrationBuilder.DropTable(
                name: "Produse");

            migrationBuilder.DropTable(
                name: "Utilizators");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Examene",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);
        }
    }
}
