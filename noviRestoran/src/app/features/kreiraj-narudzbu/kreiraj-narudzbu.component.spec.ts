import { ComponentFixture, TestBed } from '@angular/core/testing';

import { KreirajNarudzbuComponent } from './kreiraj-narudzbu.component';

describe('KreirajNarudzbuComponent', () => {
  let component: KreirajNarudzbuComponent;
  let fixture: ComponentFixture<KreirajNarudzbuComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [KreirajNarudzbuComponent]
    })
    .compileComponents();
    
    fixture = TestBed.createComponent(KreirajNarudzbuComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
