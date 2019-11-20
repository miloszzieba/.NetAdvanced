using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace DotNetAdvanced.Async
{
    class Program
    {
        public static void Main(string[] args)
        {
            var task = Task.Run(async () =>
            {
                var mainTask = Main();
                Thread.Sleep(10000);
                await mainTask;
            });

            Thread.Sleep(5000);
            
            task.GetAwaiter().GetResult();
        }

        public static async Task Main()
        {
            var onetPageLengthTask = AccessTheWebAsync();

            int i = 1;
            i++;

            var result = await onetPageLengthTask;
        }

        private static async Task<int> AccessTheWebAsync()
        {
            var client = new HttpClient();

            Task<string> getOnetTask = client.GetStringAsync("http://onet.pl");
            Task<string> getWPTask = client.GetStringAsync("http://wp.pl");

            string urlContents = await getOnetTask;
            string content = await getWPTask;

            return urlContents.Length;
        }
    }
}
