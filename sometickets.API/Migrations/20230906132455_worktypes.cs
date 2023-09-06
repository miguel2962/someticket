using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace sometickets.API.Migrations
{
    /// <inheritdoc />
    public partial class worktypes : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ClienteType",
                columns: table => new
                {
                    Id_clienteType = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Description = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ClienteType", x => x.Id_clienteType);
                });

            migrationBuilder.CreateTable(
                name: "WorkTypes",
                columns: table => new
                {
                    Id_worktype = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Description = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WorkTypes", x => x.Id_worktype);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ClienteType_Description",
                table: "ClienteType",
                column: "Description",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_WorkTypes_Description",
                table: "WorkTypes",
                column: "Description",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ClienteType");

            migrationBuilder.DropTable(
                name: "WorkTypes");
        }
    }
}
