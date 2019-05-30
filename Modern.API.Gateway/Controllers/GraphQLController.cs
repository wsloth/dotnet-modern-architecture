using System.Threading.Tasks;
using GraphQL;
using GraphQL.Types;
using Microsoft.AspNetCore.Mvc;
using Modern.API.Gateway.Data;
using Modern.API.Gateway.GraphQL.Queries;
using Newtonsoft.Json.Linq;

namespace Modern.API.Gateway.Controllers
{
    public class GraphQLQuery
    {
        public string OperationName { get; set; }
        public string NamedQuery { get; set; }
        public string Query { get; set; }
        public JObject Variables { get; set; }
    }

    [ApiController]
    [Route("/api/graphql")]
    public class GraphQLController : Controller
    {
        private ApplicationDbContext Db { get; }

        public GraphQLController(ApplicationDbContext db) => Db = db;

        /// <summary>
        /// Query:
        /// manufacturers {
        ///    id
        ///    name
        ///    cars {
        ///      name
        ///      created
        ///      manufacturerId
        ///    }
        ///}
        /// </summary>
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] GraphQLQuery query)
        {
            var inputs = query.Variables.ToInputs();

            var schema = new Schema
            {
                Query = new ManufacturerQuery(Db)
            };

            var result = await new DocumentExecuter().ExecuteAsync(_ =>
            {
                _.Schema = schema;
                _.Query = query.Query;
                _.OperationName = query.OperationName;
                _.Inputs = inputs;
            });

            if (result.Errors?.Count > 0)
            {
                return BadRequest(result.Errors);
            }

            return Ok(result);
        }
    }
}
