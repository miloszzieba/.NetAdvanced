using DotNetAdvanced.Reflection.Models;
using System;
using System.Collections.Generic;
using System.Reflection;

namespace DotNetAdvanced.Reflection
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            var productType = typeof(Product);
            var propertyInfo = productType.GetProperties();
            var constructorInfo = productType.GetConstructors();
            var methodInfo = productType.GetMethods();

            #region Creating new objects
            var product = Activator.CreateInstance(productType);
            productType.GetProperty("Id").SetValue(product, 2);
            productType
                .GetField("name", BindingFlags.NonPublic | BindingFlags.Instance)
                .SetValue(product, "hakerska nazwa");
            #endregion


            #region Attributes
            var attributes = productType.GetCustomAttributes(false);
            foreach (var attribute in attributes)
            {
                if (attribute is MyAttribute)
                {
                    //...
                }
            }

            var assembly = Assembly.GetExecutingAssembly();
            var attributeClasses = new List<Type>();
            foreach (var type in assembly.GetTypes())
            {
                if (type.GetCustomAttributes(typeof(MyAttribute), true).Length > 0)
                    attributeClasses.Add(type);
            }
            #endregion
        }
    }
}
