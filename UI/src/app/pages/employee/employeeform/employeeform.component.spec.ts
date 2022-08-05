import { ComponentFixture, TestBed } from '@angular/core/testing';

import { EmployeeformComponent } from './employeeform.component';

describe('EmployeeformComponent', () => {
  let component: EmployeeformComponent;
  let fixture: ComponentFixture<EmployeeformComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ EmployeeformComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(EmployeeformComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
