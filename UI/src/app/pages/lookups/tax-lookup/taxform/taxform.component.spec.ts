import { ComponentFixture, TestBed } from '@angular/core/testing';

import { TaxformComponent } from './taxform.component';

describe('TaxformComponent', () => {
  let component: TaxformComponent;
  let fixture: ComponentFixture<TaxformComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ TaxformComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(TaxformComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
