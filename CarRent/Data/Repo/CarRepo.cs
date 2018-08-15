using CarRent.Models;

namespace CarRent.Data.Repo
{
    public class CarRepo : BaseRepo<Car>, ICarRepo
    {
        public CarRepo(ApplicationDbContext dbContext) : base(dbContext)
        {
            Table = dbContext.GetCars;
        }
    }
}
