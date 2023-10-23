import { Component, OnInit, ViewChild, ElementRef } from '@angular/core';
import { ChargeThingsService } from '../charge-things.service';
import { Display_promo } from '../Interfaces/displaypromo.interface';
import { billpdf } from '../Interfaces/billpdf.interface';
import { DataService } from '../data.service';
import { Router } from '@angular/router';

@Component({
  selector: 'app-promotions',
  templateUrl: './promotions.component.html',
  styleUrls: ['./promotions.component.css']
})

export class PromotionsComponent {
  
  
@ViewChild('flightContainer') flightContainer?: ElementRef;

  constructor(private charge:ChargeThingsService,private data:DataService, private router:Router) { }
  flights:Display_promo[] = [];
  
  billpdf:billpdf = {//an intance of billpdf
    origen:'',
    destino:'',
    precio:0,
    fecha: 0,
    cedula:'',
    tarjeta:'',
  }

  date = new Date();

  ngOnInit(): void {
    this.charge.getAirport();
    this.charge.getCalendar();
    this.charge.getSales();
    this.charge.getDisplaypromo();
    this.flights = [...this.charge.displaypromo];
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

  toReserve(string:string, origin:string , destination:string, price:number){
    this.data.setData('calendario', string)
    this.billpdf.origen = origin;
    this.billpdf.destino = destination;
    this.billpdf.precio = price;
    this.billpdf.fecha = this.date.getDate();
    this.data.setData('billpdf', this.billpdf)
    this.router.navigate(['/reservation'])
  }
}