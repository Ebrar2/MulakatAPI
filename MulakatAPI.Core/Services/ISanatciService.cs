using MulakatAPI.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MulakatAPI.Core.Services
{
    public interface ISanatciService:IService<Sanatci>
    {
        IEnumerable<Sanatci> GetAllAsync(string[]? includes = null);

    }
}
