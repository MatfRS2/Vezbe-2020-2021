using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Prodavnica2.Models
{
    public class EFRepozotorijum : IProizvodRepozitorijum
    {
        private ApplicationDbContext repozitorijum;

        public EFRepozotorijum(ApplicationDbContext repo)
        {
            repozitorijum = repo;
        }

        public IQueryable<Proizvod> Proizvodi => repozitorijum.Proizvodi;

        public Proizvod BrisiProizvod(int proizvodID)
        {
            Proizvod dbProizvod = repozitorijum.Proizvodi
                .FirstOrDefault(p => p.ProizvodID == proizvodID);

            if (dbProizvod != null)
            {
                repozitorijum.Proizvodi.Remove(dbProizvod);
                repozitorijum.SaveChanges();
            }

            return dbProizvod;
        }

        public async Task SacuvajProizvod(Proizvod proizvod)
        {
            if (proizvod.ProizvodID == 0)
                repozitorijum.Proizvodi.Add(proizvod);
            else
                repozitorijum.Proizvodi.Update(proizvod);

            await repozitorijum.SaveChangesAsync();
        }
    }
}
