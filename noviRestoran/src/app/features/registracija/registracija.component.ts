import { Component, OnInit, inject } from '@angular/core';
import { FormBuilder, FormGroup, ReactiveFormsModule, Validators } from '@angular/forms';
import { AuthService } from '../../services/auth.service';
import { Router } from '@angular/router';
import { CommonModule } from '@angular/common';

@Component({
  selector: 'app-registracija',
  standalone: true,
  imports: [CommonModule, ReactiveFormsModule],
  templateUrl: './registracija.component.html',
  styleUrls: ['./registracija.component.css']
})
export class RegistracijaComponent implements OnInit {
  registerForm!: FormGroup;
  successMessage!: string;
  errorMessage!: string;

  private fb = inject(FormBuilder);
  private authService = inject(AuthService);
  private router = inject(Router);

  constructor() { }

  ngOnInit(): void {
    this.registerForm = this.fb.group({
      ImePrezime: ['', Validators.required],
      KorisnickoIme: ['', Validators.required],
      email: ['', [Validators.required, Validators.email]],
      lozinka: ['', [Validators.required, Validators.minLength(6)]]
    });
  }

  onSubmit(): void {
    if (this.registerForm.valid) {
      const formData = this.registerForm.value;
      const dataToSend = {
        ...formData,
        smjena: 'Jutarnja',
        uloga: 'Korisnik'
      };

      this.authService.register(dataToSend).subscribe(
        response => {
          this.successMessage = 'Korisnik je uspješno registrovan!';
          this.registerForm.reset();
          this.router.navigate(['/prijava']);
        },
        error => {
          this.errorMessage = 'Greška pri registraciji. Pokušajte ponovo.';
          console.error('Greška:', error);
        }
      );
    }
  }
}
