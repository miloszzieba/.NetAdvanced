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
            var service = new HttpService(httpClient, "http://localhost:81/api");
            var response = service.Get<string[]>("values");
        }
    }
}
