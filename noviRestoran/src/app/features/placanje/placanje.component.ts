import { Component, OnInit, inject } from '@angular/core';
import { PaymentService } from '../../services/placanje.service';

@Component({
  selector: 'app-placanje',
  standalone: true,
  template: `<button (click)="pay()">Pay Now</button>`,
  styleUrls: ['./placanje.component.css']
})
export class PlacanjeComponent implements OnInit {
  private paymentService = inject(PaymentService);

  constructor() {}

  ngOnInit(): void {}

  pay() {
    this.paymentService.checkout('Pizza Order', 20);
    
  }
}
