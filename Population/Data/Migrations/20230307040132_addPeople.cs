using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Population.Data.Migrations
{
    public partial class addPeople : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "peoples",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: true),
                    FatherName = table.Column<string>(nullable: true),
                    MotherName = table.Column<string>(nullable: true),
                    DateOfBirth = table.Column<string>(nullable: true),
                    BloodGroupId = table.Column<int>(nullable: false),
                    SSCBoardId = table.Column<int>(nullable: false),
                    HSCBoardId = table.Column<int>(nullable: false),
                    PresentAddress = table.Column<string>(nullable: true),
                    PermanentAddress = table.Column<string>(nullable: true),
                    MobileNo = table.Column<string>(nullable: true),
                    Email = table.Column<string>(nullable: true),
                    Image = table.Column<string>(nullable: true),
                    SSCNameOfSchool = table.Column<string>(nullable: true),
                    SSCYearOfPassing = table.Column<string>(nullable: true),
                    SSCResult = table.Column<string>(nullable: true),
                    HSCNameOfCollege = table.Column<string>(nullable: true),
                    HSCNameOfBoard = table.Column<string>(nullable: true),
                    HSCYearOfPassing = table.Column<string>(nullable: true),
                    HSCResult = table.Column<string>(nullable: true),
                    BSCDepartment = table.Column<string>(nullable: true),
                    University = table.Column<string>(nullable: true),
                    BSCYearOfPassing = table.Column<string>(nullable: true),
                    universityOrBoard = table.Column<string>(nullable: true),
                    BSCResult = table.Column<string>(nullable: true),
                    CareerObjective = table.Column<string>(nullable: true),
                    Skill = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_peoples", x => x.Id);
                    table.ForeignKey(
                        name: "FK_peoples_BloodGroups_BloodGroupId",
                        column: x => x.BloodGroupId,
                        principalTable: "BloodGroups",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_peoples_HSCBoards_HSCBoardId",
                        column: x => x.HSCBoardId,
                        principalTable: "HSCBoards",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_peoples_SSCBoards_SSCBoardId",
                        column: x => x.SSCBoardId,
                        principalTable: "SSCBoards",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_peoples_BloodGroupId",
                table: "peoples",
                column: "BloodGroupId");

            migrationBuilder.CreateIndex(
                name: "IX_peoples_HSCBoardId",
                table: "peoples",
                column: "HSCBoardId");

            migrationBuilder.CreateIndex(
                name: "IX_peoples_SSCBoardId",
                table: "peoples",
                column: "SSCBoardId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "peoples");
        }
    }
}
