using DotNetAdvanced.GenericType_CQRS.Models;

namespace DotNetAdvanced.GenericType_CQRS.Interfaces
{
    public interface IQuery<TResult> where TResult : BaseEntity
    {
    }
}
