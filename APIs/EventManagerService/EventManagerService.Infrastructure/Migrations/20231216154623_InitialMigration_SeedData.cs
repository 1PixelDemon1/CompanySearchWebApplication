using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace EventManagerService.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class InitialMigration_SeedData : Migration
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
                    CreatorId = table.Column<int>(type: "integer", nullable: false),
                    UserEventId = table.Column<int>(type: "integer", nullable: true)
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
                        name: "FK_UserEvents_Users_CreatorId",
                        column: x => x.CreatorId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CommercialEvents",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false),
                    CreatorId = table.Column<int>(type: "integer", nullable: false),
                    Price = table.Column<decimal>(type: "numeric", nullable: false),
                    CommercialEventId = table.Column<int>(type: "integer", nullable: true),
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
                        name: "FK_CommercialEvents_CommercialUsers_CreatorId",
                        column: x => x.CreatorId,
                        principalTable: "CommercialUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CommercialEvents_UserEvents_UserEventId",
                        column: x => x.UserEventId,
                        principalTable: "UserEvents",
                        principalColumn: "Id");
                });

            migrationBuilder.InsertData(
                table: "BaseEvent",
                columns: new[] { "Id", "CreateTime", "DeadLine", "Description", "EventDateTime", "EventDuration", "GenderRules", "Location", "MaxAge", "MaxUsers", "MinAge", "MinUsers", "UpdateTime" },
                values: new object[,]
                {
                    { 1, new DateTime(2023, 12, 16, 20, 46, 23, 120, DateTimeKind.Local).AddTicks(1783), new DateTime(2023, 12, 26, 20, 46, 23, 120, DateTimeKind.Local).AddTicks(1792), "Посещение кинотеатра Джаз.Синема для просмотра фильма \"Человек паук 6\"", new DateTime(2023, 12, 27, 20, 46, 23, 120, DateTimeKind.Local).AddTicks(1797), new TimeSpan(0, 2, 56, 0, 0), 0, "г.Магнитогорск ул.Герцена д.6", -1, 80, 16, 1, new DateTime(2023, 12, 16, 20, 46, 23, 120, DateTimeKind.Local).AddTicks(1792) },
                    { 2, new DateTime(2023, 12, 16, 20, 46, 23, 120, DateTimeKind.Local).AddTicks(1804), new DateTime(2023, 12, 26, 20, 46, 23, 120, DateTimeKind.Local).AddTicks(1805), "Посещение кинотеатра Джаз.Синема для просмотра фильма \"Человек паук 6\", посещение фестиваля после", new DateTime(2023, 12, 27, 20, 46, 23, 120, DateTimeKind.Local).AddTicks(1806), new TimeSpan(0, 9, 36, 0, 0), 0, "г.Магнитогорск пр.Ленина д.72", -1, 80, 16, 1, new DateTime(2023, 12, 16, 20, 46, 23, 120, DateTimeKind.Local).AddTicks(1805) },
                    { 3, new DateTime(2023, 12, 16, 20, 46, 23, 120, DateTimeKind.Local).AddTicks(1825), new DateTime(2023, 12, 21, 20, 46, 23, 120, DateTimeKind.Local).AddTicks(1826), "Проведение публичной конференции", new DateTime(2023, 12, 22, 20, 46, 23, 120, DateTimeKind.Local).AddTicks(1826), new TimeSpan(0, 2, 0, 0, 0), 0, "г.Магнитогорск пр.Ленина д.130", -1, -1, 18, 20, new DateTime(2023, 12, 16, 20, 46, 23, 120, DateTimeKind.Local).AddTicks(1825) },
                    { 4, new DateTime(2023, 12, 16, 20, 46, 23, 120, DateTimeKind.Local).AddTicks(1830), new DateTime(2023, 12, 31, 20, 46, 23, 120, DateTimeKind.Local).AddTicks(1831), "Проведение IT - конференции", new DateTime(2024, 1, 1, 20, 46, 23, 120, DateTimeKind.Local).AddTicks(1831), new TimeSpan(0, 2, 30, 0, 0), 0, "г.Магнитогорск пр.Ленина д.130", -1, -1, 18, 0, new DateTime(2023, 12, 16, 20, 46, 23, 120, DateTimeKind.Local).AddTicks(1830) }
                });

            migrationBuilder.InsertData(
                table: "CommercialUsers",
                columns: new[] { "Id", "Name", "PersonalAccount" },
                values: new object[,]
                {
                    { 5, "VIMers corp", "70ББ000584" },
                    { 6, "Банк Пеньков", "70ББ000585" }
                });

            migrationBuilder.InsertData(
                table: "EventCategories",
                columns: new[] { "Id", "Name", "ParentCategoryId" },
                values: new object[,]
                {
                    { 1, "Фестиваль", null },
                    { 3, "Концерт", null },
                    { 5, "Поход в кино", null },
                    { 6, "Конференция", null }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Age", "Email", "Gender", "MyProperty", "Name", "PhoneNumber" },
                values: new object[,]
                {
                    { 1, 21, "testmail@gmail.com", 0, 0, "Анатолий", "+71234567890" },
                    { 2, 45, "testmail1@gmail.com", 0, 0, "Евгений", "+71234567891" },
                    { 3, 32, "testmail2@gmail.com", 1, 0, "Анастасия", "+71234567892" },
                    { 4, 15, "testmail3@gmail.com", 1, 0, "Валентина", "+71234567893" }
                });

            migrationBuilder.InsertData(
                table: "CommercialEvents",
                columns: new[] { "Id", "CommercialEventId", "CreatorId", "Price", "UserEventId" },
                values: new object[,]
                {
                    { 3, null, 5, 0m, null },
                    { 4, null, 6, 0m, null }
                });

            migrationBuilder.InsertData(
                table: "EventCategories",
                columns: new[] { "Id", "Name", "ParentCategoryId" },
                values: new object[,]
                {
                    { 2, "Фестиваль волонтеров", 1 },
                    { 4, "Праздничный концерт", 3 }
                });

            migrationBuilder.InsertData(
                table: "UserEvents",
                columns: new[] { "Id", "CreatorId", "UserEventId" },
                values: new object[,]
                {
                    { 1, 1, null },
                    { 2, 3, null }
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
                name: "IX_CommercialEvents_CreatorId",
                table: "CommercialEvents",
                column: "CreatorId");

            migrationBuilder.CreateIndex(
                name: "IX_CommercialEvents_UserEventId",
                table: "CommercialEvents",
                column: "UserEventId");

            migrationBuilder.CreateIndex(
                name: "IX_EventCategories_ParentCategoryId",
                table: "EventCategories",
                column: "ParentCategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_UserEvents_CreatorId",
                table: "UserEvents",
                column: "CreatorId");

            migrationBuilder.CreateIndex(
                name: "IX_UserEvents_UserEventId",
                table: "UserEvents",
                column: "UserEventId");
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
