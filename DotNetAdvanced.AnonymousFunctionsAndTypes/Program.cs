using DotNetAdvanced.AnonymousFunctionsAndTypes.Helpers;
using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Linq.Expressions;

namespace DotNetAdvanced.AnonymousFunctionsAndTypes
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            #region AnonymousFunctions
            Action<int> action = (int x) =>
            {
                Console.WriteLine(x);
            };

            Func<int, int> func = (int x) =>
            {
                return x + 2;
            };

            Predicate<int> predicate = (int x) =>
            {
                return x > 5;
            };
            #endregion

            //Only in scope of the body of Main method
            #region Local Functions
            int localFuntion(int x, int y)
            {
                return x * y + 4;
            }

            var a = localFuntion(4, 5);
            var b = localFuntion(5, 6);
            var c = localFuntion(6, 7);
            #endregion

            #region AnonymousTypes
            var books = new List<Book>() {
                new Book() { Name = "TEST", Price = 10 }
            };

            var bookPrices = books.Select((book) => new
            {
                Price = book.Price * 1.23
            })
            .Select((x) =>
            new
            {
                Price = x.Price > 10 ? x.Price - 5 : x.Price
            });
            #endregion

            #region Expression
            Expression<Func<int, bool>> expression = (x) => x > 2;
            Expression<Func<int, bool>> expression2 = (x) => x < 7;

            //Summing expressions
            //It needs a lot more code to work
            //CombineAdd is extension method that hides it in Helpers folder.
            var finalExpression = expression.CombineAnd(expression2);
            var expressionPredicate = finalExpression.Compile();
            var numberList = new List<int>() { 1, 4, 5, 7, 8 };
            var expressionResult = numberList.Where(expressionPredicate);
            #endregion

            #region dynamic
            dynamic dyn = new { Price = 1 };
            //Exception:
            //a.ProductionYear = 2000;
            dyn = 1;
            dyn = "string";
            #endregion

            #region ExpandoObject
            dynamic sampleObject = new ExpandoObject();
            sampleObject.number = 10;

            sampleObject.Increment = (Action)(() => { sampleObject.number++; });
            sampleObject.Increment();
            #endregion
        }
    }
}
