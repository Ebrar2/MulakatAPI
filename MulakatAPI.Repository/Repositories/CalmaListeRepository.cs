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
    public class CalmaListeRepository : GenericRepository<CalmaListe>, ICalmaListeRepository
    {

        protected readonly AppDbContext _context;
        private readonly DbSet<CalmaListe> _dbSet;
        public CalmaListeRepository(AppDbContext context) : base(context)
        {
            _context = context;
            _dbSet = _context.Set<CalmaListe>();
        }

        
    }
}
