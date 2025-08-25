import { ComponentFixture, TestBed } from '@angular/core/testing';

import { SveRezervacijeComponent } from './sve-rezervacije.component';

describe('SveRezervacijeComponent', () => {
  let component: SveRezervacijeComponent;
  let fixture: ComponentFixture<SveRezervacijeComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [SveRezervacijeComponent]
    })
    .compileComponents();
    
    fixture = TestBed.createComponent(SveRezervacijeComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
