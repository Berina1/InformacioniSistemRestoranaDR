import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';

interface Reservation {
  rezervacijaID: number;
  stoID: number;
  rezervisanoOd: string;
  vrijemeRezervacije: string;
  kontaktBroj: string;
  status: string;
}

@Injectable({
  providedIn: 'root'
})
export class SverezervacijeService {
  private apiUrl = 'https://localhost:7277/api/Rezervacija';

  constructor(private http: HttpClient) { }

  getReservations(): Observable<Reservation[]> {
    return this.http.get<Reservation[]>(this.apiUrl);
  }

  updateReservationStatus(rezervacijaID: number, updatedReservation: Reservation): Observable<any> {
    return this.http.put(`${this.apiUrl}/${rezervacijaID}`, updatedReservation);
  }

}
