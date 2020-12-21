using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ProjeCore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjeCore.Controllers
{
    public class PersonelimController : Controller
    {
        Context c = new Context();
        [Authorize]
        public IActionResult Index()
        {
            var degerler = c.personels.Include(x => x.Birim).ToList();
            return View(degerler);
        }
        [HttpGet]   //sayfa yüklendiğinde Çalışsın
        public IActionResult YeniPersonel()
        {
            List<SelectListItem> degerler = (from x in c.birims.ToList()
                                             select new SelectListItem
                                             {
                                                 Text = x.BirimAd,
                                                 Value = x.BirimID.ToString()
                                             }).ToList();
            ViewBag.dgr = degerler;
            return View();
        }
        //[HttpPost]   //butona basıldığında çalışsın
        public IActionResult YeniPersonel(Personel p)
        {
            
            var per = c.birims.Where(x => x.BirimID == p.Birim.BirimID).FirstOrDefault();
            p.Birim = per;
            c.personels.Add(p);
            c.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
