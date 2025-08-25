import {
  Component,
  AfterViewInit,
  QueryList,
  ViewChildren,
  ElementRef
} from '@angular/core';
import { CommonModule } from '@angular/common';
import { RouterModule } from '@angular/router';
import { AuthService } from '../../services/auth.service';
import { RoleService } from '../../services/role.service';

@Component({
  selector: 'app-o-nama',
  standalone: true,
  imports: [CommonModule, RouterModule],
  templateUrl: './o-nama.component.html',
  styleUrls: ['./o-nama.component.css']
})
export class ONamaComponent implements AfterViewInit {
  constructor (private authService: AuthService, public roleService: RoleService){}
  index = 0;
  intervalId: any;

  @ViewChildren('testimonialSlide') slides!: QueryList<ElementRef>;
  @ViewChildren('dot') dots!: QueryList<ElementRef>;

  ngAfterViewInit(): void {
    this.showSlide(this.index);

    this.intervalId = setInterval(() => this.nextSlide(), 3000);

    this.dots.forEach((dot, i) => {
      dot.nativeElement.addEventListener('click', () => {
        this.index = i;
        this.showSlide(this.index);
      });
    });

    const container = document.querySelector('.testimonial-container');
    container?.addEventListener('mouseenter', () => clearInterval(this.intervalId));
    container?.addEventListener('mouseleave', () => {
      this.intervalId = setInterval(() => this.nextSlide(), 3000);
    });
  }

  showSlide(i: number): void {
    this.slides.forEach((slide) =>
      slide.nativeElement.classList.remove('active')
    );
    this.dots.forEach((dot) => dot.nativeElement.classList.remove('active'));

    this.slides.toArray()[i]?.nativeElement.classList.add('active');
    this.dots.toArray()[i]?.nativeElement.classList.add('active');
  }

  nextSlide(): void {
    this.index = (this.index + 1) % this.slides.length;
    this.showSlide(this.index);
  }

   logout() {
    this.authService.logout();
  }

}
