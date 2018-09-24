using CarRent.Models;

namespace CarRent.Data.Repo
{
    public interface IOrderRepo: IRepo<Order>
    {
        void EditState(Order order);
    }
}
