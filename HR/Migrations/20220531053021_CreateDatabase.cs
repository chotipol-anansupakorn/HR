using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HR.Migrations
{
    public partial class CreateDatabase : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "department",
                columns: table => new
                {
                    departmentID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    departmentName = table.Column<string>(type: "varchar(150)", unicode: false, maxLength: 150, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_department", x => x.departmentID);
                });

            migrationBuilder.CreateTable(
                name: "district",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    districtName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    provinceId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_district", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "empBoss",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    empID = table.Column<string>(type: "nvarchar(7)", maxLength: 7, nullable: false),
                    BossID = table.Column<string>(type: "nvarchar(7)", maxLength: 7, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_empBoss", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "employee",
                columns: table => new
                {
                    empID = table.Column<string>(type: "nvarchar(7)", maxLength: 7, nullable: false),
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    empName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    empSurname = table.Column<string>(type: "nvarchar(75)", maxLength: 75, nullable: false),
                    empIDNo = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    bod = table.Column<DateTime>(type: "date", nullable: true),
                    empGenderID = table.Column<int>(type: "int", nullable: false),
                    empMarrySatatusID = table.Column<int>(type: "int", nullable: false),
                    empTel = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    empEmail = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    empImage = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    empIDCardAddress = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    empCurrentAddress = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    subDistrict = table.Column<int>(type: "int", nullable: false),
                    district = table.Column<int>(type: "int", nullable: false),
                    province = table.Column<int>(type: "int", nullable: false),
                    zipcode = table.Column<int>(type: "int", nullable: false),
                    empStart = table.Column<DateTime>(type: "date", nullable: false),
                    empEnd = table.Column<DateTime>(type: "date", nullable: true),
                    probation = table.Column<int>(type: "int", nullable: false),
                    empJobName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    empPositionID = table.Column<int>(type: "int", nullable: false),
                    empDepartmentID = table.Column<int>(type: "int", nullable: false),
                    workingHrsID = table.Column<int>(type: "int", nullable: false),
                    baseSalary = table.Column<double>(type: "float", nullable: false),
                    skillSalary = table.Column<double>(type: "float", nullable: false),
                    registDateTime = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "(getdate())"),
                    registBy = table.Column<string>(type: "nvarchar(7)", maxLength: 7, nullable: true),
                    isDelete = table.Column<int>(type: "int", nullable: true, defaultValueSql: "((0))")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_employee_1", x => x.empID);
                });

            migrationBuilder.CreateTable(
                name: "gender",
                columns: table => new
                {
                    genderID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    genderName = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_gender", x => x.genderID);
                });

            migrationBuilder.CreateTable(
                name: "holiday",
                columns: table => new
                {
                    holidayID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    holidayName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    holidayDate = table.Column<DateTime>(type: "date", nullable: false)
                },
                constraints: table =>
                {
                });

            migrationBuilder.CreateTable(
                name: "leave",
                columns: table => new
                {
                    leaveID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    leaveType = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    leaveDays = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_leave", x => x.leaveID);
                });

            migrationBuilder.CreateTable(
                name: "marryStatus",
                columns: table => new
                {
                    marryStatusID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    marryStatus = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_marryStatus", x => x.marryStatusID);
                });

            migrationBuilder.CreateTable(
                name: "OT",
                columns: table => new
                {
                    OT_ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    OT_mutiple = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OT", x => x.OT_ID);
                });

            migrationBuilder.CreateTable(
                name: "position",
                columns: table => new
                {
                    positionID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    positionName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_position", x => x.positionID);
                });

            migrationBuilder.CreateTable(
                name: "province",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    provinceName = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_province", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "subdistrict",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    subdistrictName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    districtId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_subdistrict", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "workingPeriod",
                columns: table => new
                {
                    workingHrsID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    workingStartTime = table.Column<TimeSpan>(type: "time(4)", nullable: false),
                    workingStopTime = table.Column<TimeSpan>(type: "time(4)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_workingPeriod", x => x.workingHrsID);
                });

            migrationBuilder.CreateTable(
                name: "zipcode",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    zipcodeName = table.Column<string>(type: "nvarchar(5)", maxLength: 5, nullable: false),
                    subdistrictId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_zipcode", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "empChild",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    empID = table.Column<string>(type: "nvarchar(7)", maxLength: 7, nullable: true),
                    empChildName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    empChildSurname = table.Column<string>(type: "nvarchar(75)", maxLength: 75, nullable: true),
                    empChildDOB = table.Column<DateTime>(type: "date", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_empChild", x => x.id);
                    table.ForeignKey(
                        name: "FK_empChild_empChild",
                        column: x => x.empID,
                        principalTable: "employee",
                        principalColumn: "empID");
                });

            migrationBuilder.CreateTable(
                name: "empContact",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    empID = table.Column<string>(type: "nvarchar(7)", maxLength: 7, nullable: false),
                    empDadName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    empDadSurname = table.Column<string>(type: "nvarchar(75)", maxLength: 75, nullable: false),
                    empDadDOB = table.Column<DateTime>(type: "date", nullable: false),
                    empDadJob = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    empDadTel = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    empMomName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    empMomSurname = table.Column<string>(type: "nvarchar(75)", maxLength: 75, nullable: false),
                    empMomDOB = table.Column<DateTime>(type: "date", nullable: false),
                    empMomJob = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    empMomTel = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    empSpouseName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    empSpouseSurname = table.Column<string>(type: "nvarchar(75)", maxLength: 75, nullable: true),
                    empSpouseDOB = table.Column<DateTime>(type: "date", nullable: true),
                    empSpouseJob = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    empSpouseTel = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    emergencyContactName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    emergencyContactSurname = table.Column<string>(type: "nvarchar(75)", maxLength: 75, nullable: false),
                    emergencyContactTel = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    emergencyContactRelation = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_empContact", x => x.id);
                    table.ForeignKey(
                        name: "FK_empContact_employee",
                        column: x => x.empID,
                        principalTable: "employee",
                        principalColumn: "empID");
                });

            migrationBuilder.CreateTable(
                name: "empSlibing",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    empID = table.Column<string>(type: "nvarchar(7)", maxLength: 7, nullable: true),
                    empSlibingName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    empSlibingSurname = table.Column<string>(type: "nvarchar(75)", maxLength: 75, nullable: true),
                    empSlibingDOB = table.Column<DateTime>(type: "date", nullable: true),
                    empSlibingJob = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    empSlibingTel = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_empSlibing", x => x.id);
                    table.ForeignKey(
                        name: "FK_empSlibing_employee",
                        column: x => x.empID,
                        principalTable: "employee",
                        principalColumn: "empID");
                });

            migrationBuilder.CreateTable(
                name: "empTimestamp",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    empID = table.Column<string>(type: "nvarchar(7)", maxLength: 7, nullable: false),
                    timeIn = table.Column<DateTime>(type: "datetime", nullable: false),
                    timeOut = table.Column<DateTime>(type: "datetime", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_empTimestamp", x => x.id);
                    table.ForeignKey(
                        name: "FK_empTimestamp_employee",
                        column: x => x.empID,
                        principalTable: "employee",
                        principalColumn: "empID");
                });

            migrationBuilder.CreateTable(
                name: "empLeave",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    empID = table.Column<string>(type: "nvarchar(7)", maxLength: 7, nullable: false),
                    leaveID = table.Column<int>(type: "int", nullable: false),
                    leaveStart = table.Column<DateTime>(type: "datetime", nullable: false),
                    leaveStop = table.Column<DateTime>(type: "datetime", nullable: false),
                    registDateTime = table.Column<byte[]>(type: "rowversion", rowVersion: true, nullable: false),
                    approveBy = table.Column<string>(type: "nvarchar(7)", maxLength: 7, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_empLeave", x => x.id);
                    table.ForeignKey(
                        name: "FK_empLeave_leave",
                        column: x => x.leaveID,
                        principalTable: "leave",
                        principalColumn: "leaveID");
                });

            migrationBuilder.CreateTable(
                name: "empOT",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false),
                    empID = table.Column<string>(type: "nvarchar(7)", maxLength: 7, nullable: false),
                    OT_Date = table.Column<DateTime>(type: "date", nullable: false),
                    OT_hrs = table.Column<TimeSpan>(type: "time", nullable: false),
                    OT_id = table.Column<int>(type: "int", nullable: false),
                    registDateTime = table.Column<DateTime>(type: "datetime", nullable: false),
                    approveBy = table.Column<string>(type: "nvarchar(7)", maxLength: 7, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_empOT", x => x.id);
                    table.ForeignKey(
                        name: "FK_empOT_empOT",
                        column: x => x.empID,
                        principalTable: "employee",
                        principalColumn: "empID");
                    table.ForeignKey(
                        name: "FK_empOT_OT",
                        column: x => x.OT_id,
                        principalTable: "OT",
                        principalColumn: "OT_ID");
                });

            migrationBuilder.CreateTable(
                name: "workingShift",
                columns: table => new
                {
                    shiftID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    empID = table.Column<int>(type: "int", nullable: false),
                    workingHrsID = table.Column<int>(type: "int", nullable: false),
                    shiftStartDate = table.Column<DateTime>(type: "datetime", nullable: false),
                    shiftStopDate = table.Column<DateTime>(type: "datetime", nullable: false),
                    registDateTime = table.Column<DateTime>(type: "datetime", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_workingShift", x => x.shiftID);
                    table.ForeignKey(
                        name: "FK_workingShift_workingPeriod",
                        column: x => x.workingHrsID,
                        principalTable: "workingPeriod",
                        principalColumn: "workingHrsID");
                });

            migrationBuilder.CreateIndex(
                name: "IX_empChild_empID",
                table: "empChild",
                column: "empID");

            migrationBuilder.CreateIndex(
                name: "IX_empContact_empID",
                table: "empContact",
                column: "empID");

            migrationBuilder.CreateIndex(
                name: "IX_empLeave_leaveID",
                table: "empLeave",
                column: "leaveID");

            migrationBuilder.CreateIndex(
                name: "IX_empOT_empID",
                table: "empOT",
                column: "empID");

            migrationBuilder.CreateIndex(
                name: "IX_empOT_OT_id",
                table: "empOT",
                column: "OT_id");

            migrationBuilder.CreateIndex(
                name: "IX_empSlibing_empID",
                table: "empSlibing",
                column: "empID");

            migrationBuilder.CreateIndex(
                name: "IX_empTimestamp_empID",
                table: "empTimestamp",
                column: "empID");

            migrationBuilder.CreateIndex(
                name: "IX_workingShift_workingHrsID",
                table: "workingShift",
                column: "workingHrsID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "department");

            migrationBuilder.DropTable(
                name: "district");

            migrationBuilder.DropTable(
                name: "empBoss");

            migrationBuilder.DropTable(
                name: "empChild");

            migrationBuilder.DropTable(
                name: "empContact");

            migrationBuilder.DropTable(
                name: "empLeave");

            migrationBuilder.DropTable(
                name: "empOT");

            migrationBuilder.DropTable(
                name: "empSlibing");

            migrationBuilder.DropTable(
                name: "empTimestamp");

            migrationBuilder.DropTable(
                name: "gender");

            migrationBuilder.DropTable(
                name: "holiday");

            migrationBuilder.DropTable(
                name: "marryStatus");

            migrationBuilder.DropTable(
                name: "position");

            migrationBuilder.DropTable(
                name: "province");

            migrationBuilder.DropTable(
                name: "subdistrict");

            migrationBuilder.DropTable(
                name: "workingShift");

            migrationBuilder.DropTable(
                name: "zipcode");

            migrationBuilder.DropTable(
                name: "leave");

            migrationBuilder.DropTable(
                name: "OT");

            migrationBuilder.DropTable(
                name: "employee");

            migrationBuilder.DropTable(
                name: "workingPeriod");
        }
    }
}
