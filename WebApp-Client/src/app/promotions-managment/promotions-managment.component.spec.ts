import { ComponentFixture, TestBed } from '@angular/core/testing';

import { PromotionsManagmentComponent } from './promotions-managment.component';

describe('PromotionsManagmentComponent', () => {
  let component: PromotionsManagmentComponent;
  let fixture: ComponentFixture<PromotionsManagmentComponent>;

  beforeEach(() => {
    TestBed.configureTestingModule({
      declarations: [PromotionsManagmentComponent]
    });
    fixture = TestBed.createComponent(PromotionsManagmentComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
