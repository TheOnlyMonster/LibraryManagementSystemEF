using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace LibraryManagementSystemEF.Migrations
{
    /// <inheritdoc />
    public partial class AddedEntitiesMemberAndBorrowedBooks : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Password",
                table: "Authors",
                type: "VARCHAR(30)",
                maxLength: 30,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Authors",
                type: "VARCHAR(100)",
                maxLength: 100,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.CreateTable(
                name: "Members",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DateOfMembership = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValue: new DateTime(2024, 9, 23, 4, 34, 32, 619, DateTimeKind.Local).AddTicks(1728)),
                    MembershipDuration = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "VARCHAR(100)", maxLength: 100, nullable: false),
                    Email = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Password = table.Column<string>(type: "VARCHAR(30)", maxLength: 30, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Members", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "BorrowedBooks",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BookDetailsId = table.Column<int>(type: "int", nullable: true),
                    MemberId = table.Column<int>(type: "int", nullable: false),
                    TitleSnapshot = table.Column<string>(type: "VARCHAR(100)", maxLength: 100, nullable: false),
                    YearSnapshot = table.Column<int>(type: "int", nullable: false),
                    GenreSnapshot = table.Column<string>(type: "VARCHAR(50)", maxLength: 50, nullable: false),
                    BorrowDate = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValue: new DateTime(2024, 9, 23, 4, 34, 32, 618, DateTimeKind.Local).AddTicks(2679)),
                    ReturnDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsReturned = table.Column<bool>(type: "bit", nullable: false, defaultValue: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BorrowedBooks", x => x.Id);
                    table.ForeignKey(
                        name: "FK_BorrowedBooks_Books_BookDetailsId",
                        column: x => x.BookDetailsId,
                        principalTable: "Books",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.SetNull);
                    table.ForeignKey(
                        name: "FK_BorrowedBooks_Members_MemberId",
                        column: x => x.MemberId,
                        principalTable: "Members",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                table: "Members",
                columns: new[] { "Id", "DateOfMembership", "Email", "MembershipDuration", "Name", "Password" },
                values: new object[,]
                {
                    { 1, new DateTime(2024, 9, 23, 4, 34, 32, 619, DateTimeKind.Local).AddTicks(2592), "johnDoe@example.com", 30, "John Doe", "john123" },
                    { 2, new DateTime(2024, 9, 23, 4, 34, 32, 619, DateTimeKind.Local).AddTicks(2606), "janDoe@example.com", 30, "Jane Doe", "jane123" }
                });

            migrationBuilder.InsertData(
                table: "BorrowedBooks",
                columns: new[] { "Id", "BookDetailsId", "BorrowDate", "GenreSnapshot", "MemberId", "ReturnDate", "TitleSnapshot", "YearSnapshot" },
                values: new object[,]
                {
                    { 1, 1, new DateTime(2024, 9, 23, 4, 34, 32, 618, DateTimeKind.Local).AddTicks(3712), "Fiction", 1, new DateTime(2024, 10, 7, 4, 34, 32, 618, DateTimeKind.Local).AddTicks(3723), "The Great Gatsby", 1925 },
                    { 2, 2, new DateTime(2024, 9, 23, 4, 34, 32, 618, DateTimeKind.Local).AddTicks(3727), "Fiction", 2, new DateTime(2024, 10, 7, 4, 34, 32, 618, DateTimeKind.Local).AddTicks(3730), "To Kill a Mockingbird", 1960 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_BorrowedBooks_BookDetailsId",
                table: "BorrowedBooks",
                column: "BookDetailsId");

            migrationBuilder.CreateIndex(
                name: "IX_BorrowedBooks_MemberId",
                table: "BorrowedBooks",
                column: "MemberId");

            migrationBuilder.CreateIndex(
                name: "IX_Members_Email",
                table: "Members",
                column: "Email",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BorrowedBooks");

            migrationBuilder.DropTable(
                name: "Members");

            migrationBuilder.AlterColumn<string>(
                name: "Password",
                table: "Authors",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "VARCHAR(30)",
                oldMaxLength: 30);

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Authors",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "VARCHAR(100)",
                oldMaxLength: 100);
        }
    }
}
