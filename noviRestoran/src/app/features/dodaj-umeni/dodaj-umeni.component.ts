import { Component, inject } from '@angular/core';
import { DodajService } from '../../services/dodaj.service';
import { Router, RouterModule } from '@angular/router';
import { FormsModule } from '@angular/forms';
import { CommonModule } from '@angular/common';

@Component({
  selector: 'app-dodaj',
  standalone: true,
  imports: [RouterModule, FormsModule, CommonModule],
  templateUrl: './dodaj-umeni.component.html',
  styleUrls: ['./dodaj-umeni.component.css']
})
export class DodajComponent {
  name: string = '';
  category: string = '';
  description: string = '';
  price: number = 0;
  image: string = '';
  message: string = '';
  messageClass: string = '';

  private dodajService = inject(DodajService);
  private router = inject(Router);

  potvrdiFormu(): void {
    if (!this.name || !this.category || !this.description || isNaN(this.price) || !this.image) {
      this.message = 'Niste popunili sva polja!';
      this.messageClass = 'error';
      return;
    }

    const isCategoryFood = this.category === 'Jelo';

    const formData = {
      naziv: this.name,
      kategorija: isCategoryFood,
      opis: this.description,
      cijena: this.price,
      slika: this.image
    };

    this.dodajService.dodajMeniItem(formData).subscribe(
      (response) => {
        this.message = 'Uspješno dodano!';
        this.messageClass = 'success';
        this.clearForm();
        alert('Podaci su uspješno ažurirani!');
        this.router.navigate(['/meni']);
      },
      (error) => {
        this.message = 'Greška pri dodavanju kartice menija';
        this.messageClass = 'error';
      }
    );
  }

  ponistiFormu(): void {
    this.clearForm();
  }

  clearForm(): void {
    this.name = '';
    this.category = '';
    this.description = '';
    this.price = 0;
    this.image = '';
  }
}
