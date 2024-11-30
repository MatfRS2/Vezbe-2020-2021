import { Slika } from './slika';

export interface Korisnik {
    id: number;
    userName: string;
    brojGodina: number;
    glavnaSlikaUrl: string;
    radnaPozicija: string;
    datumZaposlenja: Date;
    poslednjaAktivnost: Date;
    tim: string;
    informacije: string;
    obrazovanje: string;
    interesovanja: string;
    grad: string;
    drzava: string;
    slike: Slika[];
  }