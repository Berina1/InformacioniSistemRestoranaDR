import { ComponentFixture, TestBed } from '@angular/core/testing';
import { DodajComponent} from './dodaj-umeni.component';

describe('DodajUmeniComponent', () => {
  let component: DodajComponent;
  let fixture: ComponentFixture<DodajComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [DodajComponent]
    })
    .compileComponents();
    
    fixture = TestBed.createComponent(DodajComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
