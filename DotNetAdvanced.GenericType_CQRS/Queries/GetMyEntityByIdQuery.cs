using DotNetAdvanced.GenericType_CQRS.Interfaces;
using DotNetAdvanced.GenericType_CQRS.Models;

namespace DotNetAdvanced.GenericType_CQRS.Queries
{
    public class GetMyEntityByIdQuery : IQuery<MyEntity>
    {
        public long Id { get; private set; }

        public GetMyEntityByIdQuery(long id)
        {
            this.Id = id;
        }
    }
}
