using CarRent.Models;
using System.Linq;

namespace CarRent.Data.Repo
{
    public interface ICarDetalistRepo:IRepo<CarDetails>
    {
        IQueryable<Car> getCarByState_Sprawny(IQueryable<CarDetails> cars, int locationID);
        void Save(CarDetails carDetails);
    }
}
