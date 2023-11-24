using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using TestMVC.Dto_s;
using TestMVC.Models;
using TestMVC.Models.ERole;
using Task = TestMVC.Models.Task;

namespace TestMVC.Data
{
    public class AppDbContext:IdentityDbContext<User>
    {
        public AppDbContext(DbContextOptions<AppDbContext> options, IServiceProvider services) : base(options)
        {
            this.Services = services;
        }
        public IServiceProvider Services { get; set; }
        public DbSet<Task> tasks { get; set; }
        public  DbSet<AuditLog> AuditLog { get; set; }
        public DbSet<UserResult> UserResults { get; set; }
        public DbSet<Test> Test { get; set; }


        public DbSet<CkeckTest> ckeckTests { get; set; }


        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.ApplyConfiguration<IdentityRole>(new RoleConfiguration(Services));

            builder.Entity<Test>()
            .HasData(
              new Test
              {
                  Id = 1,
                  Question = "C# tilida qanday operator for loop (sikl) bilan ifodalangan?",
                  Options = new List<string> { "for", "foreach", "while", "do-while" },
                  RightOption = "for"
              },
               new Test
               {
                   Id = 2,
                   Question = "C# tilida string malumotlarni birlashtirish uchun qanday operatordan foydalaniladi?",
                   Options = new List<string> { "+", "*", "&", "-" },
                   RightOption = "+"
               },
               new Test
               {
                   Id = 3,
                   Question = "C# tilidagi 'int' ma'lumot turi necha bayt ekanligini ifodalovchi operator?",
                   Options = new List<string> { "4", "8", "16", "32" },
                   RightOption = "4"
               },
               new Test
               {
                   Id = 4,
                   Question = "C# tilidagi 'if' operatori qanday ifodalangan?",
                   Options = new List<string> { "if (shart) {...}", "if {...} else {...}", "if {...} else if {...}", "agar (shart) {...}" },
                   RightOption = "if (shart) {...}"
               },
               new Test
               {
                   Id = 5,
                   Question = "C# tilidagi 'List' sinfi qanday maqsadda ishlatiladi?",
                   Options = new List<string> { "Fayllarni o'qish", "Matnlar bilan ishlash", "Ro'yxat tuzish", "Sonlarni o'qish" },
                   RightOption = "Ro'yxat tuzish"
               },
               new Test
               {
                   Id = 6,
                   Question = "C# tilidagi 'try-catch' bloklari nima uchun ishlatiladi?",
                   Options = new List<string> { "Intizomiy matnlarni o'qish", "Xatoliklarni tekshirish va qo'llab-quvvatlash", "Sonlarni hisoblash", "Matnlar bilan ishlash" },
                   RightOption = "Xatoliklarni tekshirish va qo'llab-quvvatlash"
               },
               new Test
               {
                   Id = 7,
                   Question = "C# tilidagi 'LINQ' nima uchun ishlatiladi?",
                   Options = new List<string> { "Matnlarni o'qish", "Ro'yxatlarni tahrirlash", "So'rov bilan ma'lumotlarni izlash va filterlash", "Sonlarni hisoblash" },
                   RightOption = "So'rov bilan ma'lumotlarni izlash va filterlash"
               },
               new Test
               {
                   Id = 8,
                   Question = "C# tilidagi 'async' va 'await' nima uchun ishlatiladi?",
                   Options = new List<string> { "Biror amallarni o'zaro boshqarish uchun", "Sonlarni hisoblash", "Matnlarni o'qish", "Ro'yxatlarni tahrirlash" },
                   RightOption = "Biror amallarni o'zaro boshqarish uchun"
               },
               new Test
               {
                   Id = 9,
                   Question = "C# tilidagi 'class' va 'struct' arasida qanday farq bor?",
                   Options = new List<string> { "'class' malumotni o'z ichiga oladi, 'struct' esa notekis ma'lumotlarni", "'struct' malumotni o'z ichiga oladi, 'class' esa notekis ma'lumotlarni", "Farqi yo'q", "'class' va 'struct' bir xil funksiyalarni o'z ichiga oladi" },
                   RightOption = "'class' malumotni o'z ichiga oladi, 'struct' esa notekis ma'lumotlarni"
               },
               new Test
               {
                   Id = 10,
                   Question = "C# tilidagi 'interface' nima uchun ishlatiladi?",
                   Options = new List<string> { "Ma'lumotlarni saqlash", "Funksiyalarni bir nechta klasslarda qayta-qayta ishlatish uchun", "Ro'yxatlarni tahrirlash", "Sonlarni hisoblash" },
                   RightOption = "Funksiyalarni bir nechta klasslarda qayta-qayta ishlatish uchun"
               });
        }
    }
}
