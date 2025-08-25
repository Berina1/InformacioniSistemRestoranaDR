import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Observable } from 'rxjs';

export interface DetaljNarudzbeDTO {
  meni: {
    naziv: string;
    cijena: number;
  };
  kolicina: number;
  ukupnaCijena: number;
}

export interface Narudzba {
  narudzbaID: number;
  detaljiNarudzbeDTO: DetaljNarudzbeDTO[];
  ukupno: number;
  status: string;
}

@Injectable({
  providedIn: 'root'
})
export class SvenarudzbeService {
  private apiURL = 'https://localhost:7277/api/Narudzba';

  constructor(private http: HttpClient) { }

  fetchOrders(): Observable<Narudzba[]> {
    return this.http.get<Narudzba[]>(this.apiURL);
  }

  updateOrderStatus(orderId: number, newStatus: string): Observable<any> {
    const url = `${this.apiURL}/${orderId}?status=${newStatus}`;
    return this.http.put(url, null, {
      headers: new HttpHeaders({
        'Content-Type': 'application/json'
      })
    });
  }

  fetchOrderDetails(narudzbaID: number): Observable<Narudzba> {
    return this.http.get<Narudzba>(`https://localhost:7277/api/Narudzba/${narudzbaID}`);
  }

}
