using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LearningCenter.Infraestructure.Migrations
{
    public partial class _2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "DateCreated",
                table: "Users",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2022, 11, 26, 22, 2, 55, 731, DateTimeKind.Local).AddTicks(1808),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2022, 11, 26, 21, 57, 41, 882, DateTimeKind.Local).AddTicks(9252));

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateCreated",
                table: "Tutorials",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2022, 11, 26, 22, 2, 55, 731, DateTimeKind.Local).AddTicks(1180),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2022, 11, 26, 21, 57, 41, 882, DateTimeKind.Local).AddTicks(8747));

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateCreated",
                table: "Categories",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2022, 11, 26, 22, 2, 55, 731, DateTimeKind.Local).AddTicks(650),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2022, 11, 26, 21, 57, 41, 882, DateTimeKind.Local).AddTicks(8138));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "DateCreated",
                table: "Users",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2022, 11, 26, 21, 57, 41, 882, DateTimeKind.Local).AddTicks(9252),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2022, 11, 26, 22, 2, 55, 731, DateTimeKind.Local).AddTicks(1808));

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateCreated",
                table: "Tutorials",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2022, 11, 26, 21, 57, 41, 882, DateTimeKind.Local).AddTicks(8747),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2022, 11, 26, 22, 2, 55, 731, DateTimeKind.Local).AddTicks(1180));

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateCreated",
                table: "Categories",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2022, 11, 26, 21, 57, 41, 882, DateTimeKind.Local).AddTicks(8138),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2022, 11, 26, 22, 2, 55, 731, DateTimeKind.Local).AddTicks(650));
        }
    }
}
