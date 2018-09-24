using CarRent.Models;
using System;

namespace CarRent.Data.Repo
{
    public class OrderRepo : BaseRepo<Order>, IOrderRepo
    {
        public OrderRepo(ApplicationDbContext dbContext) : base(dbContext)
        {
            Table = dbContext.GetOrders;
        }

        public void EditState(Order order)
        {
                Order dbEntry = Table.Find(order.Order_ID);
                dbEntry.State = order.State;
                dbEntry.DateOfReturn = DateTime.Now;
                _dbContext.SaveChanges();
        }
    }
}

