using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LabAppointmentSystem.API.Migrations
{
    /// <inheritdoc />
    public partial class modifyAppointmentTest : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "TechnicianId",
                table: "AppointmentTests",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_AppointmentTests_TechnicianId",
                table: "AppointmentTests",
                column: "TechnicianId");

            migrationBuilder.AddForeignKey(
                name: "FK_AppointmentTests_Technicians_TechnicianId",
                table: "AppointmentTests",
                column: "TechnicianId",
                principalTable: "Technicians",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AppointmentTests_Technicians_TechnicianId",
                table: "AppointmentTests");

            migrationBuilder.DropIndex(
                name: "IX_AppointmentTests_TechnicianId",
                table: "AppointmentTests");

            migrationBuilder.DropColumn(
                name: "TechnicianId",
                table: "AppointmentTests");
        }
    }
}
