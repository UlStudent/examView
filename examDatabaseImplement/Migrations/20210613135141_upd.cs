using Microsoft.EntityFrameworkCore.Migrations;

namespace examDatabaseImplement.Migrations
{
    public partial class upd : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Components_SystemBlocks_SystemBlockId",
                table: "Components");

            migrationBuilder.AlterColumn<int>(
                name: "SystemBlockId",
                table: "Components",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_Components_SystemBlocks_SystemBlockId",
                table: "Components",
                column: "SystemBlockId",
                principalTable: "SystemBlocks",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Components_SystemBlocks_SystemBlockId",
                table: "Components");

            migrationBuilder.AlterColumn<int>(
                name: "SystemBlockId",
                table: "Components",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Components_SystemBlocks_SystemBlockId",
                table: "Components",
                column: "SystemBlockId",
                principalTable: "SystemBlocks",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
