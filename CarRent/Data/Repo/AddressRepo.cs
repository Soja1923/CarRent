using CarRent.Models;

namespace CarRent.Data.Repo
{
    public class AddressRepo : BaseRepo<Address>, IAddressRepo
    {
        public AddressRepo(ApplicationDbContext dbContext) : base(dbContext)
        {
            Table = dbContext.GetAddresses;
        }
    }
}
