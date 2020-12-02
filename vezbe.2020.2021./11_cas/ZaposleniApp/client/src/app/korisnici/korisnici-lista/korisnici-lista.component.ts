import { Component, OnInit } from '@angular/core';
import { Observable } from 'rxjs';
import { Korisnik } from 'src/app/_models/korisnik';
import { KorisniciService } from 'src/app/_services/korisnici.service';

@Component({
  selector: 'app-korisnici-lista',
  templateUrl: './korisnici-lista.component.html',
  styleUrls: ['./korisnici-lista.component.css']
})
export class KorisniciListaComponent implements OnInit {
  korisnici$: Observable<Korisnik[]>;

  constructor(private korisniciService : KorisniciService) { }

  ngOnInit(): void {
    this.korisnici$ = this.korisniciService.getKorisnici();
  }

}
