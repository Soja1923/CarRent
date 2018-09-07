using CarRent.Models;
using System.Linq;

namespace CarRent.Data.Repo
{
    public interface ICarRepo:IRepo<Car>
    {
        IQueryable<Car> getCarByGrade(IQueryable<Car> cars, string category);
        void Save(Car car);
    }
}
