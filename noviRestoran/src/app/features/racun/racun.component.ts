import { Component, inject } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { CommonModule } from '@angular/common';
import { RacunService } from '../../services/racun.service';
import { RouterModule } from '@angular/router';

@Component({
  selector: 'app-racun',
  standalone: true,
  imports: [CommonModule, RouterModule],
  templateUrl: './racun.component.html',
  styleUrl: './racun.component.css'
})
export class RacunComponent {
  narudzbaID!: number;
  racun: any = null;
  loading: boolean = true;
  error: string | null = null;

  private route = inject(ActivatedRoute);
  private racunService = inject(RacunService);

  constructor() {
    this.narudzbaID = Number(this.route.snapshot.paramMap.get('narudzbaId'));
    this.fetchRacunDetails();
  }

  fetchRacunDetails(): void {
    this.racunService.getRacunByNarudzbaId(this.narudzbaID).subscribe({
      next: (response) => {
        this.racun = response;
        this.loading = false;
      },
      error: (error) => {
        console.error('Error fetching invoice:', error);
        this.error = 'Failed to fetch invoice details.';
        this.loading = false;
      }
    });
  }
}
