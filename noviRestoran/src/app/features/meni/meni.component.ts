import { Component, inject, OnInit } from '@angular/core';
import { Router, RouterModule } from '@angular/router';
import { CommonModule } from '@angular/common';
import { MeniService } from '../../services/meni.service';
import { RoleService } from '../../services/role.service';
import { AuthService } from '../../services/auth.service';

@Component({
  selector: 'app-meni',
  standalone: true,
  imports: [CommonModule, RouterModule],
  templateUrl: './meni.component.html',
  styleUrls: ['./meni.component.css']
})
export class MeniComponent implements OnInit {
  private meniService = inject(MeniService);
  private router = inject(Router);
  constructor(public roleService: RoleService, private authService: AuthService) { }

  menuItems: any[] = [];
  foodItems: any[] = [];
  drinkItems: any[] = [];
  isModalVisible = false;
  selectedItemId: number | null = null;

  ngOnInit() {
    this.meniService.getMenuItems().subscribe(
      (data) => {
        this.menuItems = data;
        this.filterItems();
      },
      (error) => {
        console.error('Greška pri dohvaćanju podataka:', error);
      }
    );
  }

  filterItems() {
    this.foodItems = this.menuItems.filter(item => !item.obrisano && item.kategorija);
    this.drinkItems = this.menuItems.filter(item => !item.obrisano && !item.kategorija);
  }

  confirmDeleteModal(id: number): void {
    this.selectedItemId = id;
    this.isModalVisible = true;
  }
  confirmDelete() {
    if (this.selectedItemId !== null) {
      this.meniService.deleteMenuItem(this.selectedItemId).subscribe(
        (response) => {
          alert(response);
          this.menuItems = this.menuItems.filter(item => item.meniID !== this.selectedItemId);
          this.filterItems();
          this.isModalVisible = false;
        },
        (error) => {
          console.error('Greška pri brisanju proizvoda:', error);
          alert('Došlo je do greške prilikom brisanja.');
          this.isModalVisible = false;
        }
      );
    }
  }

  closeModal(event?: MouseEvent): void {
    if (!event || event.target === event.currentTarget) {
      this.isModalVisible = false;
    }
  }
  deleteMenuItem(id: number) {
    const itemToUpdate = this.menuItems.find(item => item.meniID === id);
    if (itemToUpdate) {
      itemToUpdate.obrisano = true;
      this.meniService.updateMenuItem(id, itemToUpdate).subscribe(
        () => {
          alert('Proizvod je uspješno obrisan.');
          this.menuItems = this.menuItems.filter(item => item.meniID !== id);
          this.filterItems();
        },
        (error) => {
          console.error('Greška prilikom brisanja proizvoda.', error);
          alert('Greška prilikom brisanja proizvoda.');
        }
      );
    }
  }

  editItem(meniID: string) {
    this.router.navigate(['/uredi-meni', meniID]);
  }

  logout() {
    this.authService.logout();
  }
}
