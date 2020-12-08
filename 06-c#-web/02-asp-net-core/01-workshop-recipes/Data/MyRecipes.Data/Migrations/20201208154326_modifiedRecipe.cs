using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace MyRecipes.Data.Migrations
{
    public partial class modifiedRecipe : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Recipes_AspNetUsers_CreatorUserId",
                table: "Recipes");

            migrationBuilder.DropTable(
                name: "Settings");

            migrationBuilder.DropIndex(
                name: "IX_Recipes_CreatorUserId",
                table: "Recipes");

            migrationBuilder.DropColumn(
                name: "CreatorUserId",
                table: "Recipes");

            migrationBuilder.AddColumn<string>(
                name: "AddedByUserId",
                table: "Recipes",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "RemoteImageUrl",
                table: "Images",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Recipes_AddedByUserId",
                table: "Recipes",
                column: "AddedByUserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Recipes_AspNetUsers_AddedByUserId",
                table: "Recipes",
                column: "AddedByUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Recipes_AspNetUsers_AddedByUserId",
                table: "Recipes");

            migrationBuilder.DropIndex(
                name: "IX_Recipes_AddedByUserId",
                table: "Recipes");

            migrationBuilder.DropColumn(
                name: "AddedByUserId",
                table: "Recipes");

            migrationBuilder.DropColumn(
                name: "RemoteImageUrl",
                table: "Images");

            migrationBuilder.AddColumn<string>(
                name: "CreatorUserId",
                table: "Recipes",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Settings",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DeletedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    ModifiedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Value = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Settings", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Recipes_CreatorUserId",
                table: "Recipes",
                column: "CreatorUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Settings_IsDeleted",
                table: "Settings",
                column: "IsDeleted");

            migrationBuilder.AddForeignKey(
                name: "FK_Recipes_AspNetUsers_CreatorUserId",
                table: "Recipes",
                column: "CreatorUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
