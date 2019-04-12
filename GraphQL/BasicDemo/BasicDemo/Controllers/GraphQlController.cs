using System.Linq;
using System.Threading.Tasks;
using BasicDemo;
using GraphQL;
using GraphQL.Types;
using Microsoft.AspNetCore.Mvc;

namespace BasicDemo.Controllers
{
    [Route(Startup.GraphQlPath)]
    public class GraphQlController : Controller
    {
        public GraphQlController()
        {
        }
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] GraphQlQuery query)
        {
            var schema = new Schema { Query = new HelloWorldQuery() };
            var result = await new DocumentExecuter().ExecuteAsync(x =>
            {
                x.Schema = schema;
                x.Query = query.Query;
                x.Inputs = query.Variables;
            });
            if (result.Errors?.Count > 0)
            {
                return BadRequest();
            }
            return Ok(result);
        }
    }
}
