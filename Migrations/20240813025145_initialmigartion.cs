using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace task_manager.Migrations
{
    public partial class initialmigartion : Migration
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
                name: "tUserCollaborator",
                columns: table => new
                {
                    IDUserCollaborator = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    tUser = table.Column<long>(type: "bigint", nullable: false),
                    tCollaborator = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tUserCollaborator", x => x.IDUserCollaborator);
                    table.ForeignKey(
                        name: "FK_tUserCollaborator_tCollaborator_tCollaborator",
                        column: x => x.tCollaborator,
                        principalTable: "tCollaborator",
                        principalColumn: "IDCollaborator",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_tUserCollaborator_tUser_tUser",
                        column: x => x.tUser,
                        principalTable: "tUser",
                        principalColumn: "IDUser",
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
                    vchTimeZoneID = table.Column<int>(type: "int", maxLength: 200, nullable: false),
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

            migrationBuilder.CreateIndex(
                name: "IX_tUserCollaborator_tCollaborator",
                table: "tUserCollaborator",
                column: "tCollaborator");

            migrationBuilder.CreateIndex(
                name: "IX_tUserCollaborator_tUser",
                table: "tUserCollaborator",
                column: "tUser");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "tTimeTracker");

            migrationBuilder.DropTable(
                name: "tUserCollaborator");

            migrationBuilder.DropTable(
                name: "tTask");

            migrationBuilder.DropTable(
                name: "tCollaborator");

            migrationBuilder.DropTable(
                name: "tUser");

            migrationBuilder.DropTable(
                name: "tProject");
        }
    }
}
