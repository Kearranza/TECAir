import { Component, OnInit, ViewChild, ElementRef } from '@angular/core';
import { ChargeThingsService } from '../charge-things.service';
import { DataService } from '../data.service';
import { Router } from '@angular/router';
import { Display_flight } from '../Interfaces/displayflight.interface';
import { billpdf } from '../Interfaces/billpdf.interface';

interface Flight {
  id_calendario: string;
  origin: string;
  destination: string;
  price: number;  
}

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
  flight:Flight [] = [];
  filteredFlights:Flight [] = [];

  billpdf:billpdf = {//an intance of billpdf
    origen:'',
    destino:'',
    precio:0,
    fecha: 0,
    cedula:'',
    tarjeta:'',
  }

  ngOnInit(): void {
    this.charge.getAirport();
    this.charge.getCalendar();
    this.charge.getDisplay();
    for(let item of this.charge.airport){
      this.origins.push(item.id_aereo);
    };
    this.destinations = this.origins;
    this.flight = this.charge.display;
    this.filteredFlights = this.flight;
    console.log(this.flight)
    console.log(this.data.client)
  }

  // Function that move the carousel of flights to the left
  moveLeft() {
    const container = this.flightContainer?.nativeElement;
    const scrollLeft = container.scrollLeft;
    const itemWidth = container.offsetWidth / 3;
    container.scrollTo({
      left: scrollLeft - itemWidth,
      behavior: 'smooth'
    });
  }

  // Function that moves the carousel of flights to the right
  moveRight() {
    const container = this.flightContainer?.nativeElement;
    const scrollLeft = container.scrollLeft;
    const itemWidth = container.offsetWidth / 3;
    container.scrollTo({
      left: scrollLeft + itemWidth,
      behavior: 'smooth'
    });
  }

  // Function that change the value of the list filterFlights when the user select a new origin or destination
  filterFlights() {
    if (this.selectedOrigin === '' && this.selectedDestination === '') {
      this.filteredFlights = this.charge.display;
    } else {
      this.filteredFlights = this.charge.display.filter(flight => {
        return (this.selectedOrigin === '' || flight.origin === this.selectedOrigin) && (this.selectedDestination === '' || flight.destination === this.selectedDestination);
      });
    }
  }

  // Function that is executed when the button is pressed and validates the form
  toReserve(string:string, origin:string , destination:string, price:number){
    this.data.setData('calendario','Uno')
    this.billpdf.origen = origin;
    this.billpdf.destino = destination;
    this.billpdf.precio = price;
    this.billpdf.fecha = this.date.getDate();
    this.data.setData('billpdf', this.billpdf)
    this.router.navigate(['/reservation'])
  }

  // Fuction refresh the list of flights when the user select a new origin or destination
  ngOnChanges() {
    this.filterFlights();
  }
}
