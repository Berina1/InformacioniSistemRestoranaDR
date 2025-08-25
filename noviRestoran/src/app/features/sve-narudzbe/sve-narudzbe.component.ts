import { Component, inject, OnInit } from '@angular/core';
import { SvenarudzbeService, Narudzba } from '../../services/svenarudzbe.service';
import { HttpClient } from '@angular/common/http';
import { Router } from '@angular/router';
import { CommonModule } from '@angular/common';

@Component({
  selector: 'app-sve-narudzbe',
  standalone: true,
  imports: [CommonModule],
  templateUrl: './sve-narudzbe.component.html',
  styleUrls: ['./sve-narudzbe.component.css']
})
export class SveNarudzbeComponent implements OnInit {
  orders: Narudzba[] = [];
  errorMessage: string = '';
  selectedPaymentMethods: { [key: number]: string } = {};

  private svenarudzbeService = inject(SvenarudzbeService);
  private http = inject(HttpClient);
  private router = inject(Router);

  ngOnInit(): void {
    this.fetchOrders();
  }

  fetchOrders(): void {
    this.svenarudzbeService.fetchOrders().subscribe({
      next: (orders) => {
        this.orders = orders;
      },
      error: (error) => {
        this.errorMessage = `Greška prilikom dohvaćanja narudžbi: ${error.message}`;
      }
    });
  }

  updateOrderStatus(orderId: number, newStatus: string): void {
    console.log(`Ažuriranje statusa narudžbe ${orderId} na ${newStatus}`);

    this.svenarudzbeService.updateOrderStatus(orderId, newStatus).subscribe({
      next: () => {
        console.log(`Status narudžbe ${orderId} ažuriran na ${newStatus}`);
        this.fetchOrders();
      },
      error: (error) => {
        console.error(`Greška prilikom ažuriranja statusa: ${error.message}`);
        this.errorMessage = `Greška prilikom ažuriranja statusa: ${error.message}`;
      }
    });
  }
  goBack(): void {
    window.history.back();
  }

  setPaymentMethod(orderId: number, method: string): void {
    this.selectedPaymentMethods[orderId] = method;
    console.log(`Postavljen način plaćanja za narudžbu ${orderId}: ${method}`);
  }

  generateInvoice(narudzbaID: number): void {
    const nacinPlacanja = this.selectedPaymentMethods[narudzbaID] || 'Gotovina';

    const invoiceData = {
      narudzbaID: narudzbaID,
      nacinPlacanja: nacinPlacanja
    };

    this.http.post('https://localhost:7277/api/Racun/generisi', invoiceData)
      .subscribe(
        (response: any) => {
          console.log('Račun je generisan:', response);
          this.router.navigate([`/sveNarudzbe/racun/${narudzbaID}`]);
        },
        (error) => {
          console.error('Greška prilikom generisanja računa:', error);
          this.errorMessage = 'Greška prilikom generisanja računa. Pokušajte ponovo.';
        }
      );
  }
}
