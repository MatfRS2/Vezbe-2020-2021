using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.SignalR;

namespace Prodavnica2.Hubs
{
    public class CetHub : Hub
    {
        public async Task PosaljiPoruku(string korisnik, string poruka)
        {
            await Clients.All.SendAsync("PrimiPoruku", korisnik, poruka);
        }
    }
}
