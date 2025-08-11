using MulakatAPI.Core.Models;
using MulakatAPI.Core.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MulakatAPI.Repository.Repositories
{
    public class CalmaListeSarkiRepository : GenericRepository<CalmaListeSarki>, ICalmaListeSarkiRepository
    {
        public CalmaListeSarkiRepository(AppDbContext context) : base(context)
        {
        }
    }
}
