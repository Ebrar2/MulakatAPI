using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MulakatAPI.Core.Models
{
    public class Sanatci
    {
        public int Id { get; set; }
        public string Ad { get; set; }
        public DateTime KurulusTarihi { get; set; }
   //     public ICollection<Sarki> Sarkis { get; set; } //Sanatci-Sarki ilişkisini silip album üzerinden ulaşmak
        public ICollection<Album> Albums { get; set; }


    }
}
