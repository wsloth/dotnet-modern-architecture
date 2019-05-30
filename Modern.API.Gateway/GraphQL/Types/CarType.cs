using System;
using GraphQL.Types;
using Modern.Models;

namespace Modern.API.Gateway.Api
{
    public class CarType : ObjectGraphType<Car>
    {
        public CarType()
        {
            Name = "Car";

            Field(x => x.Id, type: typeof(IdGraphType)).Description("The Id of the car");
            Field(x => x.Name).Description("The name of the car");
            Field(x => x.Created).Description("The date this car was created");
            Field(x => x.Engine, type: typeof(ObjectGraphType<EngineInfoType>)).Description("The engine this car has");
            Field(x => x.Manufacturer, type: typeof(ObjectGraphType<Manufacturer>)).Description("The manufacturer of this car");
        }
    }
}
