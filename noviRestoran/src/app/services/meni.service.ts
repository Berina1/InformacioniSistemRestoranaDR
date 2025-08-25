import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root',
})
export class MeniService {
  private apiUrl = 'https://localhost:7277/api/Meni';

  constructor(private http: HttpClient) { }

  getMenuItems(): Observable<any[]> {
    return this.http.get<any[]>(this.apiUrl);
  }

  updateMenuItem(id: number, updatedItem: any): Observable<any> {
    return this.http.put<any>(`${this.apiUrl}/${id}`, updatedItem);
  }

  deleteMenuItem(id: number): Observable<string> {
    return this.http.delete(`${this.apiUrl}/${id}`, { responseType: 'text' });
  }
}
