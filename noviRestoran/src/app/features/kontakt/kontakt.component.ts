import { Component } from '@angular/core';
import { CommonModule } from '@angular/common';
import { RouterModule } from '@angular/router';
import { AuthService } from '../../services/auth.service';
import { RoleService } from '../../services/role.service';

@Component({
  selector: 'app-kontakt',
  standalone: true,
  imports: [CommonModule, RouterModule],
  templateUrl: './kontakt.component.html',
  styleUrls: ['./kontakt.component.css']
})
export class KontaktComponent {
  constructor(private authService: AuthService, public roleService: RoleService) { }

  logout() {
    this.authService.logout();
  }
}
