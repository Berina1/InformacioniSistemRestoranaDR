import { Routes } from '@angular/router';

import { PocetnaComponent } from './features/pocetna/pocetna.component';
import { ONamaComponent } from './features/o-nama/o-nama.component';
import { MeniComponent } from './features/meni/meni.component';
//import { DodajComponent } from './features/dodaj-umeni/dodaj-umeni.component';
import { KontaktComponent } from './features/kontakt/kontakt.component';
import { KreirajNarudzbuComponent } from './features/kreiraj-narudzbu/kreiraj-narudzbu.component';
import { PlacanjeComponent } from './features/placanje/placanje.component';
import { PrijavaComponent } from './features/prijava/prijava.component';
import { RacunComponent } from './features/racun/racun.component';
import { RegistracijaComponent } from './features/registracija/registracija.component';
import { RezervacijeComponent } from './features/rezervacije/rezervacije.component';
import { SveNarudzbeComponent } from './features/sve-narudzbe/sve-narudzbe.component';
import { SveRezervacijeComponent } from './features/sve-rezervacije/sve-rezervacije.component';
//import { UrediMeniComponent } from './features/uredi-meni/uredi-meni.component';

export const routes: Routes = [
  { path: '', redirectTo: '/prijava', pathMatch: 'full' },
  { path: 'pocetna', component: PocetnaComponent },
  { path: 'o-nama', component: ONamaComponent },
  { path: 'meni', component: MeniComponent },
  //{ path: 'dodaj-umeni', component: DodajComponent },  
  { path: 'kontakt', component: KontaktComponent },
  { path: 'kreiraj-narudzbu', component: KreirajNarudzbuComponent },
  { path: 'placanje', component: PlacanjeComponent },
  { path: 'prijava', component: PrijavaComponent },
  { path: 'racun', component: RacunComponent },
  { path: 'registracija', component: RegistracijaComponent },
  { path: 'rezervacije', component: RezervacijeComponent },
  { path: 'sve-narudzbe', component: SveNarudzbeComponent },
  { path: 'sve-rezervacije', component: SveRezervacijeComponent },
  //{ path: 'uredi-meni', component: UrediMeniComponent },  
];
