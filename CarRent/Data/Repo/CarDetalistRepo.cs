using CarRent.Models;

namespace CarRent.Data.Repo
{
    public class CarDetalistRepo : BaseRepo<CarDetails>, ICarDetalistRepo
    {
        public CarDetalistRepo(ApplicationDbContext dbContext) : base(dbContext)
        {
            Table = dbContext.GetCarDetails;
        }
    }
}
