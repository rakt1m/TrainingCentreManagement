using Microsoft.EntityFrameworkCore.Migrations;

namespace TrainingCentreManagement.DatabaseContext.Migrations
{
    public partial class RemoveTrainerId : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "TrainerId",
                table: "Batches");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "TrainerId",
                table: "Batches",
                nullable: false,
                defaultValue: 0);
        }
    }
}
