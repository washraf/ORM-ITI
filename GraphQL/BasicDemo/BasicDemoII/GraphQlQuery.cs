using GraphQL;
using Newtonsoft.Json.Linq;

namespace BasicDemoII
{
    public class GraphQlQuery
    {
        public string OperationName { get; set; }
        public string NamedQuery { get; set; }
        public string Query { get; set; }
        //public Inputs Variables { get; set; }
        public JObject Variables { get; set; }
    }
}
