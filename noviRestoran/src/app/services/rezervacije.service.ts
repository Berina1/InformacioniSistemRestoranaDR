import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class RezervacijeService {

  private apiUrl = 'https://localhost:7277/api/Rezervacija';

  constructor(private http: HttpClient) { }

  potvrdiRezervaciju(rezervacijaData: any): Observable<any> {
    return this.http.post<any>(this.apiUrl, rezervacijaData);
  }
}