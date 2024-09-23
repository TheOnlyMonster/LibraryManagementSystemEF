using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LibraryManagementSystemEF.Migrations
{
    /// <inheritdoc />
    public partial class AddedLibrarianEntity : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "DateOfMembership",
                table: "Members",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2024, 9, 23, 14, 13, 33, 473, DateTimeKind.Local).AddTicks(4986),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2024, 9, 23, 4, 34, 32, 619, DateTimeKind.Local).AddTicks(1728));

            migrationBuilder.AlterColumn<DateTime>(
                name: "BorrowDate",
                table: "BorrowedBooks",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2024, 9, 23, 14, 13, 33, 472, DateTimeKind.Local).AddTicks(1467),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2024, 9, 23, 4, 34, 32, 618, DateTimeKind.Local).AddTicks(2679));

            migrationBuilder.CreateTable(
                name: "Librarians",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Salary = table.Column<int>(type: "int", nullable: false),
                    DateOfEmployment = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Name = table.Column<string>(type: "VARCHAR(100)", maxLength: 100, nullable: false),
                    Email = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Password = table.Column<string>(type: "VARCHAR(30)", maxLength: 30, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Librarians", x => x.Id);
                });

            migrationBuilder.UpdateData(
                table: "BorrowedBooks",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "BorrowDate", "ReturnDate" },
                values: new object[] { new DateTime(2024, 9, 23, 14, 13, 33, 472, DateTimeKind.Local).AddTicks(2488), new DateTime(2024, 10, 7, 14, 13, 33, 472, DateTimeKind.Local).AddTicks(2499) });

            migrationBuilder.UpdateData(
                table: "BorrowedBooks",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "BorrowDate", "ReturnDate" },
                values: new object[] { new DateTime(2024, 9, 23, 14, 13, 33, 472, DateTimeKind.Local).AddTicks(2505), new DateTime(2024, 10, 7, 14, 13, 33, 472, DateTimeKind.Local).AddTicks(2508) });

            migrationBuilder.InsertData(
                table: "Librarians",
                columns: new[] { "Id", "DateOfEmployment", "Email", "Name", "Password", "Salary" },
                values: new object[] { 1, new DateTime(2024, 9, 23, 14, 13, 33, 472, DateTimeKind.Local).AddTicks(7808), "ahmedSmith@exmaple.com", "Ahmed Smith", "ahmed123", 5000 });

            migrationBuilder.UpdateData(
                table: "Members",
                keyColumn: "Id",
                keyValue: 1,
                column: "DateOfMembership",
                value: new DateTime(2024, 9, 23, 14, 13, 33, 473, DateTimeKind.Local).AddTicks(5896));

            migrationBuilder.UpdateData(
                table: "Members",
                keyColumn: "Id",
                keyValue: 2,
                column: "DateOfMembership",
                value: new DateTime(2024, 9, 23, 14, 13, 33, 473, DateTimeKind.Local).AddTicks(5912));

            migrationBuilder.CreateIndex(
                name: "IX_Librarians_Email",
                table: "Librarians",
                column: "Email",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Librarians");

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateOfMembership",
                table: "Members",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2024, 9, 23, 4, 34, 32, 619, DateTimeKind.Local).AddTicks(1728),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2024, 9, 23, 14, 13, 33, 473, DateTimeKind.Local).AddTicks(4986));

            migrationBuilder.AlterColumn<DateTime>(
                name: "BorrowDate",
                table: "BorrowedBooks",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2024, 9, 23, 4, 34, 32, 618, DateTimeKind.Local).AddTicks(2679),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2024, 9, 23, 14, 13, 33, 472, DateTimeKind.Local).AddTicks(1467));

            migrationBuilder.UpdateData(
                table: "BorrowedBooks",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "BorrowDate", "ReturnDate" },
                values: new object[] { new DateTime(2024, 9, 23, 4, 34, 32, 618, DateTimeKind.Local).AddTicks(3712), new DateTime(2024, 10, 7, 4, 34, 32, 618, DateTimeKind.Local).AddTicks(3723) });

            migrationBuilder.UpdateData(
                table: "BorrowedBooks",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "BorrowDate", "ReturnDate" },
                values: new object[] { new DateTime(2024, 9, 23, 4, 34, 32, 618, DateTimeKind.Local).AddTicks(3727), new DateTime(2024, 10, 7, 4, 34, 32, 618, DateTimeKind.Local).AddTicks(3730) });

            migrationBuilder.UpdateData(
                table: "Members",
                keyColumn: "Id",
                keyValue: 1,
                column: "DateOfMembership",
                value: new DateTime(2024, 9, 23, 4, 34, 32, 619, DateTimeKind.Local).AddTicks(2592));

            migrationBuilder.UpdateData(
                table: "Members",
                keyColumn: "Id",
                keyValue: 2,
                column: "DateOfMembership",
                value: new DateTime(2024, 9, 23, 4, 34, 32, 619, DateTimeKind.Local).AddTicks(2606));
        }
    }
}
