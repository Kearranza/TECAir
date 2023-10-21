import { Component, OnInit, ViewChild, ElementRef } from '@angular/core';
import { ChargeThingsService } from '../charge-things.service';

@Component({
  selector: 'app-flights',
  templateUrl: './flights.component.html',
  styleUrls: ['./flights.component.css']
})
export class FlightsComponent implements OnInit {
  
  @ViewChild('flightContainer') flightContainer?: ElementRef;
  
  constructor(private charge:ChargeThingsService) { }

  origins:string[] = [];
  destinations:string[] = [];
  selectedOrigin = '';
  selectedDestination = '';

  ngOnInit(): void {
    this.charge.getAirport();
    this.charge.getCalendar();
    this.charge.getDisplay();
    for(let item of this.charge.airport){
      this.origins.push(item.id_aereo);
    };
    this.destinations = this.origins;
  }

  filteredFlights = this.charge.display;


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

  filterFlights() {
    if (this.selectedOrigin === '' && this.selectedDestination === '') {
      this.filteredFlights = this.charge.display;
    } else {
      this.filteredFlights = this.charge.display.filter(flight => {
        return (this.selectedOrigin === '' || flight.origin === this.selectedOrigin) && (this.selectedDestination === '' || flight.destination === this.selectedDestination);
      });
    }
  }

  ngOnChanges() {
    this.filterFlights();
  }
}
