using MulakatAPI.Core.Models;
using MulakatAPI.Core.Repositories;
using MulakatAPI.Core.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MulakatAPI.Service.Services
{
    public class CalmaListeSarkiService : Service<CalmaListeSarki>, ICalmaListeSarkiService
    {
        public CalmaListeSarkiService(IGenericRepository<CalmaListeSarki> repository) : base(repository)
        {
        }
    }
}
