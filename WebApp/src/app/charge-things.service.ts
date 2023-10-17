import { Injectable } from '@angular/core';
import { APIService } from './api.service';
import { Airport } from './Interfaces/airport.interface';
import { Baggage } from './Interfaces/baggage.interface';
import { Bill } from './Interfaces/bill.interface';
import { Boarding_pass } from './Interfaces/boarding_pass.interface';
import { Calendar } from './Interfaces/calendar.interface';
import { Client } from './Interfaces/client.interface';
import { Credit_card } from './Interfaces/credit_card.interface';
import { Flight } from './Interfaces/flight.interface';
import { Plane } from './Interfaces/plane.interface';
import { Sales } from './Interfaces/sales.interface';
import { Scales } from './Interfaces/scales.interface';
import { Seat } from './Interfaces/seat.interface';
import { Student } from './Interfaces/student.interface';
import { User } from './Interfaces/user.interface';
import { DisplayFlight } from './Interfaces/displayflight.interface';

@Injectable({
  providedIn: 'root'
})

export class ChargeThingsService {

  airport:Airport[] = [];
  baggage:Baggage[] = [];
  Bill:Bill[] = []
  boarding_pass:Boarding_pass[] = [];
  calendar:Calendar[] = [];
  client:Client[] = [];
  credit_card:Credit_card[] = [];
  flight:Flight[] = [];
  plane:Plane[] = [];
  scales:Scales[] = [];
  sales:Sales[] = [];
  seat:Seat[] = [];
  student:Student[] = [];
  user:User[] = [];
  display:DisplayFlight[] = [];
  temp:DisplayFlight = {
    origin:'',
    destination:'',
    price:0,
  }

  constructor(private apiService:APIService) { }

  getAirport(){
    this.apiService.getDataAeropuerto().subscribe(data => {
      this.airport = data;
    }, error => {
      console.error('Error:', error);})
  }
  getBaggage(){
    this.apiService.getDataMaleta().subscribe(data => {
      this.baggage = data;
    }, error => {
      console.error('Error:', error);})
  }
  getBoarding_pass(){
    this.apiService.getDataPaseA().subscribe(data => {
      this.boarding_pass = data;
    }, error => {
      console.error('Error:', error);})
  }
  getCalendar(){
    this.apiService.getDataCalendario().subscribe(data => {
      this.calendar = data;
    }, error => {
      console.error('Error:', error);})
  }
  getClient(){
    this.apiService.getDataCliente().subscribe(data => {
      this.client = data;
    }, error => {
      console.error('Error:', error);})
  }
  getCredit_card(){
    this.apiService.getDataTarjeta().subscribe(data => {
      this.credit_card = data;
    }, error => {
      console.error('Error:', error);})
  }
  getFlight(){
    this.apiService.getDataVuelos().subscribe(data => {
      this.flight = data;
    }, error => {
      console.error('Error:', error);})
  }
  getPlane(){
    this.apiService.getDataAvion().subscribe(data => {
      this.plane = data;
    }, error => {
      console.error('Error:', error);})
  }
  getScales(){
    this.apiService.getDataEscala().subscribe(data => {
      this.scales = data;
    }, error => {
      console.error('Error:', error);})
  }
  getSales(){
    this.apiService.getDataPromociones().subscribe(data => {
      this.sales = data;
    }, error => {
      console.error('Error:', error);})
  }
  getSeat(){
    this.apiService.getDataAsiento().subscribe(data => {
      this.seat = data;
    }, error => {
      console.error('Error:', error);})
  }
  getStudent(){
    this.apiService.getDataEstudiante().subscribe(data => {
      this.student = data;
    }, error => {
      console.error('Error:', error);})
  }
  getUser(){
    this.apiService.getDataUser().subscribe(data => {
      this.user = data;
    }, error => {
      console.error('Error:', error);})
  }
  getDisplay(){
    let map = new Map();
    for (let item of this.calendar) {
  map.set(item.id_vuelo, item);
    }
    for (let item of this.flight) {
      if (map.has(item.id_vuelo)) { // replace with your condition
          this.temp.origin = item.aereo_origen,
          this.temp.destination = item.aereo_final,
          this.temp.price = map.get(item.id_vuelo).precio
        this.display.push(this.temp);
      }
    }
  }
}
