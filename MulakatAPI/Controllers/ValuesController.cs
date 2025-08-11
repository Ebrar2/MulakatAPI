using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MulakatAPI.Core.DTOs;
using MulakatAPI.Core.Models;
using MulakatAPI.Core.Services;

namespace MulakatAPI.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        ICalmaListeService calmaListeService;

        public ValuesController(ICalmaListeService calmaListeService)
        {
            this.calmaListeService = calmaListeService;
        }
        [HttpPost]
        public IActionResult Topla(int a,int b)
        {
            return Ok(a+b);
        }

        [HttpPost]
        public async Task<IActionResult> Add(CalmaListeDto calmaListe)
        {
            CalmaListe calmaListe1 = new CalmaListe();
            calmaListe1.Ad=calmaListe.Ad;
            return Ok(await calmaListeService.AddAsync(calmaListe1));
        }
        [HttpPost]
        public async Task<IActionResult> Delete(int id)
        {
            return Ok(await calmaListeService.RemoveById(id));
        }
        [HttpPost]
        public IActionResult  Update(CalmaListeUpdateDto calmaListe)
        {
            CalmaListe calmaListe1 = new CalmaListe();
            calmaListe1.Ad = calmaListe.Ad;
            calmaListe1.Id = calmaListe.Id;

            return Ok(calmaListeService.Update(calmaListe1));
        }
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await calmaListeService.GetAllAsync());
        }
    }
}
