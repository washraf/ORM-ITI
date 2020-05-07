using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GraphQL;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace SimpleDemo2.Controllers
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
