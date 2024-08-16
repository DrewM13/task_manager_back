using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace task_manager.Migrations
{
    public partial class initialMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "tCollaborator",
                columns: table => new
                {
                    IDCollaborator = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    vchCollaboratorName = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false),
                    dtmCreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    dtmUpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    dtmDeletedAt = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tCollaborator", x => x.IDCollaborator);
                });

            migrationBuilder.CreateTable(
                name: "tProject",
                columns: table => new
                {
                    IDProject = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    vchProjectName = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false),
                    dtmCreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    dtmUpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    dtmDeletedAt = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tProject", x => x.IDProject);
                });

            migrationBuilder.CreateTable(
                name: "tUser",
                columns: table => new
                {
                    IDUser = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    vchUserName = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false),
                    vchPassword = table.Column<string>(type: "nvarchar(512)", maxLength: 512, nullable: false),
                    dtmCreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    dtmUpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    dtmDeletedAt = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tUser", x => x.IDUser);
                });

            migrationBuilder.CreateTable(
                name: "tTask",
                columns: table => new
                {
                    IDTask = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    vchTaskName = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false),
                    vchDescription = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IDProject = table.Column<long>(type: "bigint", nullable: false),
                    dtmCreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    dtmUpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    dtmDeletedAt = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tTask", x => x.IDTask);
                    table.ForeignKey(
                        name: "FK_tTask_tProject_IDProject",
                        column: x => x.IDProject,
                        principalTable: "tProject",
                        principalColumn: "IDProject",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "tTaskCollaborator",
                columns: table => new
                {
                    IDTaskCollaborator = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IDTask = table.Column<long>(type: "bigint", nullable: false),
                    IDCollaborator = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tTaskCollaborator", x => x.IDTaskCollaborator);
                    table.ForeignKey(
                        name: "FK_tTaskCollaborator_tCollaborator_IDCollaborator",
                        column: x => x.IDCollaborator,
                        principalTable: "tCollaborator",
                        principalColumn: "IDCollaborator",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_tTaskCollaborator_tTask_IDTask",
                        column: x => x.IDTask,
                        principalTable: "tTask",
                        principalColumn: "IDTask",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "tTimeTracker",
                columns: table => new
                {
                    IDTimeTracker = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    dtmStart = table.Column<DateTime>(type: "datetime2", nullable: false),
                    dtmEnd = table.Column<DateTime>(type: "datetime2", nullable: false),
                    vchTimeZoneID = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    IDTask = table.Column<long>(type: "bigint", nullable: false),
                    IDCollaborator = table.Column<long>(type: "bigint", nullable: false),
                    dtmCreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    dtmUpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    dtmDeletedAt = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tTimeTracker", x => x.IDTimeTracker);
                    table.ForeignKey(
                        name: "FK_tTimeTracker_tCollaborator_IDCollaborator",
                        column: x => x.IDCollaborator,
                        principalTable: "tCollaborator",
                        principalColumn: "IDCollaborator",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_tTimeTracker_tTask_IDTask",
                        column: x => x.IDTask,
                        principalTable: "tTask",
                        principalColumn: "IDTask",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_tTask_IDProject",
                table: "tTask",
                column: "IDProject");

            migrationBuilder.CreateIndex(
                name: "IX_tTaskCollaborator_IDCollaborator",
                table: "tTaskCollaborator",
                column: "IDCollaborator");

            migrationBuilder.CreateIndex(
                name: "IX_tTaskCollaborator_IDTask",
                table: "tTaskCollaborator",
                column: "IDTask");

            migrationBuilder.CreateIndex(
                name: "IX_tTimeTracker_IDCollaborator",
                table: "tTimeTracker",
                column: "IDCollaborator");

            migrationBuilder.CreateIndex(
                name: "IX_tTimeTracker_IDTask",
                table: "tTimeTracker",
                column: "IDTask");

            migrationBuilder.CreateIndex(
                name: "IX_tUser_vchUserName",
                table: "tUser",
                column: "vchUserName",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "tTaskCollaborator");

            migrationBuilder.DropTable(
                name: "tTimeTracker");

            migrationBuilder.DropTable(
                name: "tUser");

            migrationBuilder.DropTable(
                name: "tCollaborator");

            migrationBuilder.DropTable(
                name: "tTask");

            migrationBuilder.DropTable(
                name: "tProject");
        }
    }
}
