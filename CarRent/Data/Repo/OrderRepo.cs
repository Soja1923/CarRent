using CarRent.Models;

namespace CarRent.Data.Repo
{
    public class OrderRepo : BaseRepo<Order>, IOrderRepo
    {
        public OrderRepo(ApplicationDbContext dbContext) : base(dbContext)
        {
            Table = dbContext.GetOrders;
        }
    }
}
