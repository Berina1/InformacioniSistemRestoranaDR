import { Component } from '@angular/core';
import { RezervacijeService } from '../../services/rezervacije.service';
import { FormsModule, NgForm } from '@angular/forms';
import { inject } from '@angular/core';
import { Router, RouterModule } from '@angular/router';
import { provideHttpClient } from '@angular/common/http';
import { RoleService } from '../../services/role.service';
import { AuthService } from '../../services/auth.service';
import { CommonModule } from '@angular/common';

@Component({
  selector: 'app-rezervacije',
  standalone: true,
  imports: [RouterModule, FormsModule, CommonModule],
  providers: [RezervacijeService],
  templateUrl: './rezervacije.component.html',
  styleUrls: ['./rezervacije.component.css']
})
export class RezervacijeComponent {
  imePrezime: string = '';
  telefon: string = '';
  vrijeme: string = '';
  brojGostiju: number | null = null;
  email: string = '';

  private rezervacijeService = inject(RezervacijeService);

  constructor(private router: Router, private authService: AuthService, public roleService: RoleService) { }

  potvrdiRezervaciju(): void {
    if (!this.imePrezime || !this.telefon || !this.vrijeme || !this.brojGostiju) {
      alert("Sva polja moraju biti popunjena!");
      return;
    }

    const rezervacijaData = {
      rezervacijaID: 0,
      stoID: 2,
      rezervisanoOd: this.imePrezime,
      vrijemeRezervacije: this.vrijeme,
      kontaktBroj: this.telefon,
      email: this.email,
      status: "Na cekanju"
    };

    this.rezervacijeService.potvrdiRezervaciju(rezervacijaData).subscribe(
      (data) => {
        alert('Rezervacija je uspješno potvrđena!');
        console.log(data);
        this.router.navigate(['/']);

      },
      (error) => {
        alert('Došlo je do greške prilikom slanja rezervacije.');
        console.error('Error:', error);
      }
    );
  }

  ponistiFormu(): void {
    this.imePrezime = '';
    this.telefon = '';
    this.vrijeme = '';
    this.brojGostiju = null;
  }

   logout() {
    this.authService.logout();
  }
}
