import { ComponentFixture, TestBed } from '@angular/core/testing';

import { DeletePromotionComponent } from './delete-promotion.component';

describe('DeletePromotionComponent', () => {
  let component: DeletePromotionComponent;
  let fixture: ComponentFixture<DeletePromotionComponent>;

  beforeEach(() => {
    TestBed.configureTestingModule({
      declarations: [DeletePromotionComponent]
    });
    fixture = TestBed.createComponent(DeletePromotionComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
