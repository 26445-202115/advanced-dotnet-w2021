using System;
using System.Threading.Tasks;
using Week06_2_AsyncDatabaseAccess.Data;
using Week06_2_AsyncDatabaseAccess.Models;

namespace Week06_2_AsyncDatabaseAccess
{
    class Program
    {
        private static AppDbContext db = new AppDbContext();
        static async Task Main(string[] args)
        {

            Console.WriteLine("Starting Sync. DB Operation");

            //Save to DB Sync
            DbSave();


            Console.WriteLine("Press enter to continue");

            Console.ReadLine();

            Console.WriteLine("Starting Async. DB Operation");

            //Save to DB Async
            var task = DbSaveAsync();

            Console.WriteLine("Continue");
            await task;



        }

        private static void DbSave()
        {
            //Synchronous Database Insert
            for (int i = 0; i < 100000; i++)
            {
                Person newPerson = new Person()
                {
                    FirstName = "Sync",
                    LastName = "Doe",
                    CreationTime = DateTime.Now
                };

                db.Persons.Add(newPerson);  //Add the newly object to the queue to be inserted later
            }


            db.SaveChanges();   //New records are not saved in the database unless SaveChanges(), or SaveChangesAsync() is called.


        }

        private static async Task DbSaveAsync()
        {

            //Asynchronous Database Insert
            for (int i = 0; i < 100000; i++)
            {
                Person newPerson = new Person()
                {
                    FirstName = "Async",
                    LastName = "Doe",
                    CreationTime = DateTime.Now
                };

                db.Persons.Add(newPerson);  //Add the newly object to the queue to be inserted later
            }

            Console.WriteLine("before async");
            await db.SaveChangesAsync();    //New records are not saved in the database unless SaveChanges(), or SaveChangesAsync() is called.
            Console.WriteLine("Async Complete!");


        }
    }
}
