using Microsoft.EntityFrameworkCore.Migrations;

namespace TrainingCentreManagement.DatabaseContext.Migrations
{
    public partial class AppRoleAddedToDbContext : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<long>(
                name: "ScedhuleTypeId",
                table: "Schedule",
                nullable: true,
                oldClrType: typeof(long));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<long>(
                name: "ScedhuleTypeId",
                table: "Schedule",
                nullable: false,
                oldClrType: typeof(long),
                oldNullable: true);
        }
    }
}
