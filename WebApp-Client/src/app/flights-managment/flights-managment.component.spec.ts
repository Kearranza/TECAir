import { ComponentFixture, TestBed } from '@angular/core/testing';

import { FlightsManagmentComponent } from './flights-managment.component';

describe('FlightsManagmentComponent', () => {
  let component: FlightsManagmentComponent;
  let fixture: ComponentFixture<FlightsManagmentComponent>;

  beforeEach(() => {
    TestBed.configureTestingModule({
      declarations: [FlightsManagmentComponent]
    });
    fixture = TestBed.createComponent(FlightsManagmentComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
