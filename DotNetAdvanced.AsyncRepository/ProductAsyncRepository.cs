using DotNetAdvanced.AsyncRepository.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace DotNetAdvanced.AsyncRepository
{
    public class ProductAsyncRepository
    {
        private readonly string _path;
        private readonly SemaphoreSlim _semaphore = new SemaphoreSlim(1);

        public ProductAsyncRepository(string path)
        {
            this._path = path;
            if (!File.Exists(path))
                File.WriteAllText(path, "");
        }

        public async Task Add(Product product)
        {
            await _semaphore.WaitAsync();
            try
            {
                var products = await File.ReadAllLinesAsync(this._path);
                if (products.Contains(product.Name))
                    return;
                await File.AppendAllLinesAsync(this._path, new List<string>() { product.Name });
            }
            finally
            {
                _semaphore.Release();
            }

        }

        public async Task<Product> GetByNameAsync(string name)
        {
            try
            {
                var products = await File.ReadAllLinesAsync(this._path);
                if (products.Contains(name))
                    return new Product()
                    {
                        Name = name
                    };
                return null;
            }
            finally
            {
            }
        }
    }

}
