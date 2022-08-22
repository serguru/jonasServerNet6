using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace JonasCodingTestNet6.API.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Companies",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    CompanyCode = table.Column<string>(type: "TEXT", nullable: false),
                    CompanyName = table.Column<string>(type: "TEXT", maxLength: 50, nullable: false),
                    AddressLine1 = table.Column<string>(type: "TEXT", nullable: true),
                    AddressLine2 = table.Column<string>(type: "TEXT", nullable: true),
                    AddressLine3 = table.Column<string>(type: "TEXT", nullable: true),
                    PostalZipCode = table.Column<string>(type: "TEXT", nullable: true),
                    PhoneNumber = table.Column<string>(type: "TEXT", nullable: true),
                    FaxNumber = table.Column<string>(type: "TEXT", nullable: true),
                    EquipmentCompanyCode = table.Column<string>(type: "TEXT", nullable: true),
                    Country = table.Column<string>(type: "TEXT", nullable: true),
                    LastModified = table.Column<DateTime>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Companies", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ArSubledgers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    CompanyId = table.Column<int>(type: "INTEGER", nullable: false),
                    ArSubledgerCode = table.Column<string>(type: "TEXT", maxLength: 50, nullable: false),
                    Description = table.Column<string>(type: "TEXT", nullable: true),
                    CustomerName = table.Column<string>(type: "TEXT", nullable: true),
                    AddressLine1 = table.Column<string>(type: "TEXT", nullable: true),
                    AddressLine2 = table.Column<string>(type: "TEXT", nullable: true),
                    AddressLine3 = table.Column<string>(type: "TEXT", nullable: true),
                    PostalZipCode = table.Column<string>(type: "TEXT", nullable: true),
                    PhoneNumber = table.Column<string>(type: "TEXT", nullable: true),
                    FaxNumber = table.Column<string>(type: "TEXT", nullable: true),
                    LastModified = table.Column<DateTime>(type: "TEXT", nullable: true),
                    Active = table.Column<string>(type: "TEXT", nullable: true),
                    Inactive = table.Column<string>(type: "TEXT", nullable: true),
                    Excellent = table.Column<string>(type: "TEXT", nullable: true),
                    Good = table.Column<string>(type: "TEXT", nullable: true),
                    Fair = table.Column<string>(type: "TEXT", nullable: true),
                    Poor = table.Column<string>(type: "TEXT", nullable: true),
                    Condemned = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ArSubledgers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ArSubledgers_Companies_CompanyId",
                        column: x => x.CompanyId,
                        principalTable: "Companies",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Employees",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    CompanyId = table.Column<int>(type: "INTEGER", nullable: false),
                    EmployeeCode = table.Column<string>(type: "TEXT", maxLength: 50, nullable: false),
                    EmployeeName = table.Column<string>(type: "TEXT", nullable: true),
                    Occupation = table.Column<string>(type: "TEXT", nullable: true),
                    EmployeeStatus = table.Column<string>(type: "TEXT", nullable: true),
                    EmailAddress = table.Column<string>(type: "TEXT", nullable: true),
                    Phone = table.Column<string>(type: "TEXT", nullable: true),
                    LastModified = table.Column<DateTime>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Employees", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Employees_Companies_CompanyId",
                        column: x => x.CompanyId,
                        principalTable: "Companies",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Companies",
                columns: new[] { "Id", "AddressLine1", "AddressLine2", "AddressLine3", "CompanyCode", "CompanyName", "Country", "EquipmentCompanyCode", "FaxNumber", "LastModified", "PhoneNumber", "PostalZipCode" },
                values: new object[] { 1, null, null, null, "CompanyCode1", "CompanyName1", null, null, null, null, null, null });

            migrationBuilder.InsertData(
                table: "Companies",
                columns: new[] { "Id", "AddressLine1", "AddressLine2", "AddressLine3", "CompanyCode", "CompanyName", "Country", "EquipmentCompanyCode", "FaxNumber", "LastModified", "PhoneNumber", "PostalZipCode" },
                values: new object[] { 2, null, null, null, "CompanyCode2", "CompanyName2", null, null, null, null, null, null });

            migrationBuilder.InsertData(
                table: "Companies",
                columns: new[] { "Id", "AddressLine1", "AddressLine2", "AddressLine3", "CompanyCode", "CompanyName", "Country", "EquipmentCompanyCode", "FaxNumber", "LastModified", "PhoneNumber", "PostalZipCode" },
                values: new object[] { 3, null, null, null, "CompanyCode3", "CompanyName3", null, null, null, null, null, null });

            migrationBuilder.InsertData(
                table: "ArSubledgers",
                columns: new[] { "Id", "Active", "AddressLine1", "AddressLine2", "AddressLine3", "ArSubledgerCode", "CompanyId", "Condemned", "CustomerName", "Description", "Excellent", "Fair", "FaxNumber", "Good", "Inactive", "LastModified", "PhoneNumber", "Poor", "PostalZipCode" },
                values: new object[] { 1, "Yes", null, null, null, "ArSubledgerCode1", 1, null, null, null, null, null, null, null, null, null, null, null, null });

            migrationBuilder.InsertData(
                table: "ArSubledgers",
                columns: new[] { "Id", "Active", "AddressLine1", "AddressLine2", "AddressLine3", "ArSubledgerCode", "CompanyId", "Condemned", "CustomerName", "Description", "Excellent", "Fair", "FaxNumber", "Good", "Inactive", "LastModified", "PhoneNumber", "Poor", "PostalZipCode" },
                values: new object[] { 2, "Yes", null, null, null, "ArSubledgerCode2", 1, null, null, null, null, null, null, null, null, null, null, null, null });

            migrationBuilder.InsertData(
                table: "ArSubledgers",
                columns: new[] { "Id", "Active", "AddressLine1", "AddressLine2", "AddressLine3", "ArSubledgerCode", "CompanyId", "Condemned", "CustomerName", "Description", "Excellent", "Fair", "FaxNumber", "Good", "Inactive", "LastModified", "PhoneNumber", "Poor", "PostalZipCode" },
                values: new object[] { 3, "Yes", null, null, null, "ArSubledgerCode3", 2, null, null, null, null, null, null, null, null, null, null, null, null });

            migrationBuilder.InsertData(
                table: "ArSubledgers",
                columns: new[] { "Id", "Active", "AddressLine1", "AddressLine2", "AddressLine3", "ArSubledgerCode", "CompanyId", "Condemned", "CustomerName", "Description", "Excellent", "Fair", "FaxNumber", "Good", "Inactive", "LastModified", "PhoneNumber", "Poor", "PostalZipCode" },
                values: new object[] { 4, "Yes", null, null, null, "ArSubledgerCode4", 2, null, null, null, null, null, null, null, null, null, null, null, null });

            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "Id", "CompanyId", "EmailAddress", "EmployeeCode", "EmployeeName", "EmployeeStatus", "LastModified", "Occupation", "Phone" },
                values: new object[] { 1, 1, null, "EmployeeCode1", null, null, null, null, null });

            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "Id", "CompanyId", "EmailAddress", "EmployeeCode", "EmployeeName", "EmployeeStatus", "LastModified", "Occupation", "Phone" },
                values: new object[] { 2, 1, null, "EmployeeCode2", null, null, null, null, null });

            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "Id", "CompanyId", "EmailAddress", "EmployeeCode", "EmployeeName", "EmployeeStatus", "LastModified", "Occupation", "Phone" },
                values: new object[] { 3, 2, null, "EmployeeCode3", null, null, null, null, null });

            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "Id", "CompanyId", "EmailAddress", "EmployeeCode", "EmployeeName", "EmployeeStatus", "LastModified", "Occupation", "Phone" },
                values: new object[] { 4, 2, null, "EmployeeCode4", null, null, null, null, null });

            migrationBuilder.CreateIndex(
                name: "IX_ArSubledgers_ArSubledgerCode",
                table: "ArSubledgers",
                column: "ArSubledgerCode",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_ArSubledgers_CompanyId",
                table: "ArSubledgers",
                column: "CompanyId");

            migrationBuilder.CreateIndex(
                name: "IX_Companies_CompanyCode",
                table: "Companies",
                column: "CompanyCode",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Employees_CompanyId",
                table: "Employees",
                column: "CompanyId");

            migrationBuilder.CreateIndex(
                name: "IX_Employees_EmployeeCode",
                table: "Employees",
                column: "EmployeeCode",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ArSubledgers");

            migrationBuilder.DropTable(
                name: "Employees");

            migrationBuilder.DropTable(
                name: "Companies");
        }
    }
}
