using CarRent.Models;
using System.Collections.Generic;
using System.Linq;

namespace CarRent.Data.Repo
{
    public class EmployeRepo: BaseRepo<Employee>, IEmployeRepo
    {
        public IQueryable<Employee> Employees { get; set; }

        public EmployeRepo(ApplicationDbContext dbContext) : base(dbContext)
        {
            Table = dbContext.GetEmployees;
        }

    }
}
