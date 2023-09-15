using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace IntegratedAccountManagement.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class CreateTableAccount : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "public");

            migrationBuilder.CreateTable(
                name: "logs",
                schema: "public",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    accounttype = table.Column<string>(name: "account_type", type: "varchar(10)", nullable: false),
                    accountamount = table.Column<decimal>(name: "account_amount", type: "numeric(18,2)", nullable: false),
                    createdat = table.Column<DateTime>(name: "created_at", type: "timestamp", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_logs", x => x.id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "logs",
                schema: "public");
        }
    }
}
