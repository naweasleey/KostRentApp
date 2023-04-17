using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace KostRentApp.Migrations
{
    /// <inheritdoc />
    public partial class fk_status_databooking : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "StatId",
                table: "DataBookings",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_DataBookings_StatId",
                table: "DataBookings",
                column: "StatId");

            migrationBuilder.AddForeignKey(
                name: "FK_DataBookings_Stat_StatId",
                table: "DataBookings",
                column: "StatId",
                principalTable: "Stat",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DataBookings_Stat_StatId",
                table: "DataBookings");

            migrationBuilder.DropIndex(
                name: "IX_DataBookings_StatId",
                table: "DataBookings");

            migrationBuilder.DropColumn(
                name: "StatId",
                table: "DataBookings");
        }
    }
}
