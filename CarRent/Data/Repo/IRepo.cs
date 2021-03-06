﻿using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CarRent.Data.Repo
{
    public interface IRepo<T> where T: class
    {
        IQueryable<T> GetAll();
        Task<T> GetById(int id);
        Task Delete(int id);
        Task AddRange(IList<T> entities);
    }
}
