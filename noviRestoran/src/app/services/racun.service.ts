import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class RacunService {
  private apiUrl = 'https://localhost:7277/api/Racun';
  private apiUrlget = 'https://localhost:7277/api/Racun/api/racun';

  constructor(private http: HttpClient) { }

  generateRacun(narudzbaID: number, ukupno: number, nacinPlacanja: string, vrijemePlacanja: string): Observable<any> {
    const racunData = {
      NarudzbaID: narudzbaID,
      Ukupno: ukupno,
      NacinPlacanja: nacinPlacanja,
      VrijemePlacanja: vrijemePlacanja,
    };

    return this.http.post(this.apiUrl, racunData);
  }

  getRacunByNarudzbaId(narudzbaId: number): Observable<any> {
    return this.http.get<any>(`${this.apiUrlget}/${narudzbaId}`);
  }
}
