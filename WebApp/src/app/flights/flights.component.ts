import { Component, OnInit, ViewChild, ElementRef } from '@angular/core';
import { ChargeThingsService } from '../charge-things.service';
import { DataService } from '../data.service';
import { Router } from '@angular/router';
import { Display_flight } from '../Interfaces/displayflight.interface';

@Component({
  selector: 'app-flights',
  templateUrl: './flights.component.html',
  styleUrls: ['./flights.component.css']
})
export class FlightsComponent{
  
  @ViewChild('flightContainer') flightContainer?: ElementRef;
  
  constructor(private charge:ChargeThingsService, private data:DataService, private router:Router) { }

  origins:string[] = [];
  destinations:string[] = [];
  selectedOrigin = '';
  selectedDestination = '';
  date = new Date();
  flight:Display_flight[] = [];

  ngOnInit(): void {
    this.charge.getAirport();
    this.charge.getCalendar();
    this.charge.getDisplay();
    for(let item of this.charge.airport){
      this.origins.push(item.id_aereo);
    };
    this.destinations = this.origins;
    this.flight = this.charge.display;
  }
  filteredFlights = this.flight;

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

  toReserve(string:string, origin:string , destination:string, price:number){
    this.data.calendar.id_calendario = string;
    this.data.billpdf.origen = origin;
    this.data.billpdf.destino = destination;
    this.data.billpdf.precio = price;
    this.data.billpdf.fecha = this.date.getDate();
    this.router.navigate(['/reservation'])
  }

  ngOnChanges() {
    this.filterFlights();
  }
}
