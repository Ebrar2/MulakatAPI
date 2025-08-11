using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MulakatAPI.Core.Models
{
    public class CalmaListeSarki
    {
        public int Id { get; set; }
        public int CalmaListeId { get; set; } //calmaListeId ve sarkid yi composite key yaparak id alanını kaldırma?
        public int SarkiId {  get; set; }
        public CalmaListe CalmaListe { get; set; }
        public Sarki Sarki { get; set; }
    }
}
