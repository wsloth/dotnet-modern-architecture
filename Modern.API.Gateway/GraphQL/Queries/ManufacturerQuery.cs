using System;
using System.Linq;
using GraphQL.Types;
using Microsoft.EntityFrameworkCore;
using Modern.API.Gateway.GraphQL.Types;
using Modern.API.Gateway.Data;

namespace Modern.API.Gateway.GraphQL.Queries
{
    public class ManufacturerQuery : ObjectGraphType
    {
        public ManufacturerQuery(ApplicationDbContext db)
        {
            Field<ManufacturerType>("Manufacturer",
                arguments: new QueryArguments(new QueryArgument<GuidGraphType> { Name = "Id", Description = "The ID of the Manufacturer" }),
                resolve: context =>
                {
                    var id = context.GetArgument<Guid>("Id");
                    var author = db
                      .Manufacturers
                      .Include(a => a.Cars)
                      .FirstOrDefault(i => i.Id == id);
                    return author;
                });

            Field<ListGraphType<ManufacturerType>>("Manufacturers",
              resolve: context =>
              {
                  var authors = db.Manufacturers.Include(a => a.Cars);
                  return authors;
              });
        }
    }
}
