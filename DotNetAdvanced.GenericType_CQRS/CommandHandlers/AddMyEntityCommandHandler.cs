using DotNetAdvanced.GenericType_CQRS.Commands;
using DotNetAdvanced.GenericType_CQRS.Interfaces;

namespace DotNetAdvanced.GenericType_CQRS.CommandHandlers
{
    public class AddMyEntityCommandHandler : IHandleCommand<AddMyEntityCommand>
    {
        //private readonly DBContext _context;

        public AddMyEntityCommandHandler(/*DBContext context*/)
        {
            //this._context = context;
        }

        public void Handle(AddMyEntityCommand command)
        {
            //In normal implementation, here would be something like this:
            //this._context.MyEntities.Add(command.MyEntity);
            //this._context.SaveChanges();
        }
    }
}
