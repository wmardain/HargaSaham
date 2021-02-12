using Microsoft.EntityFrameworkCore.Migrations;

namespace HargaSaham.Migrations
{
    public partial class initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Sektors",
                columns: table => new
                {
                    SektorId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Nama = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sektors", x => x.SektorId);
                });

            migrationBuilder.CreateTable(
                name: "Sahams",
                columns: table => new
                {
                    SahamID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NamaSaham = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Harga = table.Column<int>(type: "int", nullable: false),
                    SektorId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sahams", x => x.SahamID);
                    table.ForeignKey(
                        name: "FK_Sahams_Sektors_SektorId",
                        column: x => x.SektorId,
                        principalTable: "Sektors",
                        principalColumn: "SektorId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Sektors",
                columns: new[] { "SektorId", "Nama" },
                values: new object[] { "I", "Infra" });

            migrationBuilder.InsertData(
                table: "Sektors",
                columns: new[] { "SektorId", "Nama" },
                values: new object[] { "B", "Banking" });

            migrationBuilder.InsertData(
                table: "Sektors",
                columns: new[] { "SektorId", "Nama" },
                values: new object[] { "M", "Mining" });

            migrationBuilder.InsertData(
                table: "Sahams",
                columns: new[] { "SahamID", "Harga", "NamaSaham", "SektorId" },
                values: new object[] { 1, 1900, "WIKA", "I" });

            migrationBuilder.InsertData(
                table: "Sahams",
                columns: new[] { "SahamID", "Harga", "NamaSaham", "SektorId" },
                values: new object[] { 2, 2000, "BRIS", "B" });

            migrationBuilder.CreateIndex(
                name: "IX_Sahams_SektorId",
                table: "Sahams",
                column: "SektorId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Sahams");

            migrationBuilder.DropTable(
                name: "Sektors");
        }
    }
}
