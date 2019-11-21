using System;
using System.Collections.Generic;
using System.IO;
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
                return await mainTask;
            }).ConfigureAwait(false);

            Thread.Sleep(5000);

            var number = task.GetAwaiter().GetResult();
        }

        public static async Task<int> Main()
        {
            var onetPageLengthTask = AccessTheWebAsync();
            try
            {
                onetPageLengthTask.Wait();
            }
            catch (AggregateException ex)
            {

            }
            try
            {
                var onetPageLengthTask2 = await AccessTheWebAsync();
            }
            catch (ApplicationException ex)
            {

            }

            Thread.Sleep(4000);

            return await onetPageLengthTask;
        }

        private static async Task<int> AccessTheWebAsync()
        {
            var client = new HttpClient();

            var getOnetTask = client.GetStringAsync("http://onet.pl");
            var getWPTask = client.GetStringAsync("http://wp.pl");

            string urlContents = await getOnetTask;
            string content = await getWPTask;

            return urlContents.Length;
        }
    }
}
