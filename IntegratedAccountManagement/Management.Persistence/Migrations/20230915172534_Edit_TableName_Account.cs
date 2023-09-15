using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace IntegratedAccountManagement.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class EditTableNameAccount : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_logs",
                schema: "public",
                table: "logs");

            migrationBuilder.RenameTable(
                name: "logs",
                schema: "public",
                newName: "accounts",
                newSchema: "public");

            migrationBuilder.AddPrimaryKey(
                name: "PK_accounts",
                schema: "public",
                table: "accounts",
                column: "id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_accounts",
                schema: "public",
                table: "accounts");

            migrationBuilder.RenameTable(
                name: "accounts",
                schema: "public",
                newName: "logs",
                newSchema: "public");

            migrationBuilder.AddPrimaryKey(
                name: "PK_logs",
                schema: "public",
                table: "logs",
                column: "id");
        }
    }
}
