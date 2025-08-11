using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MulakatAPI.Core.Models
{
    public class CalmaListe
    {
        public int Id {  get; set; }
        public string Ad { get; set; }

        public ICollection<CalmaListeSarki> CalmaListeSarkis { get; set; }
    }
}
