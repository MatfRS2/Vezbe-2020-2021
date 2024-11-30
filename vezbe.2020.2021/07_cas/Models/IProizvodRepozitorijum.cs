using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Prodavnica2.Models
{
    public interface IProizvodRepozitorijum
    {
        IQueryable<Proizvod> Proizvodi { get; }

        Proizvod BrisiProizvod(int proizvodID);
        Task SacuvajProizvod(Proizvod proizvod);
    }
}
