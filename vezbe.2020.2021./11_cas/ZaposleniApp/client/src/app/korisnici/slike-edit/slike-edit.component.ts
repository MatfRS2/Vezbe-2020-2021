import { Component, Input, OnInit } from '@angular/core';
import { FileUploader } from 'ng2-file-upload';
import { take } from 'rxjs/operators';
import { Korisnik } from 'src/app/_models/korisnik';
import { Slika } from 'src/app/_models/slika';
import { User } from 'src/app/_models/user';
import { AccountService } from 'src/app/_services/account.service';
import { KorisniciService } from 'src/app/_services/korisnici.service';
import { environment } from 'src/environments/environment';

@Component({
  selector: 'app-slike-edit',
  templateUrl: './slike-edit.component.html',
  styleUrls: ['./slike-edit.component.css']
})
export class SlikeEditComponent implements OnInit {
  @Input() korisnik: Korisnik;
  uploader: FileUploader;
  hasBazeDropzoneOver = false;
  baseUrl = environment.apiUrl;
  user: User;

  constructor(private accountService: AccountService,
              private korisnikService: KorisniciService) { 
    this.accountService.currentUser$.pipe(take(1)).subscribe(user => this.user = user);
  }

  ngOnInit(): void {
    this.inicijalizujUploader();
  }

  fileOverBase(e: any) {
    this.hasBazeDropzoneOver = e;
  }

  inicijalizujUploader() {
    this.uploader = new FileUploader({
      url: this.baseUrl + 'users/dodaj-sliku',
      authToken: 'Bearer ' + this.user.token,
      isHTML5: true,
      allowedFileType: ['image'],
      removeAfterUpload: true,
      autoUpload: false,
      maxFileSize: 10 * 1024 * 1024
    });

    
    this.uploader.onAfterAddingFile = (file) => {
      file.withCredentials = false;
    }

    this.uploader.onSuccessItem = (item, response, status, headers) => {
      if (response) {
        const slika = JSON.parse(response);
        this.korisnik.slike.push(slika);
      }
    }
  }

  postaviGlavnuSliku(slika: Slika) {
    this.korisnikService.postaviGlavnuSliku(slika.id).subscribe(() => {
      this.korisnik.glavnaSlikaUrl = slika.url;
      this.korisnik.slike.forEach( p=> {
        if (p.glavnaSlika) p.glavnaSlika = false;
        if (p.id == slika.id) p.glavnaSlika = true;
      })
    });
  }

  obrisiSliku(photoId: number) {
    this.korisnikService.izbrisiSliku(photoId).subscribe(() => {
      this.korisnik.slike = this.korisnik.slike.filter(x => x.id != photoId);
    });
  }


}
