import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { HttpClientModule, HTTP_INTERCEPTORS } from '@angular/common/http';
import { FormsModule } from '@angular/forms';
import { BsDropdownModule } from 'ngx-bootstrap/dropdown';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { NavComponent } from './nav/nav.component';
import { HomeComponent } from './home/home.component';
import { RegisterComponent } from './register/register.component';
import { KorisniciListaComponent } from './korisnici/korisnici-lista/korisnici-lista.component';
import { KorisnikDetaljiComponent } from './korisnici/korisnik-detalji/korisnik-detalji.component';
import { ListsComponent } from './lists/lists.component';
import { PorukeComponent } from './poruke/poruke.component';
import { ToastrModule } from 'ngx-toastr';
import { KorisnikKarticaComponent } from './korisnici/korisnik-kartica/korisnik-kartica.component';
import { JwtInterceptor } from './_interceptors/jwt.interceptor';
import { TabsModule } from 'ngx-bootstrap/tabs';
import { NgxGalleryModule } from '@kolkov/ngx-gallery';
import { KorisniciEditComponent } from './korisnici/korisnici-edit/korisnici-edit.component';
import { SlikeEditComponent } from './korisnici/slike-edit/slike-edit.component';
import { FileUploadModule } from 'ng2-file-upload';

@NgModule({
  declarations: [
    AppComponent,
    NavComponent,
    HomeComponent,
    RegisterComponent,
    KorisniciListaComponent,
    KorisnikDetaljiComponent,
    ListsComponent,
    PorukeComponent,
    KorisnikKarticaComponent,
    KorisniciEditComponent,
    SlikeEditComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    HttpClientModule,
    BrowserAnimationsModule,
    FormsModule,
    BsDropdownModule.forRoot(),
    ToastrModule.forRoot({
      positionClass: 'toast-bottom-right'
    }),
    TabsModule.forRoot(),
    NgxGalleryModule,
    FileUploadModule
  ],
  providers: [
    {provide: HTTP_INTERCEPTORS, useClass: JwtInterceptor, multi: true},
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }
