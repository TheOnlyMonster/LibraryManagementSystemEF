using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace LibraryManagementSystemEF.Migrations
{
    /// <inheritdoc />
    public partial class LibraryBookNowHasOnly1PrimaryKeyWhichIsTheForeginKey : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_LibraryBooks",
                table: "LibraryBooks");

            migrationBuilder.DropIndex(
                name: "IX_LibraryBooks_BookId",
                table: "LibraryBooks");

            migrationBuilder.DeleteData(
                table: "LibraryBooks",
                keyColumn: "Id",
                keyColumnType: "int",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "LibraryBooks",
                keyColumn: "Id",
                keyColumnType: "int",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "LibraryBooks",
                keyColumn: "Id",
                keyColumnType: "int",
                keyValue: 3);

            migrationBuilder.DropColumn(
                name: "Id",
                table: "LibraryBooks");

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateOfMembership",
                table: "Members",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2024, 9, 23, 14, 21, 7, 656, DateTimeKind.Local).AddTicks(5952),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2024, 9, 23, 14, 13, 33, 473, DateTimeKind.Local).AddTicks(4986));

            migrationBuilder.AlterColumn<DateTime>(
                name: "BorrowDate",
                table: "BorrowedBooks",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2024, 9, 23, 14, 21, 7, 654, DateTimeKind.Local).AddTicks(6659),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2024, 9, 23, 14, 13, 33, 472, DateTimeKind.Local).AddTicks(1467));

            migrationBuilder.AddPrimaryKey(
                name: "PK_LibraryBooks",
                table: "LibraryBooks",
                column: "BookId");

            migrationBuilder.UpdateData(
                table: "BorrowedBooks",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "BorrowDate", "ReturnDate" },
                values: new object[] { new DateTime(2024, 9, 23, 14, 21, 7, 654, DateTimeKind.Local).AddTicks(7668), new DateTime(2024, 10, 7, 14, 21, 7, 654, DateTimeKind.Local).AddTicks(7679) });

            migrationBuilder.UpdateData(
                table: "BorrowedBooks",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "BorrowDate", "ReturnDate" },
                values: new object[] { new DateTime(2024, 9, 23, 14, 21, 7, 654, DateTimeKind.Local).AddTicks(7683), new DateTime(2024, 10, 7, 14, 21, 7, 654, DateTimeKind.Local).AddTicks(7685) });

            migrationBuilder.UpdateData(
                table: "Librarians",
                keyColumn: "Id",
                keyValue: 1,
                column: "DateOfEmployment",
                value: new DateTime(2024, 9, 23, 14, 21, 7, 655, DateTimeKind.Local).AddTicks(2376));

            migrationBuilder.InsertData(
                table: "LibraryBooks",
                columns: new[] { "BookId", "Quantity" },
                values: new object[,]
                {
                    { 1, 10 },
                    { 2, 10 },
                    { 3, 10 }
                });

            migrationBuilder.UpdateData(
                table: "Members",
                keyColumn: "Id",
                keyValue: 1,
                column: "DateOfMembership",
                value: new DateTime(2024, 9, 23, 14, 21, 7, 656, DateTimeKind.Local).AddTicks(6840));

            migrationBuilder.UpdateData(
                table: "Members",
                keyColumn: "Id",
                keyValue: 2,
                column: "DateOfMembership",
                value: new DateTime(2024, 9, 23, 14, 21, 7, 656, DateTimeKind.Local).AddTicks(6855));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_LibraryBooks",
                table: "LibraryBooks");

            migrationBuilder.DeleteData(
                table: "LibraryBooks",
                keyColumn: "BookId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "LibraryBooks",
                keyColumn: "BookId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "LibraryBooks",
                keyColumn: "BookId",
                keyValue: 3);

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateOfMembership",
                table: "Members",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2024, 9, 23, 14, 13, 33, 473, DateTimeKind.Local).AddTicks(4986),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2024, 9, 23, 14, 21, 7, 656, DateTimeKind.Local).AddTicks(5952));

            migrationBuilder.AddColumn<int>(
                name: "Id",
                table: "LibraryBooks",
                type: "int",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AlterColumn<DateTime>(
                name: "BorrowDate",
                table: "BorrowedBooks",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2024, 9, 23, 14, 13, 33, 472, DateTimeKind.Local).AddTicks(1467),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2024, 9, 23, 14, 21, 7, 654, DateTimeKind.Local).AddTicks(6659));

            migrationBuilder.AddPrimaryKey(
                name: "PK_LibraryBooks",
                table: "LibraryBooks",
                column: "Id");

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

            migrationBuilder.UpdateData(
                table: "Librarians",
                keyColumn: "Id",
                keyValue: 1,
                column: "DateOfEmployment",
                value: new DateTime(2024, 9, 23, 14, 13, 33, 472, DateTimeKind.Local).AddTicks(7808));

            migrationBuilder.InsertData(
                table: "LibraryBooks",
                columns: new[] { "Id", "BookId", "Quantity" },
                values: new object[,]
                {
                    { 1, 1, 10 },
                    { 2, 2, 10 },
                    { 3, 3, 10 }
                });

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
                name: "IX_LibraryBooks_BookId",
                table: "LibraryBooks",
                column: "BookId",
                unique: true);
        }
    }
}
