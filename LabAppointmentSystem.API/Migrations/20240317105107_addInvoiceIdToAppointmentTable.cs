using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LabAppointmentSystem.API.Migrations
{
    /// <inheritdoc />
    public partial class addInvoiceIdToAppointmentTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "InvoiceId",
                table: "Appointments",
                type: "nvarchar(max)",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "InvoiceId",
                table: "Appointments");
        }
    }
}
