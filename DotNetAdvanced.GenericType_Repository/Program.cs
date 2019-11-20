using DotNetAdvanced.GenericType_Repository.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DotNetAdvanced.GenericType_Repository
{
    class Program
    {
        static void Main(string[] args)
        {
            var baseRepository = new BaseRepository<Product>();
            baseRepository.Add(new Product());
        }
    }
}
