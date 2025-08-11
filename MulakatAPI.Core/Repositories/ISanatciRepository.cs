using MulakatAPI.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MulakatAPI.Core.Repositories
{
    public interface ISanatciRepository:IGenericRepository<Sanatci>
    {
        IQueryable<Sanatci> GetAllInclude(string[]? includes = null);
    }
}
