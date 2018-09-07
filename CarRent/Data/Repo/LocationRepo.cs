using CarRent.Models;

namespace CarRent.Data.Repo
{
    public class LocationRepo : BaseRepo<Location>, ILocationRepo
    {
        public LocationRepo(ApplicationDbContext dbContext) : base(dbContext)
        {
            Table = dbContext.GetLocations;
        }

        public void Save(Location location)
        {
            if(location.Location_ID == 0)
            {
                Table.Add(location);
            }
            else
            {
                Location dbEntry = Table.Find(location.Location_ID);
                if(dbEntry != null)
                {
                    Address address = location.Address;
                    dbEntry.Address = address;
                    dbEntry.E_mail = location.E_mail;
                    dbEntry.Phone_Number = location.Phone_Number;
                }
            }
            _dbContext.SaveChanges();
        }
    }
}
