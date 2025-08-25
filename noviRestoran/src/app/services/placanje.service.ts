import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { loadStripe } from '@stripe/stripe-js';

@Injectable({
  providedIn: 'root'
})
export class PaymentService {
  private apiUrl = 'https://localhost:7277/api/placanje/create-checkout-session';
  stripePromise = loadStripe('pk_test_51R5XcqG1Riht5g8cIl9aTWaNTE7QagGOfbprmxt4do27vLabdny5q9QVLJZNE16X6RQlJD8OCSxr0FY8QKMZl54A00cpOSSlxD');

  constructor(private http: HttpClient) { }

  async checkout(itemName: string, amount: number) {
    try {
      const session = await this.http.post<{ sessionId: string }>(
        this.apiUrl,
        { itemName, amount }
      ).toPromise();

      const stripe = await this.stripePromise;
      if (stripe && session?.sessionId) {
        await stripe.redirectToCheckout({ sessionId: session.sessionId });
      } else {
        console.error('Stripe initialization failed');
      }
    } catch (error) {
      console.error('Payment error:', error);
    }
  }
}

