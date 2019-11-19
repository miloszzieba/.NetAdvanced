using DotNetAdvanced.CoAndContrVariance.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DotNetAdvanced.CoAndContrVariance
{
    class Program
    {
        static void Main(string[] args)
        {
            ICovariant<BaseEntity> baseEntityCovariant = new Covariant<Product>();
            ICovariant<Product> myEntityConariant = new Covariant<Product>();

            ICovariant<BaseEntity> baseEntityCovariant2 = new Covariant<BaseEntity>();
            //Error:
            //ICovariant<Product> myEntityCovariant2 = new Covariant<BaseEntity>();

            //Error:
            //IContrvariant<BaseEntity> baseEntityContrvariant = new Contrvariant<MyEntity>();
            IContrvariant<Product> myEntityContrvariant = new Contrvariant<Product>();

            IContrvariant<BaseEntity> baseEntityContrvariant2 = new Contrvariant<BaseEntity>();
            IContrvariant<Product> myEntityContrvariant2 = new Contrvariant<BaseEntity>();

            IContrvariant<Product> myEntityContrvariant3 = new Contrvariant<BaseEntity>();

        }
    }
}
