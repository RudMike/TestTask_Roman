using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace TestTask_Roman.Migrations
{
    /// <inheritdoc />
    public partial class SeedMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Кабинеты",
                columns: table => new
                {
                    Номер = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Кабинеты", x => x.Номер);
                });

            migrationBuilder.CreateTable(
                name: "Специализации",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Название = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Специализации", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Участки",
                columns: table => new
                {
                    Номер = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Участки", x => x.Номер);
                });

            migrationBuilder.CreateTable(
                name: "Врачи",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Фамилия = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    Имя = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    Отчество = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: true),
                    Кабинет = table.Column<int>(type: "int", nullable: true),
                    Специализация = table.Column<int>(type: "int", nullable: true),
                    Участок = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Врачи", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Врачи_Кабинеты_Кабинет",
                        column: x => x.Кабинет,
                        principalTable: "Кабинеты",
                        principalColumn: "Номер",
                        onDelete: ReferentialAction.SetNull);
                    table.ForeignKey(
                        name: "FK_Врачи_Специализации_Специализация",
                        column: x => x.Специализация,
                        principalTable: "Специализации",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.SetNull);
                    table.ForeignKey(
                        name: "FK_Врачи_Участки_Участок",
                        column: x => x.Участок,
                        principalTable: "Участки",
                        principalColumn: "Номер",
                        onDelete: ReferentialAction.SetNull);
                });

            migrationBuilder.CreateTable(
                name: "Пациенты",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Фамилия = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    Имя = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    Отчество = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: true),
                    Адрес = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Датарождения = table.Column<DateTime>(name: "Дата рождения", type: "datetime2(0)", precision: 0, nullable: false),
                    Пол = table.Column<string>(type: "nvarchar(5)", maxLength: 5, nullable: false),
                    Участок = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Пациенты", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Пациенты_Участки_Участок",
                        column: x => x.Участок,
                        principalTable: "Участки",
                        principalColumn: "Номер",
                        onDelete: ReferentialAction.SetNull);
                });

            migrationBuilder.InsertData(
                table: "Кабинеты",
                column: "Номер",
                values: new object[]
                {
                    10,
                    11,
                    12,
                    13,
                    14,
                    15
                });

            migrationBuilder.InsertData(
                table: "Специализации",
                columns: new[] { "Id", "Название" },
                values: new object[,]
                {
                    { 1, "Терапевт" },
                    { 2, "Хирург" },
                    { 3, "Травматолог" },
                    { 4, "Отоларинголог" },
                    { 5, "Дерматолог" }
                });

            migrationBuilder.InsertData(
                table: "Участки",
                column: "Номер",
                values: new object[]
                {
                    100,
                    200,
                    300,
                    400,
                    500,
                    600
                });

            migrationBuilder.InsertData(
                table: "Врачи",
                columns: new[] { "Id", "Участок", "Имя", "Фамилия", "Отчество", "Кабинет", "Специализация" },
                values: new object[,]
                {
                    { 1, 100, "Игорь", "Иванов", "Александрович", 10, 1 },
                    { 2, 200, "Дмитрий", "Петров", "Сергеевич", 12, 2 },
                    { 3, 300, "Елена", "Сидорова", "Ивановна", 13, 3 },
                    { 4, 400, "Андрей", "Кузнецов", "Петрович", 14, 4 },
                    { 5, 500, "Ольга", "Николаева", "Алексеевна", 15, 5 },
                    { 6, 100, "Алексей", "Смирнов", "Дмитриевич", 11, 2 },
                    { 7, 200, "Марина", "Волкова", "Сергеевна", 12, 3 },
                    { 8, 300, "Николай", "Козлов", "Андреевич", 13, 4 },
                    { 9, null, "Екатерина", "Морозова", "Владимировна", 14, 5 },
                    { 10, null, "Илья", "Павлов", "Геннадьевич", 15, 1 }
                });

            migrationBuilder.InsertData(
                table: "Пациенты",
                columns: new[] { "Id", "Адрес", "Участок", "Дата рождения", "Имя", "Фамилия", "Отчество", "Пол" },
                values: new object[,]
                {
                    { 1, "ул. Пушкина, д. 10", 100, new DateTime(1980, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Иван", "Иванов", "Иванович", "Муж" },
                    { 2, "ул. Лермонтова, д. 5", 200, new DateTime(1990, 2, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), "Мария", "Петрова", "Алексеевна", "Жен" },
                    { 3, "ул. Гоголя, д. 15", 300, new DateTime(1975, 3, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), "Алексей", "Сидоров", "Петрович", "Муж" },
                    { 4, "ул. Тургенева, д. 20", 400, new DateTime(1985, 4, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), "Елена", "Кузнецова", "Сергеевна", "Жен" },
                    { 5, "ул. Чехова, д. 25", 500, new DateTime(1995, 5, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), "Игорь", "Николаев", "Александрович", "Муж" },
                    { 6, "ул. Достоевского, д. 30", 100, new DateTime(1984, 6, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), "Анна", "Смирнова", "Андреевна", "Жен" },
                    { 7, "ул. Пастернака, д. 35", 200, new DateTime(1979, 7, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), "Сергей", "Волков", "Николаевич", "Муж" },
                    { 8, "ул. Есенина, д. 40", 300, new DateTime(1991, 8, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), "Ольга", "Козлова", "Викторовна", "Жен" },
                    { 9, "ул. Шолохова, д. 45", 400, new DateTime(1981, 9, 9, 0, 0, 0, 0, DateTimeKind.Unspecified), "Дмитрий", "Морозов", "Игоревич", "Муж" },
                    { 10, "ул. Ломоносова, д. 50", 500, new DateTime(1992, 10, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), "Екатерина", "Андреева", "Дмитриевна", "Жен" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Врачи_Кабинет",
                table: "Врачи",
                column: "Кабинет");

            migrationBuilder.CreateIndex(
                name: "IX_Врачи_Специализация",
                table: "Врачи",
                column: "Специализация");

            migrationBuilder.CreateIndex(
                name: "IX_Врачи_Участок",
                table: "Врачи",
                column: "Участок");

            migrationBuilder.CreateIndex(
                name: "IX_Пациенты_Участок",
                table: "Пациенты",
                column: "Участок");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Врачи");

            migrationBuilder.DropTable(
                name: "Пациенты");

            migrationBuilder.DropTable(
                name: "Кабинеты");

            migrationBuilder.DropTable(
                name: "Специализации");

            migrationBuilder.DropTable(
                name: "Участки");
        }
    }
}
