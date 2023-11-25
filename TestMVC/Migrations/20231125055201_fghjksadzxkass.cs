using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace TestMVC.Migrations
{
    /// <inheritdoc />
    public partial class fghjksadzxkass : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "04a1b3b8-3cb2-4ba3-94ee-f46325b939e8");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "32912680-c50d-495d-aceb-973ed7eabd5c");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "4eb9a5c2-5c9b-458f-b81b-11eec7322d17");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "727acda1-4512-428a-8708-745ea2ba8068", null, "USER", "USER" },
                    { "bafeb63c-7def-4263-a332-d3fd369fa0d0", null, "MANAGER", "MANAGER" },
                    { "bc2f5a5c-e718-4fdc-942c-9f61a354f0aa", null, "ADMIN", "ADMIN" }
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
                keyValue: "727acda1-4512-428a-8708-745ea2ba8068");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "bafeb63c-7def-4263-a332-d3fd369fa0d0");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "bc2f5a5c-e718-4fdc-942c-9f61a354f0aa");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "04a1b3b8-3cb2-4ba3-94ee-f46325b939e8", null, "USER", "USER" },
                    { "32912680-c50d-495d-aceb-973ed7eabd5c", null, "ADMIN", "ADMIN" },
                    { "4eb9a5c2-5c9b-458f-b81b-11eec7322d17", null, "MANAGER", "MANAGER" }
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
