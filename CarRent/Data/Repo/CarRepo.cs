using CarRent.Models;
using System.Linq;

namespace CarRent.Data.Repo
{
    public class CarRepo : BaseRepo<Car>, ICarRepo
    {
        public CarRepo(ApplicationDbContext dbContext) : base(dbContext)
        {
            Table = dbContext.GetCars;
        }

        //pobiera auta przypisane do kategorii cenowej
        public IQueryable<Car> getCarByGrade(IQueryable<Car> cars, string category)
        {
            return cars.Where(x => category == null || x.Grade.GradeType.ToString() == category).OrderBy(x=>x.Car_ID);
        }

        public void Save(Car car)
        {
            if (car.Car_ID == 0)
            {
                Table.Add(car);
            }
            else
            {
                Car dbEntry = Table.Find(car.Car_ID);
                if (dbEntry != null)
                {
                    dbEntry.Body = car.Body;
                    dbEntry.Description = car.Description;
                    dbEntry.EngineCapacity = car.EngineCapacity;
                    dbEntry.Fuel = car.Fuel;
                    dbEntry.GearboxType = car.GearboxType;
                    dbEntry.GradeID = car.GradeID;
                    dbEntry.Mark = car.Mark;
                    dbEntry.Model = car.Model;
                    dbEntry.NumberOfSeats = car.NumberOfSeats;
                    dbEntry.Year = car.Year;
                    dbEntry.Img = car.Img;
                }
            }
            _dbContext.SaveChanges();
        }
    }
}
