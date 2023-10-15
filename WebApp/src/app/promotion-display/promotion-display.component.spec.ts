import { ComponentFixture, TestBed } from '@angular/core/testing';

import { PromotionDisplayComponent } from './promotion-display.component';

describe('PromotionDisplayComponent', () => {
  let component: PromotionDisplayComponent;
  let fixture: ComponentFixture<PromotionDisplayComponent>;

  beforeEach(() => {
    TestBed.configureTestingModule({
      declarations: [PromotionDisplayComponent]
    });
    fixture = TestBed.createComponent(PromotionDisplayComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
