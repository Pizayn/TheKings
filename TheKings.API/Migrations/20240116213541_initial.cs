using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TheKings.API.Migrations
{
    public partial class initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Monarches",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false),
                    Nm = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Cty = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Hse = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Yrs = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Monarches", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Monarches");
        }
    }
}
