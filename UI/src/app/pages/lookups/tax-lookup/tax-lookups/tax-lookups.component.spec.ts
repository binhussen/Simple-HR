import { ComponentFixture, TestBed } from '@angular/core/testing';

import { TaxLookupsComponent } from './tax-lookups.component';

describe('TaxLookupsComponent', () => {
  let component: TaxLookupsComponent;
  let fixture: ComponentFixture<TaxLookupsComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ TaxLookupsComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(TaxLookupsComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
