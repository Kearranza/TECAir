import { ComponentFixture, TestBed } from '@angular/core/testing';

import { BaggageAssignmentComponent } from './baggage-assignment.component';

describe('BaggageAssignmentComponent', () => {
  let component: BaggageAssignmentComponent;
  let fixture: ComponentFixture<BaggageAssignmentComponent>;

  beforeEach(() => {
    TestBed.configureTestingModule({
      declarations: [BaggageAssignmentComponent]
    });
    fixture = TestBed.createComponent(BaggageAssignmentComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
