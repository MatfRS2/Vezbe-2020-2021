using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Prodavnica2.Models;
using Prodavnica2.Models.ViewModels;

namespace Prodavnica2.Controllers
{
    [Authorize (Roles = "Administrator")]
    public class AccountController : Controller
    {
        private UserManager<MojKorisnik> userManager;
        private RoleManager<IdentityRole> roleManager;
        private SignInManager<MojKorisnik> signInManager;

        public AccountController(UserManager<MojKorisnik> usrManager,
                                 RoleManager<IdentityRole> rolemng,
                                 SignInManager<MojKorisnik> signmng)
        {
            userManager = usrManager;
            roleManager = rolemng;
            signInManager = signmng;
        }

        public ViewResult Korisnici()
            => View(userManager.Users);

        [HttpGet]
        public ViewResult KreirajKorisnika() => View();

        [HttpPost]
        public async Task<IActionResult> KreirajKorisnika(KreirajViewModel korisnik)
        {
            if (ModelState.IsValid)
            {
                MojKorisnik mojKorisnik = new MojKorisnik
                {
                    UserName = korisnik.Ime,
                    Email = korisnik.Email
                };

                IdentityResult result =
                    await userManager.CreateAsync(mojKorisnik, korisnik.Sifra);

                if (result.Succeeded)
                {
                    await userManager.AddToRoleAsync(mojKorisnik, "ObicanKorisnik");

                    TempData["poruka"] = $"{korisnik.Ime} uspešno kreiran!";
                    return RedirectToAction("Korisnici");
                }
                else
                {
                    foreach (IdentityError e in result.Errors)
                        ModelState.AddModelError("", e.Description);
                }
            }

            return View(korisnik);
        }

        [HttpPost]
        public async Task<IActionResult> Obrisi(string id)
        {
            MojKorisnik mojKorisnik = await userManager.FindByIdAsync(id);

            if (mojKorisnik != null)
            {
                IdentityResult result = await userManager.DeleteAsync(mojKorisnik);

                if (result.Succeeded)
                {
                    TempData["poruka"] = $"{mojKorisnik.UserName} je obrisan!";
                    return RedirectToAction("Korisnici");
                }
                else
                {
                    foreach (IdentityError e in result.Errors)
                        ModelState.AddModelError("", e.Description);
                }
            }
            else
                ModelState.AddModelError("", "Ne postoji korisnik");

            return View("Korisnici");
        }

        [AllowAnonymous]
        [HttpGet]
        public ViewResult Prijavljivanje() => View();

        [AllowAnonymous]
        [HttpPost]
        public async Task<IActionResult> Prijavljivanje(PrijavljivanjeViewModel korisnik)
        {
            if (ModelState.IsValid)
            {
                MojKorisnik mojkorisnik = await userManager.FindByEmailAsync(korisnik.Email);

                if (korisnik != null)
                {
                    await signInManager.SignOutAsync();

                    Microsoft.AspNetCore.Identity.SignInResult rezultat = await signInManager
                        .PasswordSignInAsync(mojkorisnik, korisnik.Sifra, false, false);

                    if (rezultat.Succeeded)
                        return Redirect("/Admin/SpisakProizvoda");
                }

                ModelState.AddModelError("", "Nepostojeći korisnik!");
            }

            return View();
        }

        [AllowAnonymous]
        public async Task<RedirectToActionResult> Odjava()
        {
            await signInManager.SignOutAsync();
            return RedirectToAction("Spisak", "Proizvod");
        }
    }
}
