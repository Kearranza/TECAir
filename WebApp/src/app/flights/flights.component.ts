import { Component, OnInit, ViewChild, ElementRef } from '@angular/core';

@Component({
  selector: 'app-flights',
  templateUrl: './flights.component.html',
  styleUrls: ['./flights.component.css']
})
export class FlightsComponent implements OnInit {
  
  @ViewChild('flightContainer') flightContainer?: ElementRef;
  flights = [
    { origin: 'New York', destination: 'Los Angeles', price: 300 },
    { origin: 'Chicago', destination: 'Miami', price: 250 },
    { origin: 'Houston', destination: 'Denver', price: 200},
    { origin: 'Boston', destination: 'Washington D.C.', price: 100},
    { origin: 'Las Vegas', destination: 'Phoenix', price: 75 },
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
