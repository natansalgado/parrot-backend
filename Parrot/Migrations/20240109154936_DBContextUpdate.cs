using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Parrot.Migrations
{
    public partial class DBContextUpdate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "PublishedDate",
                table: "Posts",
                type: "datetime2",
                nullable: true,
                defaultValue: new DateTime(2024, 1, 9, 15, 49, 36, 622, DateTimeKind.Utc).AddTicks(9921),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true,
                oldDefaultValue: new DateTime(2024, 1, 8, 16, 24, 56, 276, DateTimeKind.Utc).AddTicks(2140));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "PublishedDate",
                table: "Posts",
                type: "datetime2",
                nullable: true,
                defaultValue: new DateTime(2024, 1, 8, 16, 24, 56, 276, DateTimeKind.Utc).AddTicks(2140),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true,
                oldDefaultValue: new DateTime(2024, 1, 9, 15, 49, 36, 622, DateTimeKind.Utc).AddTicks(9921));
        }
    }
}
