using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace Week05_2_ErrorHandling
{
    class Program
    {
        private static readonly HttpClient client = new HttpClient();
        static async Task Main(string[] args)
        {
            try
            {
                await GetSiteLengthTaskAsync();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Main 'Task' Catch: {ex.Message}");
            }

            try
            {
                GetSiteLengthVoidAsync(); //we cannot use await on an async void method

                //Since this method uses void, then No 'Task' object means the exception will not be caught in the calling method
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Main 'void' Catch: {ex.Message}");
            }



            Console.WriteLine("All Done");

            Console.ReadLine();
            Console.WriteLine("Really Done!!!");

        }

        /// <summary>
        /// Starts multiple asynchronous tasks, to contact multiple websites
        /// </summary>
        /// <remarks>we are not explicitly returning anything from this method</remarks>
        private static async Task GetSiteLengthTaskAsync()
        {
            ////Error generating list
            var siteList = new List<string> { "yahoo", "Not a website", "google", "msn", "reddit", "stackoverflow", "wired" };

            foreach (string site in siteList)
            {
                var task = client.GetStringAsync($"http://{site}.com");
                await task;
                Console.WriteLine($"{site} content length is {task.Result.Length}");
            }

        }

        /// <summary>
        /// Starts multiple asynchronous tasks, to contact multiple websites
        /// </summary>
        /// <remarks>'async void' should be avoided (use 'async Task' instead), except for event handlers</remarks>
        private static async void GetSiteLengthVoidAsync()
        {
            ////Error generating list
            var siteList = new List<string> { "yahoo", "Not a website", "google", "msn", "reddit", "stackoverflow", "wired" };

            foreach (string site in siteList)
            {
                var task = client.GetStringAsync($"http://{site}.com");
                await task;
                Console.WriteLine($"{site} content length is {task.Result.Length}");
            }

        }
    }
}
