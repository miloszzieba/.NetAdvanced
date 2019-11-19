using Autofac;
using DotNetAdvanced.GenericType_CQRS.Interfaces;
using DotNetAdvanced.GenericType_CQRS.Models;
using System;

namespace DotNetAdvanced.GenericType_CQRS
{
    public class AutofacDispatcher : IDispatcher
    {
        private readonly IComponentContext _componentContext;

        public AutofacDispatcher(IComponentContext componentContext)
        {
            this._componentContext = componentContext;
        }

        public TResult Get<TQuery, TResult>(TQuery query)
            where TQuery : IQuery<TResult>
            where TResult : BaseEntity
        {
            //Using Resolve in code is generally considered bad practice
            //We want to pass dependencies by constructor
            //Rare example when Resolve is needed
            var queryHandler = this._componentContext.Resolve<IGetQuery<TQuery, TResult>>();
            if (queryHandler == null)
                throw new NotImplementedException(typeof(IGetQuery<TQuery, TResult>).ToString());

            return queryHandler.Get(query);
        }

        public void Handle<TCommand>(TCommand command) where TCommand : ICommand
        {
            var commandHandler = this._componentContext.Resolve<IHandleCommand<TCommand>>();
            if (commandHandler == null)
                throw new NotImplementedException(typeof(IHandleCommand<TCommand>).ToString());

            commandHandler.Handle(command);
        }
    }
}
