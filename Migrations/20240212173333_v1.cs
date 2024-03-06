using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebApplication1.Migrations
{
    /// <inheritdoc />
    public partial class v1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Departments",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MGRssn = table.Column<int>(type: "int", nullable: true),
                    startdate = table.Column<DateOnly>(type: "date", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Departments", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Employees",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    fname = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    lname = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    bdate = table.Column<DateOnly>(type: "date", nullable: true),
                    address = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    salary = table.Column<decimal>(type: "money", nullable: true),
                    Sex = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    superssn = table.Column<int>(type: "int", nullable: true),
                    dno = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Employees", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Employees_Departments_dno",
                        column: x => x.dno,
                        principalTable: "Departments",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Employees_Employees_superssn",
                        column: x => x.superssn,
                        principalTable: "Employees",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Projects",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    pname = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    plocation = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    city = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    dnum = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Projects", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Projects_Departments_dnum",
                        column: x => x.dnum,
                        principalTable: "Departments",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Dependants",
                columns: table => new
                {
                    essn = table.Column<int>(type: "int", nullable: false),
                    dependant_name = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    sex = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    bdate = table.Column<DateOnly>(type: "date", nullable: false),
                    employeeId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Dependants", x => new { x.essn, x.dependant_name });
                    table.ForeignKey(
                        name: "FK_Dependants_Employees_employeeId",
                        column: x => x.employeeId,
                        principalTable: "Employees",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "works_Fors",
                columns: table => new
                {
                    essn = table.Column<int>(type: "int", nullable: false),
                    pnum = table.Column<int>(type: "int", nullable: false),
                    houres = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_works_Fors", x => new { x.essn, x.pnum });
                    table.ForeignKey(
                        name: "FK_works_Fors_Employees_essn",
                        column: x => x.essn,
                        principalTable: "Employees",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_works_Fors_Projects_pnum",
                        column: x => x.pnum,
                        principalTable: "Projects",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Departments_MGRssn",
                table: "Departments",
                column: "MGRssn",
                unique: true,
                filter: "[MGRssn] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Dependants_employeeId",
                table: "Dependants",
                column: "employeeId");

            migrationBuilder.CreateIndex(
                name: "IX_Employees_dno",
                table: "Employees",
                column: "dno");

            migrationBuilder.CreateIndex(
                name: "IX_Employees_superssn",
                table: "Employees",
                column: "superssn");

            migrationBuilder.CreateIndex(
                name: "IX_Projects_dnum",
                table: "Projects",
                column: "dnum");

            migrationBuilder.CreateIndex(
                name: "IX_works_Fors_pnum",
                table: "works_Fors",
                column: "pnum");

            migrationBuilder.AddForeignKey(
                name: "FK_Departments_Employees_MGRssn",
                table: "Departments",
                column: "MGRssn",
                principalTable: "Employees",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Departments_Employees_MGRssn",
                table: "Departments");

            migrationBuilder.DropTable(
                name: "Dependants");

            migrationBuilder.DropTable(
                name: "works_Fors");

            migrationBuilder.DropTable(
                name: "Projects");

            migrationBuilder.DropTable(
                name: "Employees");

            migrationBuilder.DropTable(
                name: "Departments");
        }
    }
}
