import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { HomeComponent } from './home/home.component';
import { KorisniciListaComponent } from './korisnici/korisnici-lista/korisnici-lista.component';
import { KorisnikDetaljiComponent } from './korisnici/korisnik-detalji/korisnik-detalji.component';
import { ListsComponent } from './lists/lists.component';
import { PorukeComponent } from './poruke/poruke.component';
import { AuthGuard } from './_guards/auth.guard';

const routes: Routes = [
  {path: '', component:HomeComponent},
  {path: 'korisnici', component: KorisniciListaComponent, canActivate: [AuthGuard]},
  {path: 'korisnici/:id', component: KorisnikDetaljiComponent, canActivate: [AuthGuard]},
  {path: 'liste', component: ListsComponent, canActivate: [AuthGuard]},
  {path: 'poruke', component: PorukeComponent, canActivate: [AuthGuard]},
  {path: '**', component:HomeComponent, pathMatch: 'full'}
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
