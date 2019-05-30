using GraphQL.Types;
using Modern.Models;

namespace Modern.API.Gateway.Api
{
    public class ManufacturerType : ObjectGraphType<Manufacturer>
    {
        public ManufacturerType()
        {
            Name = "Manufacturer";

            Field(x => x.Id, type: typeof(IdGraphType)).Description("The Id of the manufacturer");
            Field(x => x.Name).Description("The name of the manufacturer");
        }
    }
}
