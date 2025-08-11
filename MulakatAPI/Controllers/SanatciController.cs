using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using MulakatAPI.Core.DTOs;
using MulakatAPI.Core.Models;
using MulakatAPI.Core.Services;
using System.Threading.Tasks;

namespace MulakatAPI.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class SanatcController : ControllerBase
    {
        ISanatciService sanatciService;
        ISarkiService sarkiService;
        ICalmaListeService calmaListeService;
        ICalmaListeSarkiService calmaListeSarkiService;
        IAlbumService albumService;

        public SanatcController(ISanatciService sanatciService,ISarkiService sarkiService, ICalmaListeService calmaListeService,ICalmaListeSarkiService calmaListeSarkiService ,IAlbumService albumService)
        {
            this.sanatciService = sanatciService;
            this.sarkiService = sarkiService;
            this.calmaListeService = calmaListeService;
            this.calmaListeSarkiService = calmaListeSarkiService;
            this.albumService = albumService;
        }
        private static Random random = new Random();

        public static string RandomString(int length)
        {
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
            return new string(Enumerable.Repeat(chars, length)
                .Select(s => s[random.Next(s.Length)]).ToArray());
        }
        private Random gen = new Random();
        DateTime RandomDay()
        {
            DateTime start = new DateTime(1995, 1, 1);
            int range = (DateTime.Today - start).Days;
            return start.AddDays(gen.Next(range));
        }
        [HttpPost]
        public async Task<ActionResult> SanatciBazliIstatistikAl()
        {
 
           var sanatcilar=sanatciService.GetAllAsync().ToList();
           List<TableDto> returnValues=new List<TableDto>();  
           foreach(var sanatci in sanatcilar)
            {
                TableDto table = new TableDto();
                table.AlbumAdet = albumService.Where(x=>x.SanatciId==sanatci.Id).ToList().Count();
                table.SarkiAdet=sarkiService.Where(x=>x.SanatciId==sanatci.Id).ToList().Count();
                table.Name = sanatci.Ad;
                returnValues.Add(table);
            }
            return Ok(returnValues.OrderByDescending(x=>x.SarkiAdet));

        }


        [HttpPost]
        public async Task<IActionResult> CalmaListesiYenile(int calmaListesiId, int yeniSarkiAdet)
        {
            var calmaListesi = (await calmaListeSarkiService.GetAllAsync()).Where(x=>x.CalmaListeId==calmaListesiId);

            var sarkilar = await sarkiService.GetAllAsync();
            var eskiSarkilar = calmaListesi;
            int toplamSarkiSay = sarkilar.Count();
            int eskiCalmaListSarki = eskiSarkilar.Count();
            if (toplamSarkiSay-eskiCalmaListSarki<yeniSarkiAdet)
            {
                return Ok("Hatalı şarkı adeti");
            }
            var list = sarkilar.Where(x=>!eskiSarkilar.Any(e=>e.SarkiId==x.Id)).ToList();
            var yeniSarkilar=new List<CalmaListeSarki>();

            calmaListeSarkiService.RemoveRange(calmaListesi);
            
            Random random = new Random();
            for(int i=0; i<yeniSarkiAdet;i++)
            {
                int rand = random.Next(0, list.Count());
                while (yeniSarkilar.Where(x => x.SarkiId == list[rand].Id).Count() != 0)
                    rand = random.Next(0, toplamSarkiSay);

                CalmaListeSarki calmaListeSarki = new CalmaListeSarki();
                calmaListeSarki.SarkiId = list[rand].Id;
                calmaListeSarki.CalmaListeId = calmaListesiId;
                await calmaListeSarkiService.AddAsync(calmaListeSarki);   
             }

            return Ok();


        }
        [HttpPost]
        public async Task<IActionResult> AddCalmaListe(int sarkiAdet,string adi)
        {
            if(sarkiAdet==0 || adi.Length==0)
            {
                if (sarkiAdet == 0)
                    return Ok("Sarki Adeti 0 olamaz");
                return Ok("Calma Listesi Adi Bos Olamaz");
            }

            CalmaListe calmaListe = new CalmaListe();
            calmaListe.Ad = adi;
            IEnumerable<Sarki> sarkilar = await sarkiService.GetAllAsync();
            int toplamSarkiSay = sarkilar.Count();
            if(toplamSarkiSay<sarkiAdet)
            {
                return Ok("Yeterli Sarki Yok");
            }
            calmaListe.CalmaListeSarkis = new List<CalmaListeSarki>();
            Random random = new Random();
           
            var list = sarkilar.ToList();
            for (int i = 0;i<sarkiAdet;i++)
            {
                CalmaListeSarki calmaListeSarki = new CalmaListeSarki();
                int rand = random.Next(0, toplamSarkiSay);
                while (calmaListe.CalmaListeSarkis.Where(x => x.SarkiId == list[rand].Id).Count()!=0)
                    rand = random.Next(0, toplamSarkiSay);
                calmaListeSarki.SarkiId = list[rand].Id;
                calmaListe.CalmaListeSarkis.Add(calmaListeSarki);
                
            }
            var returnId= await calmaListeService.AddAsync(calmaListe);
            return Ok(returnId.Id);
        }

        [HttpPost]

        public async Task<IActionResult> Add(int albumSayi)
        {
           
            Sanatci sanatci = new Sanatci();
            sanatci.Ad = RandomString(5);
            sanatci.KurulusTarihi = RandomDay();

            sanatci.Albums = new List<Album>();
            Sanatci returnSanatci = await sanatciService.AddAsync(sanatci);
            for (int i = 0;i<albumSayi;i++)
            {
                Album album = new Album();
                Random random = new Random();
                album.Ad = RandomString(10);
                album.CikisTarihi=RandomDay();
                album.Sarkis=new List<Sarki>();
                int rand = random.Next(6, 15);
                for(int j=0;j<rand;j++)
                {
                    Sarki sarki = new Sarki();
                    sarki.SanatciId = returnSanatci.Id;
                    sarki.Ad = RandomString(15);
                    album.Sarkis.Add(sarki);

                }
                sanatci.Albums.Add(album);
            }
            sanatciService.Update(returnSanatci);
            return Ok(returnSanatci.Id);
        }
    }
}
