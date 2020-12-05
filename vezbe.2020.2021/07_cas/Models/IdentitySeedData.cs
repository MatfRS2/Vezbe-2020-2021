using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;

namespace Prodavnica2.Models
{
    public static class IdentitySeedData
    {
        public static async void DodajDefaultRole(IApplicationBuilder app)
        {
            UserManager<MojKorisnik> userManager =
                app.ApplicationServices.GetRequiredService<UserManager<MojKorisnik>>();

            RoleManager<IdentityRole> roleManager =
                app.ApplicationServices.GetRequiredService<RoleManager<IdentityRole>>();

            MojKorisnik korisnik = await userManager
                .FindByEmailAsync("danijela@matf.bg.ac.rs");

            if (korisnik == null)
            { }

            var roleExist = await roleManager.RoleExistsAsync("Administrator");
            if (!roleExist)
                await roleManager.CreateAsync(new IdentityRole("Administrator"));

            roleExist = await roleManager.RoleExistsAsync("ObicanKorisnik");
            if (!roleExist)
                await roleManager.CreateAsync(new IdentityRole("ObicanKorisnik"));

            await userManager.AddToRoleAsync(korisnik, "Administrator");
        }
    }
}
