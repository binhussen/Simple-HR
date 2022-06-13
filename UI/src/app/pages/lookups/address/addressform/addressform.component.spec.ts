import { ComponentFixture, TestBed } from '@angular/core/testing';

import { AddressformComponent } from './addressform.component';

describe('AddressformComponent', () => {
  let component: AddressformComponent;
  let fixture: ComponentFixture<AddressformComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ AddressformComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(AddressformComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
