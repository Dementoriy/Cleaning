using CleaningDLL;
using System;

namespace test
{
    class Program
    {
        static void Main(string[] args)
        {
            using (ApplicationContext db = new ApplicationContext(ApplicationContext.GetDb()))
            {
                db.SaveChanges();
            }
        }
    }
}
