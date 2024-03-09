using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class change : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Acceptation",
                table: "Patients",
                newName: "Acception");

            migrationBuilder.AddColumn<decimal>(
                name: "Pesel",
                table: "Doctors",
                type: "numeric",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.CreateIndex(
                name: "IX_Patients_Pesel",
                table: "Patients",
                column: "Pesel",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Doctors_Pesel",
                table: "Doctors",
                column: "Pesel",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Patients_Pesel",
                table: "Patients");

            migrationBuilder.DropIndex(
                name: "IX_Doctors_Pesel",
                table: "Doctors");

            migrationBuilder.DropColumn(
                name: "Pesel",
                table: "Doctors");

            migrationBuilder.RenameColumn(
                name: "Acception",
                table: "Patients",
                newName: "Acceptation");
        }
    }
}
