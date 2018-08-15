using CarRent.Models;

namespace CarRent.Data.Repo
{
    public class LocationRepo : BaseRepo<Location>, ILocationRepo
    {
        public LocationRepo(ApplicationDbContext dbContext) : base(dbContext)
        {
            Table = dbContext.GetLocations;
        }
    }
}
