using CarRent.Models;
using System.Linq;

namespace CarRent.Data.Repo
{
    public class GradeRepo : BaseRepo<Grade>, IGradeRepo
    {
        public GradeRepo(ApplicationDbContext dbContext) : base(dbContext)
        {
            Table = dbContext.GetGrades;
        }

        public IQueryable<Grade> SeletedGrade(IQueryable<Grade> grades)
        {
            return null;
        }

        public void Save(Grade grade)
        {

            if (grade.Grade_ID == 0)
            {
                Table.Add(grade);
            }
            else
            {
                Grade dbEntry = Table.Find(grade.Grade_ID);
                if (dbEntry != null)
                {
                    dbEntry.GradeType = grade.GradeType;
                    dbEntry.PricePerDay = grade.PricePerDay;
                }
            }
            _dbContext.SaveChanges();
        }
    }
}
