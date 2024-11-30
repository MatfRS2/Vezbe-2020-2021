import { Injectable } from '@angular/core';
import { CanDeactivate, ActivatedRouteSnapshot, RouterStateSnapshot, UrlTree } from '@angular/router';
import { Observable } from 'rxjs';
import { KorisniciEditComponent } from '../korisnici/korisnici-edit/korisnici-edit.component';

@Injectable({
  providedIn: 'root'
})
export class SpreciNesacuvaneIzmeneGuard implements CanDeactivate<unknown> {
  canDeactivate(component: KorisniciEditComponent): boolean {
    if (component.editForm.dirty) {
      return confirm('Da li ste sigurni da zelite da napustite stranu? Sve nesačuvane izmene će biti izgubljene.');
    }
    return true;
  }
  
}
