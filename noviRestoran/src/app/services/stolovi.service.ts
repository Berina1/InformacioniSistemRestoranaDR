import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';

interface Table {
  stoID: number;
  brojStola: number;
  brojMjesta: number;
  dostupan: boolean;
}

@Injectable({
  providedIn: 'root'
})
export class StoloviService {
  private stoApiUrl = 'https://localhost:7277/api/Stolovi';

  constructor(private http: HttpClient) { }

  getTables(): Observable<Table[]> {
    return this.http.get<Table[]>(this.stoApiUrl);
  }
}
