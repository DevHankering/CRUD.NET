using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebApplication5.Migrations
{
    /// <inheritdoc />
    public partial class update10 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_Student_Address_Id",
                table: "Student",
                column: "Address_Id",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Student_Address_Address_Id",
                table: "Student",
                column: "Address_Id",
                principalTable: "Address",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Student_Address_Address_Id",
                table: "Student");

            migrationBuilder.DropIndex(
                name: "IX_Student_Address_Id",
                table: "Student");
        }
    }
}
