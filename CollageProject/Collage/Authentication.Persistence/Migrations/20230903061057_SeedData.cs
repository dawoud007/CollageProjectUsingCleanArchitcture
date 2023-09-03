using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Collage.Persistence.Migrations
{
    public partial class SeedData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "collageusers",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Gender = table.Column<int>(type: "int", nullable: false, defaultValue: 0),
                    Role = table.Column<int>(type: "int", nullable: false),
                    UserName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NormalizedUserName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NormalizedEmail = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EmailConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    PasswordHash = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SecurityStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    TwoFactorEnabled = table.Column<bool>(type: "bit", nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    LockoutEnabled = table.Column<bool>(type: "bit", nullable: false),
                    AccessFailedCount = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_collageusers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Employees",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreationDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Employees", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Faculties",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreationDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Faculties", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Boss = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreationDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Professors",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FacultyId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    CreationDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Professors", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Professors_Faculties_FacultyId",
                        column: x => x.FacultyId,
                        principalTable: "Faculties",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Students",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Age = table.Column<int>(type: "int", nullable: false),
                    Level = table.Column<int>(type: "int", nullable: false),
                    FacultyId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    CreationDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Students", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Students_Faculties_FacultyId",
                        column: x => x.FacultyId,
                        principalTable: "Faculties",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Workers",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    JobTitle = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FacultyId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    CreationDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Workers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Workers_Faculties_FacultyId",
                        column: x => x.FacultyId,
                        principalTable: "Faculties",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "CollageDepartments",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ManagerId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    CreationDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CollageDepartments", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CollageDepartments_Professors_ManagerId",
                        column: x => x.ManagerId,
                        principalTable: "Professors",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Subjects",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Code = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ProfessorId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    CreationDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Subjects", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Subjects_Professors_ProfessorId",
                        column: x => x.ProfessorId,
                        principalTable: "Professors",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "StudentSubjects",
                columns: table => new
                {
                    StudentsId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    SubjectsId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StudentSubjects", x => new { x.StudentsId, x.SubjectsId });
                    table.ForeignKey(
                        name: "FK_StudentSubjects_Students_StudentsId",
                        column: x => x.StudentsId,
                        principalTable: "Students",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_StudentSubjects_Subjects_SubjectsId",
                        column: x => x.SubjectsId,
                        principalTable: "Subjects",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Faculties",
                columns: new[] { "Id", "CreationDate", "Name" },
                values: new object[,]
                {
                    { new Guid("216066ed-2d52-4b53-90e6-1a99cd00e3a6"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Faculty 1" },
                    { new Guid("3eac9c98-be42-4559-96c5-a9f6b61184b6"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Faculty 3" },
                    { new Guid("fba2f28c-554e-4351-a140-0342a573a378"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Faculty 2" }
                });

            migrationBuilder.InsertData(
                table: "collageusers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "Gender", "LockoutEnabled", "LockoutEnd", "Name", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "Role", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "6b5f6a8e-fc0a-4693-8065-e8ba319dd7a8", 0, "9639730c-f142-4c62-b4e8-eaa7291f64fa", "Leqaa.Technical@gmail.com", true, 1, false, null, "Leqaa", "LEQAA.TECHNICAL@GMAIL.COM", "LEQAA", "AQAAAAEAACcQAAAAECvJltgq3Z8E2KUyqlb54O2IGTRSQw+c1JLRjN3vnSw5bIHVN97Of9Aamp3/+HV22A==", null, false, 0, "cd2b7bf5-d4e9-4485-a0c4-1b7220c8d27e", false, "Leqaa" });

            migrationBuilder.InsertData(
                table: "Professors",
                columns: new[] { "Id", "CreationDate", "FacultyId", "Name" },
                values: new object[] { new Guid("1bb9ee09-27cf-4c9b-86eb-c3eef0bca5cc"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("fba2f28c-554e-4351-a140-0342a573a378"), "Professor 2" });

            migrationBuilder.InsertData(
                table: "Professors",
                columns: new[] { "Id", "CreationDate", "FacultyId", "Name" },
                values: new object[] { new Guid("291b2fad-15ff-45e3-9c10-b75a4be17be0"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("216066ed-2d52-4b53-90e6-1a99cd00e3a6"), "Professor 1" });

            migrationBuilder.InsertData(
                table: "Professors",
                columns: new[] { "Id", "CreationDate", "FacultyId", "Name" },
                values: new object[] { new Guid("6f073580-7760-4c58-a9fd-c2737e3a054f"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("3eac9c98-be42-4559-96c5-a9f6b61184b6"), "Professor 3" });

            migrationBuilder.CreateIndex(
                name: "IX_CollageDepartments_ManagerId",
                table: "CollageDepartments",
                column: "ManagerId",
                unique: true,
                filter: "[ManagerId] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Professors_FacultyId",
                table: "Professors",
                column: "FacultyId");

            migrationBuilder.CreateIndex(
                name: "IX_Students_FacultyId",
                table: "Students",
                column: "FacultyId");

            migrationBuilder.CreateIndex(
                name: "IX_StudentSubjects_SubjectsId",
                table: "StudentSubjects",
                column: "SubjectsId");

            migrationBuilder.CreateIndex(
                name: "IX_Subjects_ProfessorId",
                table: "Subjects",
                column: "ProfessorId");

            migrationBuilder.CreateIndex(
                name: "IX_Workers_FacultyId",
                table: "Workers",
                column: "FacultyId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CollageDepartments");

            migrationBuilder.DropTable(
                name: "collageusers");

            migrationBuilder.DropTable(
                name: "Employees");

            migrationBuilder.DropTable(
                name: "Products");

            migrationBuilder.DropTable(
                name: "StudentSubjects");

            migrationBuilder.DropTable(
                name: "Workers");

            migrationBuilder.DropTable(
                name: "Students");

            migrationBuilder.DropTable(
                name: "Subjects");

            migrationBuilder.DropTable(
                name: "Professors");

            migrationBuilder.DropTable(
                name: "Faculties");
        }
    }
}
