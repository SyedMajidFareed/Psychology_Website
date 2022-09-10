using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Website.Migrations
{
    public partial class AddedTherapistTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Therapists",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TUsername = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    TPassword = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    TEmail = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TContactNum = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    imgPath = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Therapists", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Therapists");
        }
    }
}
