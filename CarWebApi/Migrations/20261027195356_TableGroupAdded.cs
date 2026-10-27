using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CarWebApi.Migrations
{
    /// <inheritdoc />
    public partial class TableGroupAdded : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "GroupId",
                table: "Cars",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Groups",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Groups", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Cars_GroupId",
                table: "Cars",
                column: "GroupId");

            migrationBuilder.AddForeignKey(
                name: "FK_Cars_Groups_GroupId",
                table: "Cars",
                column: "GroupId",
                principalTable: "Groups",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Cars_Groups_GroupId",
                table: "Cars");

            migrationBuilder.DropTable(
                name: "Groups");

            migrationBuilder.DropIndex(
                name: "IX_Cars_GroupId",
                table: "Cars");

            migrationBuilder.DropColumn(
                name: "GroupId",
                table: "Cars");
        }
    }
}
