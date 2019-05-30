using GraphQL.Types;
using Modern.Models;

namespace Modern.API.Gateway.GraphQL.Types
{
    public class ManufacturerType : ObjectGraphType<Manufacturer>
    {
        public ManufacturerType()
        {
            Name = "Manufacturer";

            Field(x => x.Id, type: typeof(GuidGraphType)).Description("The Id of the manufacturer");
            Field(x => x.Name).Description("The name of the manufacturer");
            Field(x => x.Cars, type: typeof(ListGraphType<CarType>)).Description("The cars this manufacturer has produced");
        }
    }
}
