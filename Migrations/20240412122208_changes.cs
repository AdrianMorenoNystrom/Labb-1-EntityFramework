using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Labb_1.Migrations
{
    /// <inheritdoc />
    public partial class changes : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {

            migrationBuilder.CreateTable(
                name: "LeaveList",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FkEmployeeId = table.Column<int>(type: "int", nullable: false),
                    FkLeaveId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LeaveList", x => x.Id);
                    table.ForeignKey(
                        name: "FK_LeaveList_Employee_FkEmployeeId",
                        column: x => x.FkEmployeeId,
                        principalTable: "Employee",
                        principalColumn: "EmployeeId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_LeaveList_Leave_FkLeaveId",
                        column: x => x.FkLeaveId,
                        principalTable: "Leave",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction); 
                });

            migrationBuilder.CreateIndex(
                name: "IX_LeaveList_FkEmployeeId",
                table: "LeaveList",
                column: "FkEmployeeId");

            migrationBuilder.CreateIndex(
                name: "IX_LeaveList_FkLeaveId",
                table: "LeaveList",
                column: "FkLeaveId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "LeaveList");

            migrationBuilder.CreateTable(
                name: "LeaveHistory",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EmployeeId = table.Column<int>(type: "int", nullable: false),
                    ApplicationDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EndDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LeaveType = table.Column<int>(type: "int", nullable: false),
                    StartDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LeaveHistory", x => x.Id);
                    table.ForeignKey(
                        name: "FK_LeaveHistory_Employee_EmployeeId",
                        column: x => x.EmployeeId,
                        principalTable: "Employee",
                        principalColumn: "EmployeeId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_LeaveHistory_EmployeeId",
                table: "LeaveHistory",
                column: "EmployeeId");
        }
    }
}
