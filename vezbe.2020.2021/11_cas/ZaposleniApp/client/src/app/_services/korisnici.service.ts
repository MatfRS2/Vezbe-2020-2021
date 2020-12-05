import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { of } from 'rxjs';
import { map } from 'rxjs/operators';
import { environment } from 'src/environments/environment';
import { Korisnik } from '../_models/korisnik';

@Injectable({
  providedIn: 'root'
})
export class KorisniciService {
  baseUrl = environment.apiUrl;
  korisnici: Korisnik[] = [];

  constructor(private http: HttpClient) { }

  getKorisnici() {
    if (this.korisnici.length > 0) return of(this.korisnici);

    return this.http.get<Korisnik[]>(this.baseUrl + 'users').pipe(
      map (korisnici => {
        this.korisnici = korisnici;
        return korisnici;
      })
    )
  }

  getKorisnik(username : string) {
    const korisnik = this.korisnici.find(x => x.userName === username);
    if (korisnik !== undefined) return of(korisnik);
    return this.http.get<Korisnik>(this.baseUrl + 'users/' + username);
  }

  updateKorisnik(korisnik: Korisnik) {
    return this.http.put(this.baseUrl + 'users', korisnik);
  }

  postaviGlavnuSliku(photoId: number) {
    return this.http.put(this.baseUrl + 'users/postavi-glavnu-sliku/' + photoId, {});
  }

  izbrisiSliku(photoId: number) {
    return this.http.delete(this.baseUrl + 'users/obrisi-sliku/' + photoId);
  }
}
