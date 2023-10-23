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
import { SeatPost } from './Interfaces/seatpost.interface';
import { Student } from './Interfaces/student.interface';
import { User } from './Interfaces/user.interface';
import { Display_flight } from './Interfaces/displayflight.interface';
import { Display_promo } from './Interfaces/displaypromo.interface';

@Injectable({
  providedIn: 'root'
})

export class ChargeThingsService {//Makes a service for getting all the data in the database

  //Creates the list necesaries for charging the elements in the data base
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
  seat:SeatPost[] = [];
  student:Student[] = [];
  user:User[] = [];
  display:Display_flight[] = [];
  displaypromo:Display_promo[] = [];

  constructor(private apiService:APIService) { }

  getAirport(){//Charges the elements of airport
    this.apiService.getDataAeropuerto().subscribe(data => {//charges the information in data 
      this.airport = data;//the list gets the charged data
    }, error => {//if there an error it will catch it and show it in console
      console.error('Error:', error);})
  }
  getBaggage(){//Charges the elements of baggage
    this.apiService.getDataMaleta().subscribe(data => {//charges the information in data 
      this.baggage = data;//the list gets the charged data
    }, error => {//if there an error it will catch it and show it in console
      console.error('Error:', error);})
  }
  getBoarding_pass(){//Charges the elements of boarding pass
    this.apiService.getDataPaseA().subscribe(data => {//charges the information in data 
      this.boarding_pass = data;//the list gets the charged data
    }, error => {//if there an error it will catch it and show it in console
      console.error('Error:', error);})
  }
  getCalendar(){//Charges the elements of calendar
    this.apiService.getDataCalendario().subscribe(data => {//charges the information in data 
      this.calendar = data;//the list gets the charged data
    }, error => {//if there an error it will catch it and show it in console
      console.error('Error:', error);})
  }
  getClient(){//Charges the elements of client
    this.apiService.getDataCliente().subscribe(data => {//charges the information in data 
      this.client = data;//the list gets the charged data
    }, error => {//if there an error it will catch it and show it in console
      console.error('Error:', error);})
  }
  getCredit_card(){//Charges the elements of credit card
    this.apiService.getDataTarjeta().subscribe(data => {//charges the information in data 
      this.credit_card = data;//the list gets the charged data
    }, error => {//if there an error it will catch it and show it in console
      console.error('Error:', error);})
  }
  getFlight(){//Charges the elements of flight
    this.apiService.getDataVuelos().subscribe(data => {//charges the information in data 
      this.flight = data;//the list gets the charged data
    }, error => {//if there an error it will catch it and show it in console
      console.error('Error:', error);})
  }
  getPlane(){//Charges the elements of plane
    this.apiService.getDataAvion().subscribe(data => {//charges the information in data 
      this.plane = data;//the list gets the charged data
    }, error => {//if there an error it will catch it and show it in console
      console.error('Error:', error);})
  }
  getScales(){//Charges the elements of scales
    this.apiService.getDataEscala().subscribe(data => {//charges the information in data 
      this.scales = data;//the list gets the charged data
    }, error => {//if there an error it will catch it and show it in console
      console.error('Error:', error);})
  }
  getSales(){//Charges the elements of sales
    this.apiService.getDataPromociones().subscribe(data => {//charges the information in data 
      this.sales = data;//the list gets the charged data
    }, error => {//if there an error it will catch it and show it in console
      console.error('Error:', error);})
  }
  getSeat(){//Charges the elements of seat
    this.apiService.getDataAsiento().subscribe(data => {//charges the information in data 
      this.seat = data;//the list gets the charged data
    }, error => {//if there an error it will catch it and show it in console
      console.error('Error:', error);})
  }
  getStudent(){//Charges the elements of student
    this.apiService.getDataEstudiante().subscribe(data => {//charges the information in data 
      this.student = data;//the list gets the charged data
    }, error => {//if there an error it will catch it and show it in console
      console.error('Error:', error);})
  }
  getUser(){//Charges the elements of user
    this.apiService.getDataUser().subscribe(data => {//charges the information in data 
      this.user = data;//the list gets the charged data
    }, error => {//if there an error it will catch it and show it in console
      console.error('Error:', error);})
  }
  getDisplay(){//Charges the elements necesaries for display flights
    this.apiService.getDataCalendarioV().subscribe(data => {//charges the information in data 
      this.display = data;//the list gets the charged data
    }, error => {//if there an error it will catch it and show it in console
      console.error('Error', error)
    })
  }
  getDisplaypromo(){//Charges the elements necesaries for display promos
    this.apiService.getDataCalendarioP().subscribe(data => {//charges the information in data 
      this.displaypromo = data;
    }, error => {//if there an error it will catch it and show it in console
      console.error('Error', error)
    })
  }
  getBill(){//Charges the elements of bill
    this.apiService.getDataFactura().subscribe(data => {//charges the information in data 
      this.Bill = data;//the list gets the charged data
    }, error => {//if there an error it will catch it and show it in console
      console.error('Error', error)
    })
  }
}
