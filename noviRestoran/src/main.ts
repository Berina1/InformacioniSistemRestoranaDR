import { bootstrapApplication } from '@angular/platform-browser';
import { provideRouter, Routes } from '@angular/router';
import { AppComponent } from './app/app.component';
import { KontaktComponent } from './app/features/kontakt/kontakt.component';
import { KreirajNarudzbuComponent } from './app/features/kreiraj-narudzbu/kreiraj-narudzbu.component';
import { MeniComponent } from './app/features/meni/meni.component';
import { ONamaComponent } from './app/features/o-nama/o-nama.component';
import { PlacanjeComponent } from './app/features/placanje/placanje.component';
import { PocetnaComponent } from './app/features/pocetna/pocetna.component';
import { PrijavaComponent } from './app/features/prijava/prijava.component';
import { RacunComponent } from './app/features/racun/racun.component';
import { RegistracijaComponent } from './app/features/registracija/registracija.component';
import { RezervacijeComponent } from './app/features/rezervacije/rezervacije.component';
import { SveNarudzbeComponent } from './app/features/sve-narudzbe/sve-narudzbe.component';
import { SveRezervacijeComponent } from './app/features/sve-rezervacije/sve-rezervacije.component';
import { DodajComponent } from './app/features/dodaj-umeni/dodaj-umeni.component';
import { UrediComponent } from './app/features/uredi-meni/uredi-meni.component';
import { HttpClientModule, provideHttpClient } from '@angular/common/http';

const routes: Routes = [
  { path: '', redirectTo: '/prijava', pathMatch: 'full' },
  { path: 'prijava', component: PrijavaComponent },
  { path: 'pocetna', component: PocetnaComponent },
  { path: 'onama', component: ONamaComponent },
  { path: 'meni', component: MeniComponent },
  { path: 'rezervacije', component: RezervacijeComponent },
  { path: 'kontakt', component: KontaktComponent },
  { path: 'prijava', component: PrijavaComponent },
  { path: 'dodaj-umeni', component: DodajComponent },
  { path: 'kreirajNarudzbu', component: KreirajNarudzbuComponent },
  { path: 'sveNarudzbe', component: SveNarudzbeComponent },
  // {path: 'uredi-meni', component: UrediComponent},
  { path: 'uredi-meni/:id', component: UrediComponent },
  { path: 'sveRezervacije', component: SveRezervacijeComponent },
  { path: 'registracija', component: RegistracijaComponent },
  //{ path: 'racun', component:RacunComponent},
  { path: 'sveNarudzbe/racun/:narudzbaId', component: RacunComponent },
  // { path: 'racun/:narudzbaID', component: RacunComponent },
  { path: 'placanje', component: PlacanjeComponent },
];

bootstrapApplication(AppComponent, {
  providers: [
    provideRouter(routes),
    provideHttpClient(),
  ],
}).catch(err => console.error(err));

