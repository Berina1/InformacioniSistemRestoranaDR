import { ComponentFixture, TestBed } from '@angular/core/testing';

import { SveNarudzbeComponent } from './sve-narudzbe.component';

describe('SveNarudzbeComponent', () => {
  let component: SveNarudzbeComponent;
  let fixture: ComponentFixture<SveNarudzbeComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [SveNarudzbeComponent]
    })
    .compileComponents();
    
    fixture = TestBed.createComponent(SveNarudzbeComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
