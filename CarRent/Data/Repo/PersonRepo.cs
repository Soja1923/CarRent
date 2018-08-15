using CarRent.Models;

namespace CarRent.Data.Repo
{
    public class PersonRepo : BaseRepo<Person>, IPersonRepo
    {
        public PersonRepo(ApplicationDbContext dbContext) : base(dbContext)
        {
            Table = dbContext.GetPeople;
        }
    }
}
