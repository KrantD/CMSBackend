using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CMSWebApi.Migrations
{
    public partial class init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "claim",
                columns: table => new
                {
                    cId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Amount = table.Column<double>(type: "float", nullable: false),
                    ClaimDate = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_claim", x => x.cId);
                });

            migrationBuilder.CreateTable(
                name: "members",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PasswordHash = table.Column<byte[]>(type: "varbinary(max)", nullable: true),
                    Key = table.Column<byte[]>(type: "varbinary(max)", nullable: true),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    State = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Country = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EmailId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Dob = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Status = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Role = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_members", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "plans",
                columns: table => new
                {
                    pId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    pName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Duration = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Amount = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    StartDate = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EndDate = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_plans", x => x.pId);
                });

            migrationBuilder.CreateTable(
                name: "memberPlans",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MId = table.Column<int>(type: "int", nullable: false),
                    PId = table.Column<int>(type: "int", nullable: false),
                    CId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_memberPlans", x => x.Id);
                    table.ForeignKey(
                        name: "FK_memberPlans_claim_CId",
                        column: x => x.CId,
                        principalTable: "claim",
                        principalColumn: "cId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_memberPlans_members_MId",
                        column: x => x.MId,
                        principalTable: "members",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_memberPlans_plans_PId",
                        column: x => x.PId,
                        principalTable: "plans",
                        principalColumn: "pId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "claim",
                columns: new[] { "cId", "Amount", "ClaimDate" },
                values: new object[,]
                {
                    { 1, 20000.0, "22-10-2022" },
                    { 2, 30000.0, "23-10-2022" }
                });

            migrationBuilder.InsertData(
                table: "members",
                columns: new[] { "Id", "Address", "Country", "Dob", "EmailId", "Key", "Password", "PasswordHash", "PhoneNumber", "Role", "State", "Status", "UserName" },
                values: new object[,]
                {
                    { 101, "Ahmedabad", "India", "2-10-1869", "Babita@123", new byte[] { 146, 153, 174, 131, 180, 171, 40, 53, 189, 101, 141, 58, 109, 185, 69, 237, 113, 43, 29, 69, 121, 116, 35, 84, 125, 73, 233, 199, 170, 198, 208, 128, 44, 194, 244, 53, 224, 178, 77, 8, 164, 102, 102, 58, 27, 49, 165, 227, 15, 33, 246, 251, 217, 131, 29, 179, 52, 103, 160, 223, 41, 75, 138, 161, 137, 52, 13, 209, 118, 232, 22, 38, 80, 167, 13, 81, 226, 105, 141, 1, 249, 117, 113, 145, 227, 78, 157, 239, 166, 56, 40, 109, 243, 77, 172, 78, 161, 59, 80, 208, 37, 100, 88, 95, 243, 117, 197, 124, 96, 171, 113, 97, 242, 216, 124, 189, 146, 90, 213, 62, 165, 194, 138, 104, 173, 79, 77, 204 }, "Babita", new byte[] { 196, 24, 221, 126, 58, 148, 87, 211, 253, 67, 208, 104, 238, 122, 106, 96, 74, 240, 13, 200, 206, 253, 238, 75, 114, 143, 204, 210, 171, 171, 6, 105, 224, 214, 96, 172, 28, 125, 152, 109, 109, 210, 45, 42, 57, 83, 216, 66, 70, 248, 160, 248, 41, 103, 118, 40, 122, 37, 193, 151, 250, 71, 128, 45 }, "66666666", null, "Gujrat", null, "Jethalal" },
                    { 102, "Mumbai", "India", "3-10-1868", "Madhavi@123", new byte[] { 146, 153, 174, 131, 180, 171, 40, 53, 189, 101, 141, 58, 109, 185, 69, 237, 113, 43, 29, 69, 121, 116, 35, 84, 125, 73, 233, 199, 170, 198, 208, 128, 44, 194, 244, 53, 224, 178, 77, 8, 164, 102, 102, 58, 27, 49, 165, 227, 15, 33, 246, 251, 217, 131, 29, 179, 52, 103, 160, 223, 41, 75, 138, 161, 137, 52, 13, 209, 118, 232, 22, 38, 80, 167, 13, 81, 226, 105, 141, 1, 249, 117, 113, 145, 227, 78, 157, 239, 166, 56, 40, 109, 243, 77, 172, 78, 161, 59, 80, 208, 37, 100, 88, 95, 243, 117, 197, 124, 96, 171, 113, 97, 242, 216, 124, 189, 146, 90, 213, 62, 165, 194, 138, 104, 173, 79, 77, 204 }, "Madhavi", new byte[] { 154, 100, 145, 131, 82, 93, 7, 41, 34, 160, 142, 64, 248, 211, 59, 136, 118, 126, 160, 36, 34, 14, 134, 160, 36, 198, 22, 54, 11, 64, 210, 169, 16, 21, 0, 6, 173, 58, 122, 110, 42, 107, 234, 142, 180, 19, 215, 80, 85, 135, 253, 127, 230, 228, 226, 246, 149, 36, 182, 95, 158, 62, 255, 27 }, "66666667", null, "Maharashtra", null, "Bhide" }
                });

            migrationBuilder.InsertData(
                table: "plans",
                columns: new[] { "pId", "Amount", "Duration", "EndDate", "StartDate", "pName" },
                values: new object[,]
                {
                    { 1, "1000000", "1 years", null, null, "Jeevan Raksha Yojna" },
                    { 2, "200000", "5 years", null, null, "Health Security Plan " }
                });

            migrationBuilder.InsertData(
                table: "memberPlans",
                columns: new[] { "Id", "CId", "MId", "PId" },
                values: new object[] { 1, 1, 101, 1 });

            migrationBuilder.InsertData(
                table: "memberPlans",
                columns: new[] { "Id", "CId", "MId", "PId" },
                values: new object[] { 2, 1, 102, 2 });

            migrationBuilder.CreateIndex(
                name: "IX_memberPlans_CId",
                table: "memberPlans",
                column: "CId");

            migrationBuilder.CreateIndex(
                name: "IX_memberPlans_MId",
                table: "memberPlans",
                column: "MId");

            migrationBuilder.CreateIndex(
                name: "IX_memberPlans_PId",
                table: "memberPlans",
                column: "PId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "memberPlans");

            migrationBuilder.DropTable(
                name: "claim");

            migrationBuilder.DropTable(
                name: "members");

            migrationBuilder.DropTable(
                name: "plans");
        }
    }
}
