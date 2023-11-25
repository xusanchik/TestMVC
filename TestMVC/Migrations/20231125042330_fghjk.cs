using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace TestMVC.Migrations
{
    /// <inheritdoc />
    public partial class fghjk : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "300c42ac-36d5-46d1-9320-ef003ecdbe82");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "5621cb2b-fd46-42a8-8975-3afda5ac6c8b");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "9a1a3041-40e7-41da-affa-e6a214048b9d");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "924c65a0-2bab-43bb-b341-0c1fd59d3acd", null, "ADMIN", "ADMIN" },
                    { "9df12ccb-af88-475e-97a0-5a47226fa086", null, "MANAGER", "MANAGER" },
                    { "abe4c73e-ff68-4567-9df1-115ab2e3af1a", null, "USER", "USER" }
                });

            migrationBuilder.UpdateData(
                table: "Test",
                keyColumn: "Id",
                keyValue: 1,
                column: "Options",
                value: new List<string> { "for", "foreach", "while", "do-while" });

            migrationBuilder.UpdateData(
                table: "Test",
                keyColumn: "Id",
                keyValue: 2,
                column: "Options",
                value: new List<string> { "+", "*", "&", "-" });

            migrationBuilder.UpdateData(
                table: "Test",
                keyColumn: "Id",
                keyValue: 3,
                column: "Options",
                value: new List<string> { "4", "8", "16", "32" });

            migrationBuilder.UpdateData(
                table: "Test",
                keyColumn: "Id",
                keyValue: 4,
                column: "Options",
                value: new List<string> { "if (shart) {...}", "if {...} else {...}", "if {...} else if {...}", "agar (shart) {...}" });

            migrationBuilder.UpdateData(
                table: "Test",
                keyColumn: "Id",
                keyValue: 5,
                column: "Options",
                value: new List<string> { "Fayllarni o'qish", "Matnlar bilan ishlash", "Ro'yxat tuzish", "Sonlarni o'qish" });

            migrationBuilder.UpdateData(
                table: "Test",
                keyColumn: "Id",
                keyValue: 6,
                column: "Options",
                value: new List<string> { "Intizomiy matnlarni o'qish", "Xatoliklarni tekshirish va qo'llab-quvvatlash", "Sonlarni hisoblash", "Matnlar bilan ishlash" });

            migrationBuilder.UpdateData(
                table: "Test",
                keyColumn: "Id",
                keyValue: 7,
                column: "Options",
                value: new List<string> { "Matnlarni o'qish", "Ro'yxatlarni tahrirlash", "So'rov bilan ma'lumotlarni izlash va filterlash", "Sonlarni hisoblash" });

            migrationBuilder.UpdateData(
                table: "Test",
                keyColumn: "Id",
                keyValue: 8,
                column: "Options",
                value: new List<string> { "Biror amallarni o'zaro boshqarish uchun", "Sonlarni hisoblash", "Matnlarni o'qish", "Ro'yxatlarni tahrirlash" });

            migrationBuilder.UpdateData(
                table: "Test",
                keyColumn: "Id",
                keyValue: 9,
                column: "Options",
                value: new List<string> { "'class' malumotni o'z ichiga oladi, 'struct' esa notekis ma'lumotlarni", "'struct' malumotni o'z ichiga oladi, 'class' esa notekis ma'lumotlarni", "Farqi yo'q", "'class' va 'struct' bir xil funksiyalarni o'z ichiga oladi" });

            migrationBuilder.UpdateData(
                table: "Test",
                keyColumn: "Id",
                keyValue: 10,
                column: "Options",
                value: new List<string> { "Ma'lumotlarni saqlash", "Funksiyalarni bir nechta klasslarda qayta-qayta ishlatish uchun", "Ro'yxatlarni tahrirlash", "Sonlarni hisoblash" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "924c65a0-2bab-43bb-b341-0c1fd59d3acd");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "9df12ccb-af88-475e-97a0-5a47226fa086");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "abe4c73e-ff68-4567-9df1-115ab2e3af1a");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "300c42ac-36d5-46d1-9320-ef003ecdbe82", null, "ADMIN", "ADMIN" },
                    { "5621cb2b-fd46-42a8-8975-3afda5ac6c8b", null, "MANAGER", "MANAGER" },
                    { "9a1a3041-40e7-41da-affa-e6a214048b9d", null, "USER", "USER" }
                });

            migrationBuilder.UpdateData(
                table: "Test",
                keyColumn: "Id",
                keyValue: 1,
                column: "Options",
                value: new List<string> { "for", "foreach", "while", "do-while" });

            migrationBuilder.UpdateData(
                table: "Test",
                keyColumn: "Id",
                keyValue: 2,
                column: "Options",
                value: new List<string> { "+", "*", "&", "-" });

            migrationBuilder.UpdateData(
                table: "Test",
                keyColumn: "Id",
                keyValue: 3,
                column: "Options",
                value: new List<string> { "4", "8", "16", "32" });

            migrationBuilder.UpdateData(
                table: "Test",
                keyColumn: "Id",
                keyValue: 4,
                column: "Options",
                value: new List<string> { "if (shart) {...}", "if {...} else {...}", "if {...} else if {...}", "agar (shart) {...}" });

            migrationBuilder.UpdateData(
                table: "Test",
                keyColumn: "Id",
                keyValue: 5,
                column: "Options",
                value: new List<string> { "Fayllarni o'qish", "Matnlar bilan ishlash", "Ro'yxat tuzish", "Sonlarni o'qish" });

            migrationBuilder.UpdateData(
                table: "Test",
                keyColumn: "Id",
                keyValue: 6,
                column: "Options",
                value: new List<string> { "Intizomiy matnlarni o'qish", "Xatoliklarni tekshirish va qo'llab-quvvatlash", "Sonlarni hisoblash", "Matnlar bilan ishlash" });

            migrationBuilder.UpdateData(
                table: "Test",
                keyColumn: "Id",
                keyValue: 7,
                column: "Options",
                value: new List<string> { "Matnlarni o'qish", "Ro'yxatlarni tahrirlash", "So'rov bilan ma'lumotlarni izlash va filterlash", "Sonlarni hisoblash" });

            migrationBuilder.UpdateData(
                table: "Test",
                keyColumn: "Id",
                keyValue: 8,
                column: "Options",
                value: new List<string> { "Biror amallarni o'zaro boshqarish uchun", "Sonlarni hisoblash", "Matnlarni o'qish", "Ro'yxatlarni tahrirlash" });

            migrationBuilder.UpdateData(
                table: "Test",
                keyColumn: "Id",
                keyValue: 9,
                column: "Options",
                value: new List<string> { "'class' malumotni o'z ichiga oladi, 'struct' esa notekis ma'lumotlarni", "'struct' malumotni o'z ichiga oladi, 'class' esa notekis ma'lumotlarni", "Farqi yo'q", "'class' va 'struct' bir xil funksiyalarni o'z ichiga oladi" });

            migrationBuilder.UpdateData(
                table: "Test",
                keyColumn: "Id",
                keyValue: 10,
                column: "Options",
                value: new List<string> { "Ma'lumotlarni saqlash", "Funksiyalarni bir nechta klasslarda qayta-qayta ishlatish uchun", "Ro'yxatlarni tahrirlash", "Sonlarni hisoblash" });
        }
    }
}
