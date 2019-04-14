using System.Linq;
using System.Threading.Tasks;
using DataBaseDemo.Graph;
using DataBaseDemo.Graph.Validators;
using GraphQL;
using GraphQL.FluentValidation;
using Microsoft.AspNetCore.Mvc;

namespace DataBaseDemo.API.Controllers
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
            var validatorTypeCache = new ValidatorTypeCache();
            validatorTypeCache.
                AddValidatorsFromAssemblyContaining(typeof(ItemValidator));

            var options = new ExecutionOptions
            {
                Schema = schema,
                Query = query.Query,
                Inputs = query.Variables.ToInputs()
            };
            options.UseFluentValidation(validatorTypeCache);

            var result = await new DocumentExecuter().ExecuteAsync(options);
            if (result.Errors?.Count > 0)
            {
                return BadRequest(result.Errors);
            }
            return Ok(result);
        }
    }
}
