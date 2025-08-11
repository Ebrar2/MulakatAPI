using Microsoft.EntityFrameworkCore;
using MulakatAPI.Core.Models;
using MulakatAPI.Core.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MulakatAPI.Repository.Repositories
{
    public class SanatciRepository : GenericRepository<Sanatci>, ISanatciRepository
    {
        AppDbContext _appDbContext;
        public SanatciRepository(AppDbContext context) : base(context)
        {
            _appDbContext = context;
        }

        public IQueryable<Sanatci> GetAllInclude(string[]? includes = null)
        {
            IQueryable<Sanatci> query = _appDbContext.Set<Sanatci>();

            if (includes != null)
                foreach (var include in includes)
                    query = query.Include(include);

            return  query;
         }
    }
}
