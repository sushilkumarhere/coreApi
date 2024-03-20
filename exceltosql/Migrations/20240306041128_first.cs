using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace exceltosql.Migrations
{
    /// <inheritdoc />
    public partial class first : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "emp",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Gender = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_emp", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "his_icd_diagnosis1",
                columns: table => new
                {
                    IcdID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IcdCode = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    LD = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_his_icd_diagnosis1", x => x.IcdID);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "emp");

            migrationBuilder.DropTable(
                name: "his_icd_diagnosis1");
        }
    }
}
