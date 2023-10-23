import { ComponentFixture, TestBed } from '@angular/core/testing';

import { FlightDisplayComponent } from './flight-display.component';

describe('FlightDisplayComponent', () => {
  let component: FlightDisplayComponent;
  let fixture: ComponentFixture<FlightDisplayComponent>;

  beforeEach(() => {
    TestBed.configureTestingModule({
      declarations: [FlightDisplayComponent]
    });
    fixture = TestBed.createComponent(FlightDisplayComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
