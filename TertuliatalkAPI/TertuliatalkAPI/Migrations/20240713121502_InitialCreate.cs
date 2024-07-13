using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TertuliatalkAPI.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "users",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: false),
                    Email = table.Column<string>(type: "text", nullable: false),
                    Password = table.Column<string>(type: "text", nullable: false),
                    Active = table.Column<int>(type: "integer", nullable: false),
                    Role = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "users",
                columns: new[] { "id", "name", "mail", "password", "active", "role" },
                values: new object[,]
                {
                { new Guid("a69c6836-21ec-42db-a771-54340b6c2f89"), "Name_superadmin", "superadmin@gmail.com", "supo", 1, "SuperAdmin" },
                { new Guid("a69c6836-21ec-42db-a771-54340b6c2f90"), "Name_tenantadmin", "tenantadmin@gmail.com", "teno", 1, "TenantAdmin" },
                { new Guid("a69c6836-21ec-42db-a771-54340b6c2f91"), "Name_advisor", "advisor@gmail.com", "ado", 1, "Advisor" },
                { new Guid("a69c6836-21ec-42db-a771-54340b6c2f92"), "Name_user", "user@gmail.com", "uso", 1, "User" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "users");
        }
    }
}
