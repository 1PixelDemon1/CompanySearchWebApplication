using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace EventManagerService.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class Initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "BaseEvent",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    CreateTime = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    UpdateTime = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    EventDateTime = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    Location = table.Column<string>(type: "text", nullable: false),
                    Description = table.Column<string>(type: "text", nullable: false),
                    EventDuration = table.Column<TimeSpan>(type: "interval", nullable: true),
                    GenderRules = table.Column<int>(type: "integer", nullable: false),
                    DeadLine = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    MinUsers = table.Column<int>(type: "integer", nullable: true),
                    MaxUsers = table.Column<int>(type: "integer", nullable: true),
                    MinAge = table.Column<int>(type: "integer", nullable: true),
                    MaxAge = table.Column<int>(type: "integer", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BaseEvent", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "CommercialUsers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    PersonalAccount = table.Column<string>(type: "text", nullable: true),
                    Name = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CommercialUsers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "EventCategories",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "text", nullable: false),
                    ParentCategoryId = table.Column<int>(type: "integer", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EventCategories", x => x.Id);
                    table.ForeignKey(
                        name: "FK_EventCategories_EventCategories_ParentCategoryId",
                        column: x => x.ParentCategoryId,
                        principalTable: "EventCategories",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Age = table.Column<int>(type: "integer", nullable: false),
                    Gender = table.Column<int>(type: "integer", nullable: false),
                    MyProperty = table.Column<int>(type: "integer", nullable: false),
                    PhoneNumber = table.Column<string>(type: "text", nullable: true),
                    Email = table.Column<string>(type: "text", nullable: true),
                    Name = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "BaseEventEventCategory",
                columns: table => new
                {
                    CategoriesId = table.Column<int>(type: "integer", nullable: false),
                    EventsId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BaseEventEventCategory", x => new { x.CategoriesId, x.EventsId });
                    table.ForeignKey(
                        name: "FK_BaseEventEventCategory_BaseEvent_EventsId",
                        column: x => x.EventsId,
                        principalTable: "BaseEvent",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_BaseEventEventCategory_EventCategories_CategoriesId",
                        column: x => x.CategoriesId,
                        principalTable: "EventCategories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "BaseEventUser",
                columns: table => new
                {
                    RegisteredUsersId = table.Column<int>(type: "integer", nullable: false),
                    SignedEventsId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BaseEventUser", x => new { x.RegisteredUsersId, x.SignedEventsId });
                    table.ForeignKey(
                        name: "FK_BaseEventUser_BaseEvent_SignedEventsId",
                        column: x => x.SignedEventsId,
                        principalTable: "BaseEvent",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_BaseEventUser_Users_RegisteredUsersId",
                        column: x => x.RegisteredUsersId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UserEvents",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false),
                    UserEventId = table.Column<int>(type: "integer", nullable: true),
                    UserId = table.Column<int>(type: "integer", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserEvents", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UserEvents_BaseEvent_Id",
                        column: x => x.Id,
                        principalTable: "BaseEvent",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UserEvents_UserEvents_UserEventId",
                        column: x => x.UserEventId,
                        principalTable: "UserEvents",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_UserEvents_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "CommercialEvents",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false),
                    Price = table.Column<decimal>(type: "numeric", nullable: false),
                    CommercialEventId = table.Column<int>(type: "integer", nullable: true),
                    CommercialUserId = table.Column<int>(type: "integer", nullable: true),
                    UserEventId = table.Column<int>(type: "integer", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CommercialEvents", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CommercialEvents_BaseEvent_Id",
                        column: x => x.Id,
                        principalTable: "BaseEvent",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CommercialEvents_CommercialEvents_CommercialEventId",
                        column: x => x.CommercialEventId,
                        principalTable: "CommercialEvents",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_CommercialEvents_CommercialUsers_CommercialUserId",
                        column: x => x.CommercialUserId,
                        principalTable: "CommercialUsers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_CommercialEvents_UserEvents_UserEventId",
                        column: x => x.UserEventId,
                        principalTable: "UserEvents",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_BaseEventEventCategory_EventsId",
                table: "BaseEventEventCategory",
                column: "EventsId");

            migrationBuilder.CreateIndex(
                name: "IX_BaseEventUser_SignedEventsId",
                table: "BaseEventUser",
                column: "SignedEventsId");

            migrationBuilder.CreateIndex(
                name: "IX_CommercialEvents_CommercialEventId",
                table: "CommercialEvents",
                column: "CommercialEventId");

            migrationBuilder.CreateIndex(
                name: "IX_CommercialEvents_CommercialUserId",
                table: "CommercialEvents",
                column: "CommercialUserId");

            migrationBuilder.CreateIndex(
                name: "IX_CommercialEvents_UserEventId",
                table: "CommercialEvents",
                column: "UserEventId");

            migrationBuilder.CreateIndex(
                name: "IX_EventCategories_ParentCategoryId",
                table: "EventCategories",
                column: "ParentCategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_UserEvents_UserEventId",
                table: "UserEvents",
                column: "UserEventId");

            migrationBuilder.CreateIndex(
                name: "IX_UserEvents_UserId",
                table: "UserEvents",
                column: "UserId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BaseEventEventCategory");

            migrationBuilder.DropTable(
                name: "BaseEventUser");

            migrationBuilder.DropTable(
                name: "CommercialEvents");

            migrationBuilder.DropTable(
                name: "EventCategories");

            migrationBuilder.DropTable(
                name: "CommercialUsers");

            migrationBuilder.DropTable(
                name: "UserEvents");

            migrationBuilder.DropTable(
                name: "BaseEvent");

            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
