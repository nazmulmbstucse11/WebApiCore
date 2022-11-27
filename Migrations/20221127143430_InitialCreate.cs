using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace WebApiFirst.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ExceptionTable",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    ExceptionType = table.Column<string>(nullable: true),
                    Logtime = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ExceptionTable", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PersonTable",
                columns: table => new
                {
                    Name = table.Column<string>(nullable: false),
                    Mobile = table.Column<string>(nullable: true),
                    Address = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PersonTable", x => x.Name);
                });

            migrationBuilder.CreateTable(
                name: "RequestTable",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Logtime = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RequestTable", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TaskTable",
                columns: table => new
                {
                    TaskId = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    TaskName = table.Column<string>(nullable: true),
                    Date = table.Column<string>(nullable: true),
                    RequesterName = table.Column<string>(nullable: true),
                    RequesterMobile = table.Column<string>(nullable: true),
                    RequesterAddress = table.Column<string>(nullable: true),
                    ExecutorName = table.Column<string>(nullable: true),
                    ExecutorMobile = table.Column<string>(nullable: true),
                    ExecutorAddress = table.Column<string>(nullable: true),
                    isComplete = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TaskTable", x => x.TaskId);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ExceptionTable");

            migrationBuilder.DropTable(
                name: "PersonTable");

            migrationBuilder.DropTable(
                name: "RequestTable");

            migrationBuilder.DropTable(
                name: "TaskTable");
        }
    }
}
