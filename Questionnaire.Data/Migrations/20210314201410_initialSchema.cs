using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Questionnaire.Data.Migrations
{
    public partial class initialSchema : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Answers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    QuestionId = table.Column<int>(type: "int", nullable: false),
                    OptionId = table.Column<int>(type: "int", nullable: false),
                    IsCorrect = table.Column<bool>(type: "bit", nullable: false),
                    Stamp = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Answers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Questions",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    QuestionStatement = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    isActive = table.Column<bool>(type: "bit", nullable: false),
                    Stamp = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Questions", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "QuestionsOptions",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    QuestionId = table.Column<int>(type: "int", nullable: false),
                    OptionStatement = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    isCorrect = table.Column<bool>(type: "bit", nullable: false),
                    Stamp = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_QuestionsOptions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_QuestionsOptions_Questions_QuestionId",
                        column: x => x.QuestionId,
                        principalTable: "Questions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                table: "Questions",
                columns: new[] { "Id", "QuestionStatement", "Stamp", "isActive" },
                values: new object[] { 1, "Which is the national flower of Poland?", new DateTime(2021, 3, 15, 1, 14, 9, 430, DateTimeKind.Local).AddTicks(1360), true });

            migrationBuilder.InsertData(
                table: "Questions",
                columns: new[] { "Id", "QuestionStatement", "Stamp", "isActive" },
                values: new object[] { 2, "Which city is now the capital of Poland?", new DateTime(2021, 3, 15, 1, 14, 9, 431, DateTimeKind.Local).AddTicks(5252), true });

            migrationBuilder.InsertData(
                table: "Questions",
                columns: new[] { "Id", "QuestionStatement", "Stamp", "isActive" },
                values: new object[] { 3, "Which countries border Poland?", new DateTime(2021, 3, 15, 1, 14, 9, 431, DateTimeKind.Local).AddTicks(5312), true });

            migrationBuilder.InsertData(
                table: "QuestionsOptions",
                columns: new[] { "Id", "OptionStatement", "QuestionId", "Stamp", "isCorrect" },
                values: new object[,]
                {
                    { 1, "Lily", 1, new DateTime(2021, 3, 15, 1, 14, 9, 439, DateTimeKind.Local).AddTicks(3916), false },
                    { 2, "Corn Poppy", 1, new DateTime(2021, 3, 15, 1, 14, 9, 439, DateTimeKind.Local).AddTicks(5374), true },
                    { 3, "Lavender", 1, new DateTime(2021, 3, 15, 1, 14, 9, 439, DateTimeKind.Local).AddTicks(6135), false },
                    { 4, "Flor De Maga", 1, new DateTime(2021, 3, 15, 1, 14, 9, 439, DateTimeKind.Local).AddTicks(6146), false },
                    { 5, "Astana", 2, new DateTime(2021, 3, 15, 1, 14, 9, 439, DateTimeKind.Local).AddTicks(6149), false },
                    { 6, "Warsaw", 2, new DateTime(2021, 3, 15, 1, 14, 9, 439, DateTimeKind.Local).AddTicks(6161), true },
                    { 7, "Krakow", 2, new DateTime(2021, 3, 15, 1, 14, 9, 439, DateTimeKind.Local).AddTicks(6199), false },
                    { 8, "Bucharest", 2, new DateTime(2021, 3, 15, 1, 14, 9, 439, DateTimeKind.Local).AddTicks(6202), false },
                    { 9, "Germany", 3, new DateTime(2021, 3, 15, 1, 14, 9, 439, DateTimeKind.Local).AddTicks(6205), true },
                    { 10, "Ukraine", 3, new DateTime(2021, 3, 15, 1, 14, 9, 439, DateTimeKind.Local).AddTicks(6301), true },
                    { 11, "Romania", 3, new DateTime(2021, 3, 15, 1, 14, 9, 439, DateTimeKind.Local).AddTicks(6306), false },
                    { 12, "Italy ", 3, new DateTime(2021, 3, 15, 1, 14, 9, 439, DateTimeKind.Local).AddTicks(6308), false }
                });

            migrationBuilder.CreateIndex(
                name: "IX_QuestionsOptions_QuestionId",
                table: "QuestionsOptions",
                column: "QuestionId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Answers");

            migrationBuilder.DropTable(
                name: "QuestionsOptions");

            migrationBuilder.DropTable(
                name: "Questions");
        }
    }
}
