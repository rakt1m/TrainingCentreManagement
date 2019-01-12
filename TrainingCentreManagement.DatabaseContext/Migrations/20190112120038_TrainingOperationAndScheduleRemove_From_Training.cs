using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace TrainingCentreManagement.DatabaseContext.Migrations
{
    public partial class TrainingOperationAndScheduleRemove_From_Training : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Schedule_ScedhuleType_ScedhuleTypeId",
                table: "Schedule");

            migrationBuilder.DropForeignKey(
                name: "FK_Training_Schedule_TrainingScheduleId",
                table: "Training");

            migrationBuilder.DropIndex(
                name: "IX_Training_TrainingScheduleId",
                table: "Training");

            migrationBuilder.DropColumn(
                name: "Fee",
                table: "Training");

            migrationBuilder.DropColumn(
                name: "HasBatches",
                table: "Training");

            migrationBuilder.DropColumn(
                name: "IsFree",
                table: "Training");

            migrationBuilder.DropColumn(
                name: "RegistrationEnd",
                table: "Training");

            migrationBuilder.DropColumn(
                name: "RegistrationStart",
                table: "Training");

            migrationBuilder.DropColumn(
                name: "TotalCapacity",
                table: "Training");

            migrationBuilder.DropColumn(
                name: "TrainingScheduleId",
                table: "Training");

            migrationBuilder.DropColumn(
                name: "TrainingStart",
                table: "Training");

            migrationBuilder.AlterColumn<long>(
                name: "ScedhuleTypeId",
                table: "Schedule",
                nullable: true,
                oldClrType: typeof(long));

            migrationBuilder.AddColumn<bool>(
                name: "IsNameDisplayed",
                table: "Batches",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddForeignKey(
                name: "FK_Schedule_ScedhuleType_ScedhuleTypeId",
                table: "Schedule",
                column: "ScedhuleTypeId",
                principalTable: "ScedhuleType",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Schedule_ScedhuleType_ScedhuleTypeId",
                table: "Schedule");

            migrationBuilder.DropColumn(
                name: "IsNameDisplayed",
                table: "Batches");

            migrationBuilder.AddColumn<decimal>(
                name: "Fee",
                table: "Training",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<bool>(
                name: "HasBatches",
                table: "Training",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsFree",
                table: "Training",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<DateTime>(
                name: "RegistrationEnd",
                table: "Training",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "RegistrationStart",
                table: "Training",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "TotalCapacity",
                table: "Training",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<long>(
                name: "TrainingScheduleId",
                table: "Training",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "TrainingStart",
                table: "Training",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AlterColumn<long>(
                name: "ScedhuleTypeId",
                table: "Schedule",
                nullable: false,
                oldClrType: typeof(long),
                oldNullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Training_TrainingScheduleId",
                table: "Training",
                column: "TrainingScheduleId",
                unique: true,
                filter: "[TrainingScheduleId] IS NOT NULL");

            migrationBuilder.AddForeignKey(
                name: "FK_Schedule_ScedhuleType_ScedhuleTypeId",
                table: "Schedule",
                column: "ScedhuleTypeId",
                principalTable: "ScedhuleType",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Training_Schedule_TrainingScheduleId",
                table: "Training",
                column: "TrainingScheduleId",
                principalTable: "Schedule",
                principalColumn: "Id",
                onDelete: ReferentialAction.SetNull);
        }
    }
}
