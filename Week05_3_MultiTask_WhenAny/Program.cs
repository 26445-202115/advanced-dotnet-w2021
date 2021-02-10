using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace Week05_3_MultiTask_WhenAny
{
    class Program
    {
        private static readonly HttpClient client = new HttpClient();
        static async Task Main(string[] args)
        {
            try
            {
                await GetSiteLengthAsync();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Main Catch: {ex.Message}");
            }
            Console.WriteLine("All Done");
        }

        /// <summary>
        /// Starts multiple asynchronous tasks, to contact multiple websites
        /// </summary>
        /// <remarks>we are not explicitly returning anything from this method</remarks>
        private static async Task GetSiteLengthAsync()
        {
            var siteList = new List<string> { "yahoo", "google", "msn", "reddit", "stackoverflow"};

            //Using LINQ to create and invoke multiple tasks using the sitelist object
            List<Task<string>> taskList = (from site in siteList
                                           select client.GetStringAsync($"http://{site}.com")).ToList();

            int sumLength = 0;
            Console.WriteLine("Starting While Loop!!");
            while (taskList.Any()) //Check if there is still any (pending) tasks in the tasklist 
            {
                 //Retrieve the task object for whichever task that finishes first; there is no guarantee of what order this will be. as a matter of fact, if you run this multipole times; you are more than likely to get different order every few times
                var firstToFinish = await Task.WhenAny(taskList);


                Console.WriteLine($"content length is {firstToFinish.Result.Length}");
                sumLength += firstToFinish.Result.Length;
                taskList.Remove(firstToFinish); //after completion remove each task from the taskList
            }


            Console.WriteLine($"Total length: {sumLength}");


        }
    }
}
