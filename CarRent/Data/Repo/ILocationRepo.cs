using CarRent.Models;

namespace CarRent.Data.Repo
{
    public interface ILocationRepo:IRepo<Location>
    {
        void Save(Location location);
    }
}
