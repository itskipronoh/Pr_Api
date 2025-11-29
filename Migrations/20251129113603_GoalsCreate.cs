using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace PR.Migrations
{
    /// <inheritdoc />
    public partial class GoalsCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Goals",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Category = table.Column<int>(type: "int", nullable: false),
                    Weight = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    StartDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EndDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Status = table.Column<int>(type: "int", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ApprovalComment = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ApprovedBy = table.Column<int>(type: "int", nullable: true),
                    ApprovedOn = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Goals", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EmployeeId = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PasswordHash = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Department = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    JobTitle = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    Role = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    HireDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "KPIs",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MeasurementUnit = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TargetValue = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    GoalId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_KPIs", x => x.Id);
                    table.ForeignKey(
                        name: "FK_KPIs_Goals_GoalId",
                        column: x => x.GoalId,
                        principalTable: "Goals",
                        principalColumn: "Id");
                });

            migrationBuilder.InsertData(
                table: "Goals",
                columns: new[] { "Id", "ApprovalComment", "ApprovedBy", "ApprovedOn", "Category", "CreatedAt", "Description", "EndDate", "StartDate", "Status", "Title", "UpdatedAt", "Weight" },
                values: new object[,]
                {
                    { 1, null, 1, null, 1, new DateTime(2025, 11, 29, 11, 36, 0, 76, DateTimeKind.Utc).AddTicks(6049), "Grow overall company revenue by expanding market share.", new DateTime(2025, 12, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Increase Annual Revenue", new DateTime(2025, 11, 29, 11, 36, 0, 76, DateTimeKind.Utc).AddTicks(6052), 0m },
                    { 2, null, 1, null, 1, new DateTime(2025, 11, 29, 11, 36, 0, 76, DateTimeKind.Utc).AddTicks(6079), "Improve customer onboarding experience and expand reach.", new DateTime(2025, 8, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 2, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Enhance Customer Base", new DateTime(2025, 11, 29, 11, 36, 0, 76, DateTimeKind.Utc).AddTicks(6081), 0m },
                    { 3, null, 1, null, 1, new DateTime(2025, 11, 29, 11, 36, 0, 76, DateTimeKind.Utc).AddTicks(6094), "Streamline workflows using automation.", new DateTime(2025, 10, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Improve Internal Processes", new DateTime(2025, 11, 29, 11, 36, 0, 76, DateTimeKind.Utc).AddTicks(6096), 0m }
                });

            migrationBuilder.InsertData(
                table: "KPIs",
                columns: new[] { "Id", "GoalId", "MeasurementUnit", "Name", "TargetValue" },
                values: new object[,]
                {
                    { 1, null, "%", "Revenue Growth %", null },
                    { 2, null, "Count", "Customer Acquisition", null },
                    { 3, null, "%", "Operational Efficiency", null },
                    { 4, null, "%", "Employee Satisfaction", null }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "CreatedAt", "Department", "Email", "EmployeeId", "FirstName", "HireDate", "IsActive", "JobTitle", "LastName", "PasswordHash", "Role", "UpdatedAt" },
                values: new object[] { 1, new DateTime(2025, 11, 29, 11, 36, 0, 76, DateTimeKind.Utc).AddTicks(4173), "IT", "admin@performancemanagement.com", "EMP001", "System", new DateTime(2020, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), true, "System Administrator", "Administrator", "Admin@123", "Admin", new DateTime(2025, 11, 29, 11, 36, 0, 76, DateTimeKind.Utc).AddTicks(4176) });

            migrationBuilder.CreateIndex(
                name: "IX_KPIs_GoalId",
                table: "KPIs",
                column: "GoalId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "KPIs");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "Goals");
        }
    }
}
