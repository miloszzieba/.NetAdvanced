using DotNetAdvanced.ExtensionsMethods.Models;
using System.Collections.Generic;

namespace DotNetAdvanced.ExtensionsMethods
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            var cars = new List<Car>()
           {
               new Car(){ ProductionYear = 1998, Name = "Skoda", Price = 10_000.00m},
               new Car(){ ProductionYear = 2010, Name = "Toyota", Price = 30_000.00m},
               new Car(){ ProductionYear = 2017, Name = "Volvo", Price = 80_000.00m},
               new Car(){ ProductionYear = 2012, Name = "Ford", Price = 25_000.00m}
           };

            cars = cars.AddTax(23)
                .AddDiscount(1000)
                .ModifyCar(x => x.ProductionYear += 4);
        }
    }
}
