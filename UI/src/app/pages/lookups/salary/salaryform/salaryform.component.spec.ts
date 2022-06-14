import { ComponentFixture, TestBed } from '@angular/core/testing';

import { SalaryformComponent } from './salaryform.component';

describe('SalaryformComponent', () => {
  let component: SalaryformComponent;
  let fixture: ComponentFixture<SalaryformComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ SalaryformComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(SalaryformComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
