using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebApplication11.Migrations.ApplicationDb
{
    /// <inheritdoc />
    public partial class AssignRolesToUser : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("INSERT INTO [dbo].[AspNetUserRoles] (UserId,RoleId) SELECT 'b5e473a0-6456-436f-a5ce-3df2555bee6f',Id FROM [dbo].[AspNetRoles]");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("DELETE FROM [dbo].[AspNetUserRoles] WHERE UserId='b5e473a0-6456-436f-a5ce-3df2555bee6f'");
        }
    }
}
