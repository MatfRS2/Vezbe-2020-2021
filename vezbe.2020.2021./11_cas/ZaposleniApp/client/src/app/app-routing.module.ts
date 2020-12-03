import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { HomeComponent } from './home/home.component';
import { KorisniciEditComponent } from './korisnici/korisnici-edit/korisnici-edit.component';
import { KorisniciListaComponent } from './korisnici/korisnici-lista/korisnici-lista.component';
import { KorisnikDetaljiComponent } from './korisnici/korisnik-detalji/korisnik-detalji.component';
import { ListsComponent } from './lists/lists.component';
import { PorukeComponent } from './poruke/poruke.component';
import { AuthGuard } from './_guards/auth.guard';
import { SpreciNesacuvaneIzmeneGuard } from './_guards/spreci-nesacuvane-izmene.guard';

const routes: Routes = [
  {path: '', component:HomeComponent},
  {path: 'korisnici', component: KorisniciListaComponent, canActivate: [AuthGuard]},
  {path: 'korisnici/:username', component: KorisnikDetaljiComponent, canActivate: [AuthGuard]},
  {path: 'korisnik/edit', component: KorisniciEditComponent, canActivate: [AuthGuard], canDeactivate: [SpreciNesacuvaneIzmeneGuard]},
  {path: 'liste', component: ListsComponent, canActivate: [AuthGuard]},
  {path: 'poruke', component: PorukeComponent, canActivate: [AuthGuard]},
  {path: '**', component:HomeComponent, pathMatch: 'full'}
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
