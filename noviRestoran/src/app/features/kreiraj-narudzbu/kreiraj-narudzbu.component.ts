import { Component, inject } from '@angular/core';
import { CommonModule } from '@angular/common';
import { NarudzbaService } from '../../services/narudzba.service';
import { RouterModule } from '@angular/router';
import { FormsModule } from '@angular/forms';

@Component({
  selector: 'app-kreiraj-narudzbu',
  standalone: true,
  imports: [CommonModule, RouterModule, FormsModule],
  templateUrl: './kreiraj-narudzbu.component.html',
  styleUrl: './kreiraj-narudzbu.component.css'
})
export class KreirajNarudzbuComponent {
  private narudzbaService = inject(NarudzbaService);
  dishes: any[] = [];
  prices: { [key: string]: number } = {};
  total: number = 0;
  orderItems: { meniID: number; kolicina: number; ukupnaCijena: number }[] = [];

  constructor() {
    this.loadMenu();
  }

  loadMenu(): void {
    this.narudzbaService.getMenuItems().subscribe({
      next: (menuItems) => {
        this.dishes = menuItems.filter((item: any) => !item.obrisano);
        this.dishes.forEach(item => {
          this.prices[item.meniID] = item.cijena;
        });
      },
      error: (err) => {
        console.error("Error fetching menu items", err);
      }
    });
  }

  addItem(): void {
    const newItem = { meniID: 0, kolicina: 1, ukupnaCijena: 0 };
    this.orderItems.push(newItem);
    this.updatePrice();
  }

  updatePrice(): void {
    this.total = 0;
    this.orderItems.forEach((item) => {
      if (item.meniID && item.kolicina > 0) {
        item.ukupnaCijena = this.prices[item.meniID] * item.kolicina;
        this.total += item.ukupnaCijena;
      }
    });
  }

  removeItem(index: number): void {
    this.orderItems.splice(index, 1);
    this.updatePrice();
  }

  confirmOrder(): void {
    if (this.orderItems.length > 0) {
      const orderData = {
        korisnikID: 3,
        stoID: 2,
        status: 'Kreirana',
        vrijemeNarudzbe: new Date().toISOString(),
        detaljiNarudzbe: this.orderItems,
      };

      this.narudzbaService.sendOrder(orderData).subscribe({
        next: () => {
          alert('Narudžba je uspješno poslana!');
        },
        error: (error) => {
          console.error('Greška pri slanju narudžbe:', error);
          alert('Došlo je do greške pri slanju narudžbe.');
        },
      });
    } else {
      alert('Molimo unesite važeću količinu za jelo/piće.');
    }
  }

  resetForm(): void {
    this.orderItems = [];
    this.total = 0;
  }
}
