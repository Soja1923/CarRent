using CarRent.Models;

namespace CarRent.Data.Repo
{
    public class UserRatingRepo : BaseRepo<UserRating>, IUserRatingRepo
    {
        public UserRatingRepo(ApplicationDbContext dbContext) : base(dbContext)
        {
            Table = dbContext.GetUserRatings;
        }
    }
}
