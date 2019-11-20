using DotNetAdvanced.Linq.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DotNetAdvanced.Linq
{
    public static class Excercises
    {
        public static void Excercise1()
        {
            var cars = new List<Car>()
            {
               new Car(){ ClientId = 1, ProductionYear = 1998, Name = "Skoda", Price = 10_000.00m},
               new Car(){ ClientId = 1, ProductionYear = 2010, Name = "Toyota", Price = 30_000.00m},
               new Car(){ ClientId = 1, ProductionYear = 2017, Name = "Volvo", Price = 80_000.00m},
               new Car(){ ClientId = 1, ProductionYear = 2012, Name = "Ford", Price = 25_000.00m}
            };

            cars.Average(x => x.Price);

            cars.Select(x => x.Price)
                .Average();
        }

        public static void Excercise2()
        {
            var directory = @"D:\Downloads";
            var extensionGroups = Directory.GetFiles(directory, "*", SearchOption.AllDirectories)
                                 .GroupBy(x => Path.GetExtension(x));

            foreach (var extension in extensionGroups)
            {
                Console.WriteLine($"{extension.Key}:");
                foreach (var filePath in extension.ToList())
                    Console.WriteLine(filePath);
            }

            //Rozwiązanie z SelectMany (ale bez 
            Directory.GetFiles(directory, "*", SearchOption.AllDirectories)
                                 .GroupBy(x => Path.GetExtension(x))
                                 .SelectMany(x => x.AsEnumerable())
                                 .ToList()
                                 .ForEach(x => Console.WriteLine(x));
        }

        public static IEnumerable<Car> Excercise3(Func<Car, bool> predicate, int x, int y)
        {
            var cars = new List<Car>()
            {
               new Car(){ ClientId = 1, ProductionYear = 1998, Name = "Skoda", Price = 10_000.00m},
               new Car(){ ClientId = 1, ProductionYear = 2010, Name = "Toyota", Price = 30_000.00m},
               new Car(){ ClientId = 1, ProductionYear = 2017, Name = "Volvo", Price = 80_000.00m},
               new Car(){ ClientId = 1, ProductionYear = 2012, Name = "Ford", Price = 25_000.00m}
            };

            return cars.Where(predicate)
                .OrderBy(o => o.ProductionYear)
                .Skip((x - 1) * y)
                .Take(y);
        }

        public static double Excercise4()
        {
            var list = new List<int>() { 1, 2, 3, 4, 5 };

            var average = list.Average();

            //Wersja łatwa
            var sum = list.Sum(x => Math.Pow(x - average, 2));
            var result = Math.Sqrt(sum / list.Count);

            //Wersja trudna
            return list.Aggregate(0d, (seed, x) => seed + Math.Pow(x - average, 2), 
                seed => Math.Sqrt(seed / list.Count));
        }
    }
}
