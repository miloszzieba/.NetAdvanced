using DotNetAdvanced.GenericType_CQRS.Models;

namespace DotNetAdvanced.GenericType_CQRS.Interfaces
{
    public interface IGetQuery<TQuery, TResult> where TQuery : IQuery<TResult> 
                                                where TResult : BaseEntity
    {
        TResult Get(TQuery command);
    }
}
