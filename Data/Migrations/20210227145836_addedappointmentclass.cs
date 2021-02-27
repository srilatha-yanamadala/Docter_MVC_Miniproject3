using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Docter_MVC_Miniproject3.Data.Migrations
{
    public partial class addedappointmentclass : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "DateTime",
                table: "Appointments",
                newName: "Start");

            migrationBuilder.AddColumn<DateTime>(
                name: "End",
                table: "Appointments",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "End",
                table: "Appointments");

            migrationBuilder.RenameColumn(
                name: "Start",
                table: "Appointments",
                newName: "DateTime");
        }
    }
}
