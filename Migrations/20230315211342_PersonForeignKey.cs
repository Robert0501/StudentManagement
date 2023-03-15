using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace StudentManagement.Migrations
{
    /// <inheritdoc />
    public partial class PersonForeignKey : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Person_AddressId",
                table: "Person");

            migrationBuilder.AddColumn<int>(
                name: "PersonId",
                table: "Address",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Person_AddressId",
                table: "Person",
                column: "AddressId",
                unique: true,
                filter: "[AddressId] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Address_PersonId",
                table: "Address",
                column: "PersonId");

            migrationBuilder.AddForeignKey(
                name: "FK_Address_Person_PersonId",
                table: "Address",
                column: "PersonId",
                principalTable: "Person",
                principalColumn: "PersonId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Address_Person_PersonId",
                table: "Address");

            migrationBuilder.DropIndex(
                name: "IX_Person_AddressId",
                table: "Person");

            migrationBuilder.DropIndex(
                name: "IX_Address_PersonId",
                table: "Address");

            migrationBuilder.DropColumn(
                name: "PersonId",
                table: "Address");

            migrationBuilder.CreateIndex(
                name: "IX_Person_AddressId",
                table: "Person",
                column: "AddressId");
        }
    }
}
