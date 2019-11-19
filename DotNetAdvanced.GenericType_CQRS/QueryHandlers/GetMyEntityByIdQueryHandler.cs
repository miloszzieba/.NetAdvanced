using DotNetAdvanced.GenericType_CQRS.Interfaces;
using DotNetAdvanced.GenericType_CQRS.Models;
using DotNetAdvanced.GenericType_CQRS.Queries;
using System;

namespace DotNetAdvanced.GenericType_CQRS.QueryHandlers
{
    public class GetMyEntityByIdQueryHandler : IGetQuery<GetMyEntityByIdQuery, MyEntity>
    {
        //private readonly DBContext _context;

        public GetMyEntityByIdQueryHandler(/*DBContext context*/)
        {
            //this._context = context;
        }

        public MyEntity Get(GetMyEntityByIdQuery command)
        {
            //In normal implementation, here would be something like this:
            //return this._context.MyEntities.FirstOrDefault(x => x.Id == command.Id);
            return new MyEntity();
        }
    }
}
