using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MulakatAPI.Core.Models
{
    public class Album
    { 
        public int Id { get; set; }
        public string Ad { get; set; }
        public int SanatciId { get; set; }
        public DateTime CikisTarihi { get; set; }
        public Sanatci Sanatci { get; set; }
        public ICollection<Sarki> Sarkis {  get; set; }
    }
}
