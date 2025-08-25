import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Observable } from 'rxjs';
import { Router } from '@angular/router';

@Injectable({
  providedIn: 'root'
})
export class AuthService {

  private apiUrl = 'https://localhost:7277/api/Korisnici/register';
  private loginUrl = 'https://localhost:7277/api/Korisnici/login';
  private logoutUrl = 'https://localhost:7277/api/Korisnici/logout';

  constructor(private http: HttpClient, private router: Router) { }

  register(data: any): Observable<any> {
    return this.http.post(this.apiUrl, data, {
      headers: new HttpHeaders({
        'Content-Type': 'application/json'
      })
    });
  }

  login(credentials: any): Observable<any> {
    return this.http.post(this.loginUrl, credentials, {
      headers: new HttpHeaders({
        'Content-Type': 'application/json'
      })
    });
  }

  logout() {
    this.http.post(this.logoutUrl, {}).subscribe(() => {
      localStorage.removeItem('token');
      localStorage.removeItem('userRole');
      this.router.navigate(['/prijava']).then(() => {
        window.location.reload();
      });
    }, error => {
      console.error('Logout error:', error);
      localStorage.removeItem('token');
      localStorage.removeItem('userRole');
      this.router.navigate(['/prijava']).then(() => {
        window.location.reload();
      });
    });
  }

  isAuthenticated(): boolean {
    return !!localStorage.getItem('token');
  }
}
