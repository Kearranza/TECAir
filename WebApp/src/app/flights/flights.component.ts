import { Component, OnInit, ViewChild, ElementRef } from '@angular/core';

@Component({
  selector: 'app-flights',
  templateUrl: './flights.component.html',
  styleUrls: ['./flights.component.css']
})
export class FlightsComponent implements OnInit {
  @ViewChild('flightContainer') flightContainer?: ElementRef;

  flights = [
    { origin: 'New York', destination: 'Los Angeles', price: '$300-10%' },
    { origin: 'Chicago', destination: 'Miami', price: '$250-15%' },
    { origin: 'Houston', destination: 'Denver', price: '$200-5%' },
    { origin: 'Boston', destination: 'Washington D.C.', price: '$100-25%' },
    { origin: 'Las Vegas', destination: 'Phoenix', price: '$75-30%' }
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