using CarRent.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CarRent.Data.Repo
{
    public class CustomerRepo: BaseRepo<Customer>, ICustomerRepo
    {
        public IQueryable<Customer> Customers { get; set; }

        public CustomerRepo(ApplicationDbContext dbContext) : base(dbContext)
        {
            Table = dbContext.GetCustomers;
        }
    }
}
