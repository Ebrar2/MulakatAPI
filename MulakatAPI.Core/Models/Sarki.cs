using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MulakatAPI.Core.Models
{
    public class Sarki
    {
        public int Id { get; set; }
        public string Ad { get; set; }
        public int AlbumId { get; set; }
        public int SanatciId {  get; set; }    //Album kısmına taşıma?
        public Album Album { get; set; }
     //   public Sanatci Sanatci { get; set; }     //Album kısmına taşıma?
        public ICollection<CalmaListeSarki> CalmaListeSarkis { get; set; } 
    }
}
