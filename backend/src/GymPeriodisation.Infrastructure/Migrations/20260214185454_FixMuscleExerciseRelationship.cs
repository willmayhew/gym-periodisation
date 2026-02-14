using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GymPeriodisation.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class FixMuscleExerciseRelationship : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Muscles_Exercises_ExerciseId",
                table: "Muscles");

            migrationBuilder.DropIndex(
                name: "IX_Muscles_ExerciseId",
                table: "Muscles");

            migrationBuilder.DropColumn(
                name: "ExerciseId",
                table: "Muscles");

            migrationBuilder.CreateTable(
                name: "ExerciseMuscles",
                columns: table => new
                {
                    ExercisesId = table.Column<int>(type: "int", nullable: false),
                    MuscleGroupsId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ExerciseMuscles", x => new { x.ExercisesId, x.MuscleGroupsId });
                    table.ForeignKey(
                        name: "FK_ExerciseMuscles_Exercises_ExercisesId",
                        column: x => x.ExercisesId,
                        principalTable: "Exercises",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ExerciseMuscles_Muscles_MuscleGroupsId",
                        column: x => x.MuscleGroupsId,
                        principalTable: "Muscles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ExerciseMuscles_MuscleGroupsId",
                table: "ExerciseMuscles",
                column: "MuscleGroupsId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ExerciseMuscles");

            migrationBuilder.AddColumn<int>(
                name: "ExerciseId",
                table: "Muscles",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Muscles_ExerciseId",
                table: "Muscles",
                column: "ExerciseId");

            migrationBuilder.AddForeignKey(
                name: "FK_Muscles_Exercises_ExerciseId",
                table: "Muscles",
                column: "ExerciseId",
                principalTable: "Exercises",
                principalColumn: "Id");
        }
    }
}
