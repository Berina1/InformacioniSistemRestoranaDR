import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class UrediService {

  private apiUrl = 'https://localhost:7277/api/Meni';

  constructor(private http: HttpClient) { }

  getItemData(id: string): Observable<any> {
    return this.http.get<any>(`${this.apiUrl}/${id}`);
  }

  updateItemData(id: string, updatedData: any): Observable<any> {
    return this.http.put<any>(`${this.apiUrl}/${id}`, updatedData, {
      headers: new HttpHeaders({
        'Content-Type': 'application/json'
      })
    });
  }
}
