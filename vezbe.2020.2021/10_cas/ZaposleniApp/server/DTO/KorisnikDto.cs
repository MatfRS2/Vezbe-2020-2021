using System;
using System.Collections.Generic;

namespace server.DTO
{
    public class KorisnikDto
    {
        public int Id { get; set; }
        public string UserName { get; set; }

        public int BrojGodina { get; set; }
        public string GlavnaSlikaUrl { get; set; }
        public string RadnaPozicija { get; set; }
        public DateTime DatumZaposlenja { get; set; }
        public DateTime PoslednjaAktivnost { get; set; }
        public string Tim { get; set; }
        public string Informacije { get; set; }
        public string Obrazovanje { get; set; }
        public string Interesovanja { get; set; }
        public string Grad { get; set; }
        public string Drzava { get; set; }
        public ICollection<PhotoDto> Slike { get; set; }
    }
}
