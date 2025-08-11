using MulakatAPI.Core.Models;
using MulakatAPI.Core.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MulakatAPI.Repository.Repositories
{
    public class SarkiRepository : GenericRepository<Sarki>,ISarkiRepository
    {
        public SarkiRepository(AppDbContext context) : base(context)
        {
        }
    }
}
