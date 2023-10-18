import { Component, OnInit, ViewChild, ElementRef } from '@angular/core';
import { ChargeThingsService } from '../charge-things.service';

@Component({
  selector: 'app-promotions',
  templateUrl: './promotions.component.html',
  styleUrls: ['./promotions.component.css']
})
export class PromotionsComponent implements OnInit {
  
@ViewChild('flightContainer') flightContainer?: ElementRef;
  realDiscount = 0.4;

  constructor(private charge:ChargeThingsService) { }

  flights = this.charge.displaypromo;

  ngOnInit(): void {
    this.charge.getAirport();
    this.charge.getCalendar();
    this.charge.getSales();
    this.charge.getDisplaypromo();
  }

  moveLeft() {
    const container = this.flightContainer?.nativeElement;
    const scrollLeft = container.scrollLeft;
    const itemWidth = container.offsetWidth / 3;
    container.scrollTo({
      left: scrollLeft - itemWidth,
      behavior: 'smooth'
    });
  }

  moveRight() {
    const container = this.flightContainer?.nativeElement;
    const scrollLeft = container.scrollLeft;
    const itemWidth = container.offsetWidth / 3;
    container.scrollTo({
      left: scrollLeft + itemWidth,
      behavior: 'smooth'
    });
  }
}