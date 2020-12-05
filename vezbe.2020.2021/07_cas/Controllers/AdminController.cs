using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Prodavnica2.Models;

namespace Prodavnica2.Controllers
{
    [Authorize]
    public class AdminController : Controller
    {
        private IProizvodRepozitorijum repozitorijum;
        private IWebHostEnvironment hostEnvironment;
        private UserManager<MojKorisnik> userManager;

        public AdminController(IProizvodRepozitorijum repo,
            IWebHostEnvironment host,
            UserManager<MojKorisnik> usrManager)
        {
            repozitorijum = repo;
            hostEnvironment = host;
            userManager = usrManager;
        }

        public ViewResult SpisakProizvoda() =>
            View(repozitorijum.Proizvodi);

        [HttpPost]
        public RedirectToActionResult Obrisi(int proizvodId)
        {
            Proizvod proizvod = repozitorijum.BrisiProizvod(proizvodId);

            if (proizvod != null)
            {
                TempData["poruka"] = $"{proizvod.Ime} je obrisan.";
            }

            return RedirectToAction("SpisakProizvoda");
        }

        [HttpGet]
        public ViewResult Izmeni(int proizvodId) =>
            View(repozitorijum.Proizvodi.FirstOrDefault(p => p.ProizvodID == proizvodId));

        [HttpPost]
        public async Task<IActionResult> Izmeni(
            [Bind("ProizvodID, Ime, Opis, Kategorija, Cena")] Proizvod proizvod,
            IFormFile slika)
        {
            if (ModelState.IsValid)
            {
                await repozitorijum.SacuvajProizvod(proizvod);

                if (slika != null)
                {
                    FileInfo slikaInfo = new FileInfo(slika.FileName);
                    var newFilename = proizvod.ProizvodID + "_" +
                        String.Format("{0:d}", (DateTime.Now.Ticks / 10) % 100000000) +
                        slikaInfo.Extension;

                    var webPath = hostEnvironment.WebRootPath;
                    var path = Path.Combine("", webPath + @"\ProizvodiSlike\" + newFilename);
                    var pathToSave = newFilename;

                    using (var stream = new FileStream(path, FileMode.Create))
                    {
                        await slika.CopyToAsync(stream);
                    }
                    proizvod.SlikaPutanja = pathToSave;

                    await repozitorijum.SacuvajProizvod(proizvod);

                }

                TempData["poruka"] = $"{proizvod.Ime} je sačuvan!";
                return RedirectToAction("SpisakProizvoda");
            }
            else
                return View(proizvod);
        }

        public ViewResult Kreiraj() =>
            View("Izmeni", new Proizvod());

        public async Task<ViewResult> Cetovanje()
        {
            System.Security.Claims.ClaimsPrincipal trenutnoUlogovani = this.User;
            MojKorisnik user = await userManager.GetUserAsync(trenutnoUlogovani);
            return View("Cetovanje", user.UserName);
        }

    }
}
