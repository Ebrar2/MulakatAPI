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
    public class SanatciService : Service<Sanatci>, ISanatciService
    {
        ISanatciRepository _repository;
        public SanatciService(IGenericRepository<Sanatci> repository, ISanatciRepository sanatciRepository) : base(repository)
        {

            _repository = sanatciRepository;
        }

        public IEnumerable<Sanatci> GetAllAsync(string[]? includes = null)
        {
           return  _repository.GetAllInclude(includes);
        }
    }
}
