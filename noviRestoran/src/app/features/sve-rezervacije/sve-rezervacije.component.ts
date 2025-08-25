import { Component, inject, OnInit } from '@angular/core';
import { SverezervacijeService } from '../../services/sverezervacije.service';
import { StoloviService } from '../../services/stolovi.service';
import { FormsModule } from '@angular/forms';
import { CommonModule } from '@angular/common';
import { HttpClientModule } from '@angular/common/http';

interface Reservation {
  rezervacijaID: number;
  stoID: number;
  rezervisanoOd: string;
  vrijemeRezervacije: string;
  kontaktBroj: string;
  status: string;
}

interface Table {
  stoID: number;
  brojStola: number;
  brojMjesta: number;
  dostupan: boolean;
}

@Component({
  selector: 'app-sve-rezervacije',
  standalone: true,
  imports: [FormsModule, CommonModule, HttpClientModule],
  templateUrl: './sve-rezervacije.component.html',
  styleUrls: ['./sve-rezervacije.component.css']
})
export class SveRezervacijeComponent implements OnInit {
  reservations: Reservation[] = [];
  tables: Table[] = [];
  rezervacije: any[] = [];

  private sverezervacijeService = inject(SverezervacijeService);
  private stoloviService = inject(StoloviService);

  ngOnInit(): void {
    this.fetchReservations();
    this.fetchTables();
  }

  fetchReservations(): void {
    this.sverezervacijeService.getReservations().subscribe(
      (data: Reservation[]) => {
        this.reservations = data;
      },
      error => {
        console.error('Error fetching reservations:', error);
      }
    );
  }

  fetchTables(): void {
    this.stoloviService.getTables().subscribe(
      (data: Table[]) => {
        this.tables = data;
      },
      error => {
        console.error('Error fetching tables:', error);
      }
    );
  }
  getTableDisplay(stoID: number): string {
    const table = this.tables.find(t => t.stoID === stoID);
    return table ? `Sto ${table.brojStola} - (${table.brojMjesta} mjesta)` : 'Nepoznat sto';
  }
  goBack(): void {
    window.history.back();
  }


  /*updateReservationStatus(reservation: Reservation): void {
   this.sverezervacijeService.updateReservationStatus(reservation.rezervacijaID, reservation).subscribe(
     () => {
       alert('Status je uspješno ažuriran.');
       this.fetchReservations();
     },
     error => {
       console.error('Error updating reservation status:', error);
       if (error.error && error.error.errors) {
         console.error('Validation errors:', error.error.errors);
         alert('Greška u validaciji: ' + JSON.stringify(error.error.errors));
       } else {
         alert('Status nije moguće ažurirati.');
       }
     }
   );
 }*/

}
