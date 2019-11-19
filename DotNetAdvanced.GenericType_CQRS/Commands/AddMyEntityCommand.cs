using DotNetAdvanced.GenericType_CQRS.Interfaces;
using DotNetAdvanced.GenericType_CQRS.Models;

namespace DotNetAdvanced.GenericType_CQRS.Commands
{
    public class AddMyEntityCommand : ICommand
    {
        public MyEntity MyEntity { get; private set; }

        public AddMyEntityCommand(MyEntity myEntity)
        {
            this.MyEntity = myEntity;
        }
    }
}
