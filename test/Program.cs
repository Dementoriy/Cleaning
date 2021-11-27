using CleaningDLL;
using System;

namespace test
{
    class Program
    {
        static void Main(string[] args)
        {
            using (ApplicationContext db = new ApplicationContext())
            {
                // создаем два объекта User
                Application user1 = new Application { Status = "ГОТОВ" };
                Application user2 = new Application { Status = "НЕ ГОТОВ" };

                // добавляем их в бд
                db.Application.AddRange(user1, user2);
                db.SaveChanges();
            }
        }
    }
}
