using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebApplication5.Migrations
{
    /// <inheritdoc />
    public partial class update2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Address_Student_StudentId",
                table: "Address");

            migrationBuilder.DropForeignKey(
                name: "FK_Images_Student_StudentId",
                table: "Images");

            migrationBuilder.DropForeignKey(
                name: "FK_Images_Student_StudentId1",
                table: "Images");

            migrationBuilder.DropIndex(
                name: "IX_Images_StudentId",
                table: "Images");

            migrationBuilder.DropIndex(
                name: "IX_Images_StudentId1",
                table: "Images");

            migrationBuilder.DropIndex(
                name: "IX_Address_StudentId",
                table: "Address");

            migrationBuilder.DropColumn(
                name: "StudentId",
                table: "Images");

            migrationBuilder.DropColumn(
                name: "StudentId1",
                table: "Images");

            migrationBuilder.DropColumn(
                name: "StudentId",
                table: "Address");

            migrationBuilder.AddColumn<int>(
                name: "AddressId",
                table: "Student",
                type: "integer",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ImageId",
                table: "Student",
                type: "integer",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Student_AddressId",
                table: "Student",
                column: "AddressId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Student_ImageId",
                table: "Student",
                column: "ImageId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Student_Address_AddressId",
                table: "Student",
                column: "AddressId",
                principalTable: "Address",
                principalColumn: "AddressId");

            migrationBuilder.AddForeignKey(
                name: "FK_Student_Images_ImageId",
                table: "Student",
                column: "ImageId",
                principalTable: "Images",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Student_Address_AddressId",
                table: "Student");

            migrationBuilder.DropForeignKey(
                name: "FK_Student_Images_ImageId",
                table: "Student");

            migrationBuilder.DropIndex(
                name: "IX_Student_AddressId",
                table: "Student");

            migrationBuilder.DropIndex(
                name: "IX_Student_ImageId",
                table: "Student");

            migrationBuilder.DropColumn(
                name: "AddressId",
                table: "Student");

            migrationBuilder.DropColumn(
                name: "ImageId",
                table: "Student");

            migrationBuilder.AddColumn<int>(
                name: "StudentId",
                table: "Images",
                type: "integer",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "StudentId1",
                table: "Images",
                type: "integer",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "StudentId",
                table: "Address",
                type: "integer",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Images_StudentId",
                table: "Images",
                column: "StudentId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Images_StudentId1",
                table: "Images",
                column: "StudentId1");

            migrationBuilder.CreateIndex(
                name: "IX_Address_StudentId",
                table: "Address",
                column: "StudentId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Address_Student_StudentId",
                table: "Address",
                column: "StudentId",
                principalTable: "Student",
                principalColumn: "StudentId");

            migrationBuilder.AddForeignKey(
                name: "FK_Images_Student_StudentId",
                table: "Images",
                column: "StudentId",
                principalTable: "Student",
                principalColumn: "StudentId");

            migrationBuilder.AddForeignKey(
                name: "FK_Images_Student_StudentId1",
                table: "Images",
                column: "StudentId1",
                principalTable: "Student",
                principalColumn: "StudentId");
        }
    }
}
