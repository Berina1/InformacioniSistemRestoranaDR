import { Component, inject, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { UrediService } from '../../services/uredi.service';
import { CommonModule } from '@angular/common';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { RouterModule } from '@angular/router';

@Component({
  selector: 'app-uredi',
  standalone: true,
  imports: [CommonModule, FormsModule, RouterModule],
  templateUrl: './uredi-meni.component.html',
  styleUrls: ['./uredi-meni.component.css']
})
export class UrediComponent implements OnInit {
  itemId: string | null = null;
  itemData = {
    naziv: '',
    opis: '',
    cijena: 0,
    slika: ''
  };
  isLoading = false;
  errorMessage: string | null = null;

  private urediService = inject(UrediService);
  private route = inject(ActivatedRoute);
  private router = inject(Router);

  ngOnInit(): void {
    this.itemId = this.route.snapshot.paramMap.get('id');

    if (this.itemId) {
      this.fetchItemData(this.itemId);
    } else {
      this.errorMessage = 'Nema ID-a za učitavanje podataka.';
    }
  }

  fetchItemData(id: string): void {
    this.isLoading = true;
    this.urediService.getItemData(id).subscribe(
      data => {
        this.itemData = data;
        this.isLoading = false;
      },
      error => {
        this.errorMessage = 'Greška prilikom preuzimanja podataka.';
        this.isLoading = false;
      }
    );
  }

  potvrdiPromjenu(): void {
    if (!this.itemData.naziv || !this.itemData.opis || !this.itemData.cijena) {
      alert('Molimo popunite sva obavezna polja.');
      return;
    }

    this.isLoading = true;

    this.urediService.updateItemData(this.itemId!, this.itemData).subscribe(
      data => {
        if (data.meniID) {
          alert('Podaci su uspješno ažurirani!');
          this.router.navigate(['/meni']);
        } else {
          alert('Greška pri ažuriranju podataka: Nedostaju podaci u odgovoru.');
        }
        this.isLoading = false;
      },
      error => {
        this.errorMessage = 'Greška pri ažuriranju podataka.';
        this.isLoading = false;
      }
    );
  }

  ponistiFormu(): void {
    this.itemData = {
      naziv: '',
      opis: '',
      cijena: 0,
      slika: ''
    };
  }
}
