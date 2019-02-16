using GraphQL.Client;
using GraphQL.Common.Request;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace GraphQLGraphTypeFirstSingleTableArgument.Controllers
{
    [Route("Employee")]
    public class EmployeeController : Controller
    {
        [HttpGet("{id}")]
        public async Task<Employee> Get(int id)
        {
            using (GraphQLClient graphQLClient = new GraphQLClient("http://localhost:64925/graphql"))
            {
                var query = new GraphQLRequest
                {
                    Query = @" 
                        query employeeQuery($employeeId: ID!)
                        { employee(id: $employeeId) 
                            { id name email 
                            }
                        }",
                    Variables = new { employeeId = id }
                };
                var response = await graphQLClient.PostAsync(query);
                return response.GetDataFieldAs<Employee>("employee");
            }
        }
    }
}
