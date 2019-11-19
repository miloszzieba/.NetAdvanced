using DotNetAdvanced.GenericType_Repository.Models;
using System.Linq;

namespace DotNetAdvanced.GenericType_Repository
{
    public class ProductRepository : BaseRepository<Product>
    {
        public ProductRepository()
            : base()
        {

        }


        public Product GetByName(string name)
        {
            return this._inMemoryDatabaseCollection.FirstOrDefault(x => x.Name == name);
        }
    }
}
