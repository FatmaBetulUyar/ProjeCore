using Microsoft.AspNetCore.Mvc;
using ProjeCore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjeCore.Controllers
{
    public class DefaultController : Controller
    {
        Context c = new Context();
        public IActionResult Index()
        {
            var degerler = c.birims.ToList();
            return View(degerler);
        }
        [HttpGet]
        public IActionResult YeniBirim()
        {
            return View();
        }
        [HttpPost]
        public IActionResult YeniBirim(Birim b)
        {
            c.birims.Add(b);
            c.SaveChanges();
            return RedirectToAction("Index");

        }
        public IActionResult BirimSil(int id)
        {
            var dep = c.birims.Find(id);
            c.birims.Remove(dep);
            c.SaveChanges();
            return RedirectToAction("Index");
        }
        public IActionResult BirimGetir(int id)
        {
            var depart = c.birims.Find(id);
            return View("BirimGetir", depart);
        }

        public IActionResult BirimGuncelle(Birim b)
        {
            var depart = c.birims.Find(b.BirimID);
            depart.BirimAd = b.BirimAd;
            c.SaveChanges();
            return RedirectToAction("Index");
        }

        public IActionResult BirimDetay(int id)
        {
            var degerler = c.personels.Where(x => x.BirimID == id).ToList();
            var brmad = c.birims.Where(x => x.BirimID == id).Select(y => y.BirimAd).FirstOrDefault();
            ViewBag.brm = brmad;
            return View(degerler);
        }
    }
}

