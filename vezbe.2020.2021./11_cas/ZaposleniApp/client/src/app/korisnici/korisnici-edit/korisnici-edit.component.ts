import { Component, HostListener, OnInit, ViewChild } from '@angular/core';
import { NgForm } from '@angular/forms';
import { ToastrService } from 'ngx-toastr';
import { take } from 'rxjs/operators';
import { Korisnik } from 'src/app/_models/korisnik';
import { User } from 'src/app/_models/user';
import { AccountService } from 'src/app/_services/account.service';
import { KorisniciService } from 'src/app/_services/korisnici.service';

@Component({
  selector: 'app-korisnici-edit',
  templateUrl: './korisnici-edit.component.html',
  styleUrls: ['./korisnici-edit.component.css']
})
export class KorisniciEditComponent implements OnInit {
  user: User;
  korisnik: Korisnik;
  @ViewChild('editForm') editForm: NgForm;
  @HostListener('window:beforeunload', ['$event']) unloadNotification($event: any) {
    if (this.editForm.dirty) {
      $event.returnValue = true;
    }
  }

  constructor(private accountService: AccountService, private korisnikService: KorisniciService,
    private toster: ToastrService) { 
    this.accountService.currentUser$.pipe(take(1)).subscribe(user => this.user = user);
  }

  ngOnInit(): void {
    this.loadKorisnik();
  }

  loadKorisnik() {
    this.korisnikService.getKorisnik(this.user.username).subscribe(korisnik =>
      this.korisnik = korisnik);
  }

  updateKorisnik() {
    this.korisnikService.updateKorisnik(this.korisnik).subscribe(() => {
      this.toster.success('Podaci uspesno promenjeni!');
      this.editForm.reset(this.korisnik);
    });
  }
}
