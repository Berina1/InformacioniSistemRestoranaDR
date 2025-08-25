import { Component, OnInit, inject } from '@angular/core';
import { FormBuilder, FormGroup, ReactiveFormsModule, Validators } from '@angular/forms';
import { AuthService } from '../../services/auth.service';
import { RouterModule } from '@angular/router';
import { CommonModule } from '@angular/common';
import { Router } from '@angular/router';
import { Location } from '@angular/common';

@Component({
  selector: 'app-prijava',
  standalone: true,
  imports: [RouterModule, ReactiveFormsModule, CommonModule],
  templateUrl: './prijava.component.html',
  styleUrls: ['./prijava.component.css']
})
export class PrijavaComponent implements OnInit {
  loginForm!: FormGroup;
  successMessage!: string;
  errorMessage!: string;

  private fb = inject(FormBuilder);
  private authService = inject(AuthService);

  constructor(private router: Router, private location: Location) { }

  ngOnInit(): void {
    this.loginForm = this.fb.group({
      email: ['', [Validators.required, Validators.email]],
      lozinka: ['', [Validators.required, Validators.minLength(6)]]
    });

    this.location.replaceState('/prijava');
  }
  onSubmit(): void {
    if (this.loginForm.valid) {
      const formData = this.loginForm.value;

      this.authService.login(formData).subscribe(
        (response: any) => {
          localStorage.setItem('userRole', response.uloga);
          localStorage.setItem('userEmail', response.email);

          this.successMessage = 'Korisnik je uspješno prijavljen!';
          this.loginForm.reset();
          this.router.navigate(['/pocetna']);
        },
        error => {
          this.errorMessage = 'Greška pri prijavi. Pokušajte ponovo.';
          console.error('Greška:', error);
        }
      );
    }
  }
}
