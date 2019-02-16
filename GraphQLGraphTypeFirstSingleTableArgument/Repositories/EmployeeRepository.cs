using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GraphQLGraphTypeFirstSingleTableArgument
{
    public class EmployeeRepository : IEmployeeRepository
    {
        private readonly GraphQLDemoContext _context;
        public EmployeeRepository(GraphQLDemoContext context)
        {
            _context = context;
        }

        public Task<List<Employee>> GetEmployees()
        {
            return _context.Employee.ToListAsync();
        }

        public Task<Employee> GetEmployeeById(long id)
        {
            return _context.Employee.SingleAsync(a => a.Id == id);
        }

    }

}
