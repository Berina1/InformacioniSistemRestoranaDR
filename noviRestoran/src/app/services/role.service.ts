import { Injectable } from '@angular/core';

@Injectable({
  providedIn: 'root'
})
export class RoleService {
  getRole(): string {
    return localStorage.getItem('userRole') || '';
  }

  setRole(role: string): void {
    localStorage.setItem('userRole', role);
  }

  clearRole(): void {
    localStorage.removeItem('userRole');
  }

  isAdmin(): boolean {
    return this.getRole().toLowerCase() === 'admin';
  }

  isKonobar(): boolean {
    return this.getRole().toLowerCase() === 'konobar';
  }

  isKuhar(): boolean {
    return this.getRole().toLowerCase() === 'kuhar';
  }

  isKorisnik(): boolean {
    return this.getRole().toLowerCase() === 'korisnik';
  }
}
