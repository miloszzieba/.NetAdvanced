using DotNetAdvanced.GenericType_Repository.Models;
using System.Collections.Generic;
using System.Linq;

namespace DotNetAdvanced.GenericType_Repository
{
    public class BaseRepository<T> where T : BaseEntity, new()
    {
        protected readonly List<T> _inMemoryDatabaseCollection = new List<T>();

        public void Add(T entity)
        {
            this._inMemoryDatabaseCollection.Add(entity);
        }

        public T GetById(long id)
        {
            return this._inMemoryDatabaseCollection.FirstOrDefault(x => x.Id == id);
        }

        public void DeleteById(long id)
        {
            var entity = GetById(id);
            if (entity != default(T))
            {
                this._inMemoryDatabaseCollection.Remove(entity);
            }

            this._inMemoryDatabaseCollection.RemoveAll(x => x.Id == id);
        }

        public T GetT()
        {
            return new T()
            {
                Id = _inMemoryDatabaseCollection.Count + 1
            };
        }
    }
}
