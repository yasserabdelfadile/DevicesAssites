using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebApplication11.Migrations.ApplicationDb
{
    /// <inheritdoc />
    public partial class createAdmin : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("INSERT INTO [dbo].[AspNetUsers] ([Id], [UserName], [NormalizedUserName], [Email], [NormalizedEmail], [EmailConfirmed], [PasswordHash], [SecurityStamp], [ConcurrencyStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEnd], [LockoutEnabled], [AccessFailedCount]) VALUES (N'b5e473a0-6456-436f-a5ce-3df2555bee6f', N'Admin@gmail.com', N'ADMIN@GMAIL.COM', N'Admin@gmail.com', N'ADMIN@GMAIL.COM', 1, N'AQAAAAIAAYagAAAAENT0UsELGCbFk1ky0Y1yK2wLVhu2LISApBXvPbDJLebXffsU6XlXx21VbIz6tuRykw==', N'E5TUZIV4BVUCCWDA5VKGJ42ST3Y754HZ', N'53dd8b1c-6134-4596-851f-23c6beff9e5a', NULL, 0, 0, NULL, 1, 0)");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("DELETE FROM [dbo].[AspNetUsers] WHERE Id='b5e473a0-6456-436f-a5ce-3df2555bee6f' ");
        }
    }
}
