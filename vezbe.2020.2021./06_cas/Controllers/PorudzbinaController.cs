using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Prodavnica2.Models;

namespace Prodavnica2.Controllers
{
    public class PorudzbinaController : Controller
    {
        private IPorudzbineRepozitorijum repozitorijum;
        private Korpa korpa;

        public PorudzbinaController(IPorudzbineRepozitorijum  repo, Korpa korpaIzServisa)
        {
            repozitorijum = repo;
            korpa = korpaIzServisa;
        }

        [HttpGet]
        public ViewResult Placanje()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Placanje(Porudzbina porudzbina)
        {
            if (korpa.listaProizvodaUKorpi.Count() == 0)
                ModelState.AddModelError("", "Vasa korpa je prazna");

            if (ModelState.IsValid)
            {
                porudzbina.listaProizvodaUKorpi = korpa.listaProizvodaUKorpi;
                repozitorijum.SacuvajPorudzbinu(porudzbina);
                return RedirectToAction("Zahvalnica");
            }
            else
                return View();
        }

        public ViewResult Zahvalnica()
        {
            korpa.ObrisiKorpu();

            return View();
        }

        public ViewResult SpisakNeposlatihPorudzbina()
        {
            return View(repozitorijum.Porudzbine.Where(p => p.Poslato == false));
        }

        [HttpPost]
        public IActionResult OznaciKaoPoslato(int porudzbinaID)
        {
            Porudzbina porudzbina = repozitorijum.Porudzbine
                    .FirstOrDefault(p => p.PorudzbinaID == porudzbinaID);

            if (porudzbina != null)
            {
                porudzbina.Poslato = true;
                repozitorijum.SacuvajPorudzbinu(porudzbina);
            }

            return RedirectToAction("SpisakNeposlatihPorudzbina");
        }
    }
}
