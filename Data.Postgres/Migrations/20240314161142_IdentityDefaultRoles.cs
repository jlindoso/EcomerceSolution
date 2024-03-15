using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Data.Postgres.Migrations
{
    /// <inheritdoc />
    public partial class IdentityDefaultRoles : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "7a98150a-24d6-4d29-aac2-21cd1f3602c1", "eba79445-099f-4167-9f5a-c6b525f7af4c", "Administrator", "Admin" },
                    { "a061e62e-6719-42ff-a4e9-9004f36805f5", "dfa0a43c-2b47-492d-b23f-461f74c58559", "Manager", "Manager" },
                    { "e4d5185c-fb4c-47da-842c-94f25ed94246", "85b69ea8-048c-4d54-998c-8c88ee9f9c9e", "Customer", "Customer" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "7a98150a-24d6-4d29-aac2-21cd1f3602c1");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "a061e62e-6719-42ff-a4e9-9004f36805f5");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "e4d5185c-fb4c-47da-842c-94f25ed94246");
        }
    }
}
