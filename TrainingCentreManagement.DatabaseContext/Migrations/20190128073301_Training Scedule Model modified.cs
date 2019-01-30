using Microsoft.EntityFrameworkCore.Migrations;

namespace TrainingCentreManagement.DatabaseContext.Migrations
{
    public partial class TrainingSceduleModelmodified : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Batches_Schedule_BatchScheduleId",
                table: "Batches");

            migrationBuilder.DropForeignKey(
                name: "FK_Schedule_ScedhuleType_ScedhuleTypeId",
                table: "Schedule");

            migrationBuilder.DropForeignKey(
                name: "FK_ScheduleDetail_Schedule_ScheduleId",
                table: "ScheduleDetail");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Schedule",
                table: "Schedule");

            migrationBuilder.RenameTable(
                name: "Schedule",
                newName: "Schedules");

            migrationBuilder.RenameIndex(
                name: "IX_Schedule_ScedhuleTypeId",
                table: "Schedules",
                newName: "IX_Schedules_ScedhuleTypeId");

            migrationBuilder.AddColumn<long>(
                name: "TrainingId",
                table: "Schedules",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Schedules",
                table: "Schedules",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_Schedules_TrainingId",
                table: "Schedules",
                column: "TrainingId");

            migrationBuilder.AddForeignKey(
                name: "FK_Batches_Schedules_BatchScheduleId",
                table: "Batches",
                column: "BatchScheduleId",
                principalTable: "Schedules",
                principalColumn: "Id",
                onDelete: ReferentialAction.SetNull);

            migrationBuilder.AddForeignKey(
                name: "FK_ScheduleDetail_Schedules_ScheduleId",
                table: "ScheduleDetail",
                column: "ScheduleId",
                principalTable: "Schedules",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Schedules_ScedhuleType_ScedhuleTypeId",
                table: "Schedules",
                column: "ScedhuleTypeId",
                principalTable: "ScedhuleType",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Schedules_Training_TrainingId",
                table: "Schedules",
                column: "TrainingId",
                principalTable: "Training",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Batches_Schedules_BatchScheduleId",
                table: "Batches");

            migrationBuilder.DropForeignKey(
                name: "FK_ScheduleDetail_Schedules_ScheduleId",
                table: "ScheduleDetail");

            migrationBuilder.DropForeignKey(
                name: "FK_Schedules_ScedhuleType_ScedhuleTypeId",
                table: "Schedules");

            migrationBuilder.DropForeignKey(
                name: "FK_Schedules_Training_TrainingId",
                table: "Schedules");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Schedules",
                table: "Schedules");

            migrationBuilder.DropIndex(
                name: "IX_Schedules_TrainingId",
                table: "Schedules");

            migrationBuilder.DropColumn(
                name: "TrainingId",
                table: "Schedules");

            migrationBuilder.RenameTable(
                name: "Schedules",
                newName: "Schedule");

            migrationBuilder.RenameIndex(
                name: "IX_Schedules_ScedhuleTypeId",
                table: "Schedule",
                newName: "IX_Schedule_ScedhuleTypeId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Schedule",
                table: "Schedule",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Batches_Schedule_BatchScheduleId",
                table: "Batches",
                column: "BatchScheduleId",
                principalTable: "Schedule",
                principalColumn: "Id",
                onDelete: ReferentialAction.SetNull);

            migrationBuilder.AddForeignKey(
                name: "FK_Schedule_ScedhuleType_ScedhuleTypeId",
                table: "Schedule",
                column: "ScedhuleTypeId",
                principalTable: "ScedhuleType",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ScheduleDetail_Schedule_ScheduleId",
                table: "ScheduleDetail",
                column: "ScheduleId",
                principalTable: "Schedule",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
