using DotNetAdvanced.GenericType_CQRS.Models;

namespace DotNetAdvanced.GenericType_CQRS.Interfaces
{
    public interface IDispatcher
    {
        void Handle<TCommand>(TCommand command) where TCommand : ICommand;
        TResult Get<TQuery, TResult>(TQuery query) where TQuery : IQuery<TResult> where TResult : BaseEntity;
    }
}
