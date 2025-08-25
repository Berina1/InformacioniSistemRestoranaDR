import { ComponentFixture, TestBed } from '@angular/core/testing';
import { UrediComponent } from './uredi-meni.component';

describe('UrediMeniComponent', () => {
  let component: UrediComponent;
  let fixture: ComponentFixture<UrediComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [UrediComponent]
    })
    .compileComponents();
    
    fixture = TestBed.createComponent(UrediComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
