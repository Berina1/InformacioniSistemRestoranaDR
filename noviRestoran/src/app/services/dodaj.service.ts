import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class DodajService {

  private apiUrl = 'https://localhost:7277/api/Meni';

  constructor(private http: HttpClient) { }

  dodajMeniItem(formData: any): Observable<any> {
    const headers = new HttpHeaders().set('Content-Type', 'application/json');
    return this.http.post<any>(this.apiUrl, formData, { headers });
  }
}
