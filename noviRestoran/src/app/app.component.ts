import { Component } from '@angular/core';
import { RouterModule } from '@angular/router';

@Component({
  selector: 'app-root',
  standalone: true,
  imports: [RouterModule],  
  template: `
    <!-- <nav>
      <a routerLink="/pocetna">Početna</a> |
      <a routerLink="/o-nama">O Nama</a> |
      <a routerLink="/meni">Meni</a> |
      <a routerLink="/dodaj-umeni">Dodaj Jelo/Piće</a> |
      <a routerLink="/kontakt">Kontakt</a> |
      <a routerLink="/kreiraj-narudzbu">Kreiraj Narudžbu</a> |
      <a routerLink="/placanje">Plačanje</a> |
      <a routerLink="/prijava">Prijava</a> |
      <a routerLink="/racun">Račun</a> |
      <a routerLink="/registracija">Registracija</a> |
      <a routerLink="/rezervacije">Rezervacije</a> |
      <a routerLink="/sve-narudzbe">Sve Narudžbe</a> |
      <a routerLink="/sve-rezervacije">Sve Rezervacije</a> |
      <a routerLink="/uredi-meni">Uredi Meni</a>
    </nav> -->
    <router-outlet></router-outlet>  
  `,
  styles: ['nav a { margin-right: 10px; text-decoration: none; color: blue; }']
})
export class AppComponent {}
