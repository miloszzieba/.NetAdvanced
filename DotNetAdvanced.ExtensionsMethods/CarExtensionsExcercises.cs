using DotNetAdvanced.ExtensionsMethods.Models;
using System;
using System.Collections.Generic;

namespace DotNetAdvanced.ExtensionsMethods
{
    public static class CarExtensionsExcercises
    {
        public static List<Car> AddTax(this List<Car> cars, int tax)
        {
            foreach (var car in cars)
            {
                car.Price = car.Price * (1 + tax) / 100;
            }

            return cars;
        }

        public static List<Car> AddDiscount(this List<Car> cars, int discount)
        {
            cars.ForEach(x => x.Price = x.Price - discount);
            return cars;
        }

        public static List<Car> ModifyCar(this List<Car> cars, Action<Car> modifier)
        {
            cars.ForEach(modifier);
            //foreach (var car in cars)
            //{
            //    modifier(car);
            //}

            return cars;
        }
    }
}
