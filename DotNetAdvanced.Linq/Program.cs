using DotNetAdvanced.Linq.Models;
using System.Collections.Generic;
using System.Linq;

namespace DotNetAdvanced.Linq
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            var cars = new List<Car>()
           {
               new Car(){ ClientId = 1, ProductionYear = 1998, Name = "Skoda", Price = 10_000.00m},
               new Car(){ ClientId = 1, ProductionYear = 2010, Name = "Toyota", Price = 30_000.00m},
               new Car(){ ClientId = 1, ProductionYear = 2017, Name = "Volvo", Price = 80_000.00m},
               new Car(){ ClientId = 1, ProductionYear = 2012, Name = "Ford", Price = 25_000.00m}
           };

            //Najbardziej popularne
            var list = cars.Where(x => x.ProductionYear > 2000)
                .ToList();

            var enumerable = cars
                .Select(x => new { Price = x.Price * 100 });

            var car1 = cars.First(x => x.ProductionYear > 2011);
            var car2 = cars.FirstOrDefault(x => x.ProductionYear > 2011);
            var car3 = cars.Single(x => x.ProductionYear > 2013);
            var car4 = cars.SingleOrDefault(x => x.ProductionYear > 2013);

            var anyCars = cars.Any(x => x.ProductionYear > 2011);
            var containsCars = cars.Contains(car1);

            var distinctCars = cars.Distinct();

            var pagedCars = cars
                .Skip(2)
                .Take(2);

            var orderedCars = cars.OrderBy(x => x.ProductionYear);
            var descendingCars = cars.OrderByDescending(x => x.ProductionYear);

            var sumCars = cars.Sum(x => x.ProductionYear);
            var averageCars = cars.Average(x => x.ProductionYear);
            var maxCarProductionYear = cars.Max(x => x.ProductionYear);
            var minCarProductionYear = cars.Min(x => x.ProductionYear);

            var lastCar = cars.Last(x => x.ProductionYear < 2010);

            var allCars = cars.All(x => x.ProductionYear > 1990);

            var castedCars = cars.Cast<object>();

            var skipWhileCars = cars.SkipWhile(x => x.ProductionYear < 2000);
            var takeWhileCars = cars.TakeWhile(x => x.ProductionYear < 2000);

            //Advanced
            var clients = new List<Client>()
            {
                new Client()
                {
                    Id = 1,
                    IsBussiness = true,
                    Cars = new List<Car>()
                    {
                       new Car(){ ProductionYear = 1998, Name = "Skoda", Price = 10_000.00m},
                       new Car(){ ProductionYear = 2010, Name = "Toyota", Price = 30_000.00m},
                       new Car(){ ProductionYear = 2017, Name = "Volvo", Price = 80_000.00m},
                       new Car(){ ProductionYear = 2012, Name = "Ford", Price = 25_000.00m}
                    }
                },
                new Client()
                {
                    Id = 2,
                    IsBussiness = false,
                    Cars = new List<Car>()
                    {
                        new Car(){ ProductionYear = 2005, Name = "Skoda", Price = 10_000.00m},
                        new Car(){ ProductionYear = 2009, Name = "Toyota", Price = 30_000.00m}
                    }
                }
            };

            var selectManyCars = clients
                .Where(x => x.IsBussiness)
                .SelectMany(x => x.Cars.Select(y => new
                {
                    Car = y,
                    IsBussiness = x.IsBussiness
                }));


            var joinCars = from car in cars
                           join client in clients
                           on new { Id = car.ClientId, Year = car.ProductionYear }
                           equals new { Id = client.Id, Year = 2004 }
                           where client.IsBussiness == true
                           select new { Car = car, IsBussiness = client.IsBussiness };

            joinCars = cars.Join(clients,
                car => new { Id = car.ClientId, Year = car.ProductionYear },
                client => new { Id = client.Id, Year = 2004 },
                (car, client) => new { Car = car, IsBussiness = client.IsBussiness });

            var groupJoin = clients.GroupJoin(cars,
                client => client.Id,
                car => car.ClientId,
                (client, clientCars) => new { Client = client, Cars = clientCars });

            var leftOuterJoin = clients.GroupJoin(cars,
                client => client.Id,
                car => car.ClientId,
                (client, clientCars) => new { Client = client, Cars = clientCars.DefaultIfEmpty() });

            var clientList = clients.GroupBy(x => x.IsBussiness)
                .ToDictionary(x => x.Key, x => x.ToList())
                .Where(x => x.Key == true);

            var aggregate = cars.Aggregate(0, (sum, car) =>
            {
                sum += car.ProductionYear;
                return sum;
            });

        }
    }
}
