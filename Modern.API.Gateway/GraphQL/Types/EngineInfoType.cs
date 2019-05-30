using GraphQL.Types;
using Modern.Models;

namespace Modern.API.Gateway.GraphQL.Types
{
    public class EngineInfoType : ObjectGraphType<EngineInfo>
    {
        public EngineInfoType()
        {
            Name = "EngineInfo";

            Field(x => x.Id, type: typeof(GuidGraphType)).Description("The Id of the engine");
            Field(x => x.ZeroTo100Time).Description("The time it takes for this car to reach 100km/h");
            Field(x => x.Horsepower).Description("The amount of horsepower this engine produces");
            Field(x => x.Cylinders).Description("The amount of cylinders this engine has");
        }
    }
}
