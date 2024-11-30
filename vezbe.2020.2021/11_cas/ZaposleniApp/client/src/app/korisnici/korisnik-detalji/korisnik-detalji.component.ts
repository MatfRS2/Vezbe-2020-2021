import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { NgxGalleryAnimation, NgxGalleryImage, NgxGalleryOptions } from '@kolkov/ngx-gallery';
import { Korisnik } from 'src/app/_models/korisnik';
import { KorisniciService } from 'src/app/_services/korisnici.service';

@Component({
  selector: 'app-korisnik-detalji',
  templateUrl: './korisnik-detalji.component.html',
  styleUrls: ['./korisnik-detalji.component.css']
})
export class KorisnikDetaljiComponent implements OnInit {
  korisnik: Korisnik;
  galleryOptions: NgxGalleryOptions[];
  galleryImages: NgxGalleryImage[];

  constructor(private korisnikService: KorisniciService, private route: ActivatedRoute) { }

  ngOnInit(): void {
    this.loadKorisnik();

    this.galleryOptions = [
      {
        width: '500px',
        height: '500px',
        imagePercent: 100,
        thumbnailsColumns: 4,
        imageAnimation: NgxGalleryAnimation.Slide,
        preview: false
      }
    ]
  }

  getSlike(): NgxGalleryImage[] {
    const slikeUrl = [];
    for (const slika of this.korisnik.slike) {
      slikeUrl.push({
        small: slika?.url,
        medium: slika?.url,
        big: slika?.url,
      })
    }

    return slikeUrl;
  }

  loadKorisnik() {
    this.korisnikService.getKorisnik(this.route.snapshot.paramMap.get('username')).subscribe(korisnik => {
      this.korisnik = korisnik;
      this.galleryImages = this.getSlike();
    });

    
  }

  
}
