using DotNetAdvanced.AsyncRepository.Models;
using System;
using System.Threading.Tasks;

namespace DotNetAdvanced.AsyncRepository
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Task.Run(async () =>
            {
                var repository = new ProductAsyncRepository("D:\\test.txt");

                var tasks = new Task[5];
                var productTasks = new Task<Product>[5];
                for (int i = 5; i < 10; i++)
                {
                    var task = repository.Add(new Product() { Name = $"Product {i}" });
                    tasks[i - 5] = task;
                    var productTask = repository.GetByNameAsync($"Product {i}");
                    productTasks[i - 5] = productTask;
                }
                await Task.WhenAll(tasks);
                var products = await Task.WhenAll(productTasks);
                foreach (var product in products)
                    Console.WriteLine(product?.Name);

            }).GetAwaiter().GetResult();
            Console.ReadLine();
        }
    }
}
