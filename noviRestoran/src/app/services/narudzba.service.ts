import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root',
})
export class NarudzbaService {
  private apiUrl = 'https://localhost:7277/api';

  constructor(private http: HttpClient) { }

  getMenuItems(): Observable<any> {
    return this.http.get<any>(`${this.apiUrl}/Meni`);
  }

  sendOrder(orderData: any): Observable<any> {
    return this.http.post<any>(`${this.apiUrl}/Narudzba`, orderData);
  }
}
