import { Component, OnInit, ViewChild, ElementRef } from '@angular/core';

@Component({
  selector: 'app-promotions',
  templateUrl: './promotions.component.html',
  styleUrls: ['./promotions.component.css']
})
export class PromotionsComponent implements OnInit {
  
@ViewChild('flightContainer') flightContainer?: ElementRef;
  realDiscount = 0.4;
  flights = [
    { origin: 'New York', destination: 'Los Angeles', price: 300, discount: this.realDiscount*100 },
    { origin: 'Chicago', destination: 'Miami', price: 250, discount: this.realDiscount*100 },
    { origin: 'Houston', destination: 'Denver', price: 200, discount: this.realDiscount*100 },
    { origin: 'Boston', destination: 'Washington D.C.', price: 100, discount: this.realDiscount*100 },
    { origin: 'Las Vegas', destination: 'Phoenix', price: 75 , discount: this.realDiscount*100},
  ];

  constructor() { }

  ngOnInit(): void {
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