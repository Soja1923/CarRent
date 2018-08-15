using CarRent.Models;

namespace CarRent.Data.Repo
{
    public class GradeRepo : BaseRepo<Grade>, IGradeRepo
    {
        public GradeRepo(ApplicationDbContext dbContext) : base(dbContext)
        {
            Table = dbContext.GetGrades;
        }
    }
}
