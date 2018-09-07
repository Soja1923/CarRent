using CarRent.Models;

namespace CarRent.Data.Repo
{
    public interface IGradeRepo:IRepo<Grade>
    {
        void Save(Grade grade);
    }
}
