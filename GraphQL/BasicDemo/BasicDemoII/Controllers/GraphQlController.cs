using System.Linq;
using System.Threading.Tasks;
using BasicDemoII.Model;
using BasicDemoII.Query;
using GraphQL;
using GraphQL.Types;
using Microsoft.AspNetCore.Mvc;

namespace BasicDemoII.Controllers
{
    [Route(Startup.GraphQlPath)]
    public class GraphQlController : Controller
    {
        private readonly InventorySchema schema;

        public GraphQlController(InventorySchema schema)
        {
            this.schema = schema;
        }
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] GraphQlQuery query)
        {
            var result = await new DocumentExecuter().ExecuteAsync(x =>
            {
                x.Schema = schema;
                x.Query = query.Query;
                x.Inputs = query.Variables.ToInputs();
            });
            if (result.Errors?.Count > 0)
            {
                return BadRequest(result.Errors);
            }
            return Ok(result);
        }
    }
}
