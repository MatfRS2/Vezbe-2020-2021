import { Component, Input, OnInit } from '@angular/core';
import { Korisnik } from 'src/app/_models/korisnik';

@Component({
  selector: 'app-korisnik-kartica',
  templateUrl: './korisnik-kartica.component.html',
  styleUrls: ['./korisnik-kartica.component.css']
})
export class KorisnikKarticaComponent implements OnInit {
  @Input() korisnik: Korisnik;

  constructor() { }

  ngOnInit(): void {
  }

}
