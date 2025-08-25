import { Component } from '@angular/core';
import { RouterModule } from '@angular/router';
import { QRCodeModule } from 'angularx-qrcode';
import { AuthService } from '../../services/auth.service';
import { RoleService } from '../../services/role.service';
import { CommonModule } from '@angular/common';

@Component({
  selector: 'app-pocetna',
  standalone: true,
  imports: [RouterModule, QRCodeModule, CommonModule],
  templateUrl: './pocetna.component.html',
  styleUrl: './pocetna.component.css'
})
export class PocetnaComponent {
  myAngularxQrCode: string = 'https://example.com';
  constructor(private authService: AuthService, public roleService: RoleService) { }

  logout() {
    this.authService.logout();
  }

}
