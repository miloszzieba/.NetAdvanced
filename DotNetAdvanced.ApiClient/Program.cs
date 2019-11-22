using DotNetAdvanced.ApiClient.Services;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace DotNetAdvanced.ApiClient
{
    class Program
    {
        static void Main(string[] args)
        {
            var httpClient = new HttpClient();
            var service = new HttpService(httpClient, "http://localhost:51059/api");
            var response = service.Get<string[]>("values");
            Console.WriteLine(response[0]);
            Console.WriteLine(response[1]);
            Console.ReadLine();
        }
    }
}
