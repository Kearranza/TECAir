import { ComponentFixture, TestBed } from '@angular/core/testing';

import { FlightOpeningComponent } from './flight-opening.component';

describe('FlightOpeningComponent', () => {
  let component: FlightOpeningComponent;
  let fixture: ComponentFixture<FlightOpeningComponent>;

  beforeEach(() => {
    TestBed.configureTestingModule({
      declarations: [FlightOpeningComponent]
    });
    fixture = TestBed.createComponent(FlightOpeningComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
