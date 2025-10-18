using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CMCS.Data.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate5 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "AdditionalNotes",
                table: "Claims",
                type: "nvarchar(1000)",
                maxLength: 1000,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<decimal>(
                name: "HourlyRate",
                table: "Claims",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "HoursWorked",
                table: "Claims",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AdditionalNotes",
                table: "Claims");

            migrationBuilder.DropColumn(
                name: "HourlyRate",
                table: "Claims");

            migrationBuilder.DropColumn(
                name: "HoursWorked",
                table: "Claims");
        }
    }
}
