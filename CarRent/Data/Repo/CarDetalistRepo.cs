using CarRent.Models;
using System.Linq;

namespace CarRent.Data.Repo
{
    public class CarDetalistRepo : BaseRepo<CarDetails>, ICarDetalistRepo
    {
        public CarDetalistRepo(ApplicationDbContext dbContext) : base(dbContext)
        {
            Table = dbContext.GetCarDetails;
        }

        //Wybieranie samochodów o statusie "Sprawny" z wybranej lokalizaji 
        public IQueryable<Car> getCarByState_Sprawny(IQueryable<CarDetails> cars, int locationID)
        {
            return cars.Where(x=> x.LocationID == locationID && x.State.ToString() == "Sprawny").Select(x=>x.Car);
        }

        public void Save(CarDetails carDetails)
        {
            if (carDetails.CarDetailsID == 0)
            {
                Table.Add(carDetails);
            }
            else
            {
                CarDetails dbEntry = Table.Find(carDetails.CarDetailsID);
                if (dbEntry != null)
                {
                    dbEntry.CarID = carDetails.CarID;
                    dbEntry.LocationID = carDetails.LocationID;
                    dbEntry.RegistrationNumber = carDetails.RegistrationNumber;
                    dbEntry.State = carDetails.State;
                    dbEntry.Comments = carDetails.Comments;
                }
            }
            _dbContext.SaveChanges();
        }
    }
}
