using Microsoft.EntityFrameworkCore.Migrations;

namespace Infrastructure.Migrations
{
    public partial class AddingDefaultUser : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "3710ca18-c46d-4e81-aa08-ff1bb13085e3");

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "44764de0-e0f2-4843-b684-73c137a0375e", "ea9c270d-4b99-4ef3-aa9e-1659ac71bcef" });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "44764de0-e0f2-4843-b684-73c137a0375e");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "ea9c270d-4b99-4ef3-aa9e-1659ac71bcef");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "f6b25011-ebbf-4b35-9412-2a5baa3f1e03", "e125f437-37c6-47e7-ba28-b9d02b3f9532", "Admin", "ADMIN" },
                    { "410b2e1d-1ba5-4326-911d-e3a9465a8fb0", "89e19610-ab2e-4295-ab50-525f5d1b5ede", "User", "USER" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { "e2ce1ccc-8703-4d4c-a45f-9e9fbd26dc13", 0, "9d7acd33-0fa5-4214-9709-ecb433a29d95", "testUser@test.com", false, false, null, "TESTUSER@TEST.COM", "TESTUSER", "AQAAAAEAACcQAAAAELAzhcUxax1Wem8I+xdurnj/b+rm+MVzsQJxVAvuXUpMpBkuogTdFg5ZkPRdtVneng==", null, false, "a1bd267e-4706-44c2-ab01-c350b826a0a2", false, "testUser" },
                    { "920cd937-aa8a-4528-b2db-7a4466db27f0", 0, "7e4f306a-1d4e-4a96-88c8-eaf0679fe608", "testAdmin@test.com", false, false, null, "TESTADMIN@TEST.COM", "TESTADMIN", "AQAAAAEAACcQAAAAEGmI9bKDfr3Uk0cL4UypoWR/RQzVkRKIKcDf/KSyN6mZt+ILTjNVwA8ePjLFayTl+Q==", null, false, "025c8d7a-dcc0-410b-97b3-95cf007c13c9", false, "testAdmin" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "f6b25011-ebbf-4b35-9412-2a5baa3f1e03", "920cd937-aa8a-4528-b2db-7a4466db27f0" });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "410b2e1d-1ba5-4326-911d-e3a9465a8fb0", "e2ce1ccc-8703-4d4c-a45f-9e9fbd26dc13" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "f6b25011-ebbf-4b35-9412-2a5baa3f1e03", "920cd937-aa8a-4528-b2db-7a4466db27f0" });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "410b2e1d-1ba5-4326-911d-e3a9465a8fb0", "e2ce1ccc-8703-4d4c-a45f-9e9fbd26dc13" });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "410b2e1d-1ba5-4326-911d-e3a9465a8fb0");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "f6b25011-ebbf-4b35-9412-2a5baa3f1e03");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "920cd937-aa8a-4528-b2db-7a4466db27f0");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "e2ce1ccc-8703-4d4c-a45f-9e9fbd26dc13");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "44764de0-e0f2-4843-b684-73c137a0375e", "f47c9fbf-5d25-430e-91cf-6de4ea49ee88", "Admin", "ADMIN" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "3710ca18-c46d-4e81-aa08-ff1bb13085e3", "bf3c499b-a646-48d6-8eb6-a050d03f693a", "User", "USER" });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "ea9c270d-4b99-4ef3-aa9e-1659ac71bcef", 0, "b993d027-2ed0-4771-b913-27d3b04626ed", "test@test.com", false, false, null, "TEST@TEST.COM", "TEST@TEST.COM", "AQAAAAEAACcQAAAAEJxZZr503kDyOSmweVFeWrXEgwtQOmUNC6cexIOQD2XWxFKDuojpZrLQKQac0qlrrw==", null, false, "dcda6f94-78a9-42a0-bf3f-b906c1dbd157", false, "test@test.com" });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "44764de0-e0f2-4843-b684-73c137a0375e", "ea9c270d-4b99-4ef3-aa9e-1659ac71bcef" });
        }
    }
}
