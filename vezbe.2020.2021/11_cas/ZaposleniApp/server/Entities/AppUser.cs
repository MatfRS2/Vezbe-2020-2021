using System;
using System.Collections.Generic;

namespace server.Entities
{
    public class AppUser
    {
        public int Id { get; set; }
        public string UserName { get; set; }

        public byte[] PasswordHash { get; set; }
        public byte[] PasswordSalt { get; set; }

        public DateTime DatumRodjenja { get; set; }
        public string RadnaPozicija { get; set; }
        public DateTime DatumZaposlenja { get; set; } = DateTime.Now;
        public DateTime PoslednjaAktivnost { get; set; } = DateTime.Now;
        public string Tim { get; set; }
        public string Informacije { get; set; }
        public string Obrazovanje { get; set; }
        public string Interesovanja { get; set; }
        public string Grad { get; set; }
        public string Drzava { get; set; }
        public ICollection<Photo> Slike { get; set; }

        public int GetBrojGodina()
        {
            var danas = DateTime.Today;
            var godina = danas.Year - DatumRodjenja.Year;
            if (DatumRodjenja.Date > danas.AddYears(-godina)) godina--;

            return godina;
        }
    }
}