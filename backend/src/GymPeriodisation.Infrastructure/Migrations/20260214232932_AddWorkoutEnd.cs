using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GymPeriodisation.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AddWorkoutEnd : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Date",
                table: "Workouts",
                newName: "DateStarted");

            migrationBuilder.AddColumn<string>(
                name: "Comment",
                table: "Workouts",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<DateTime>(
                name: "DateEnded",
                table: "Workouts",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "Workouts",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Comment",
                table: "Workouts");

            migrationBuilder.DropColumn(
                name: "DateEnded",
                table: "Workouts");

            migrationBuilder.DropColumn(
                name: "Name",
                table: "Workouts");

            migrationBuilder.RenameColumn(
                name: "DateStarted",
                table: "Workouts",
                newName: "Date");
        }
    }
}
