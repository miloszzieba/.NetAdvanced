namespace DotNetAdvanced.GenericType_CQRS.Interfaces
{
    public interface IHandleCommand<TCommand> where TCommand : ICommand
    {
        void Handle(TCommand command);
    }
}
