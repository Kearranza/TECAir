import { Component } from '@angular/core';
import { Router } from '@angular/router';
import { ChargeThingsService } from '../charge-things.service';
import { Boarding_pass } from '../Interfaces/boarding_pass.interface';
import { APIService } from '../api.service';
import { DataService } from '../data.service';
import { Calendar } from '../Interfaces/calendar.interface';
import { Flight } from '../Interfaces/flight.interface';

@Component({
  selector: 'app-check-in',
  templateUrl: './check-in.component.html',
  styleUrls: ['./check-in.component.css']
})
export class CheckInComponent {

  constructor(private router: Router, private charge:ChargeThingsService, private apiService:APIService, private data:DataService) {}

  boarding_pass:Boarding_pass = {
    id_pasaje:0,
    puerta: '',
    asiento: '',
    hora_salida:new Date(),
    cedula_cliente:0,
    id_calendario:'',
  }
  calendar:Calendar = {
    id_calendario: '',
    fecha:new Date(),
    precio:0,
    id_avion: '',
    id_vuelo: 0,
    abierto: false,
    pases: [],
    promociones: [],
    facturas: [],
  }

  flight:Flight ={
    id_vuelo:0,
    hora_salida: new Date(),
    aereo_origen:'',
    aereo_final:'',
    calendarios: [],
    escalas: [],
  }

  // Function for login that is executed when the button is pressed and validates the form
  onSubmit() {
    this.charge.getBill()
    if(this.charge.Bill.some(item => item.cliente === this.boarding_pass.cedula_cliente && this.charge.Bill.some(item => item.calendario == this.boarding_pass.id_calendario)))
    {
      this.apiService.getDataECalendario(this.boarding_pass.id_calendario).subscribe(data => {
        this.calendar = data;
      }, error => {
        console.error('Error:', error);})
      if(this.calendar.abierto){
        this.data.boarding_pass = this.boarding_pass;
        this.apiService.getDataEVuelos(this.calendar.id_vuelo).subscribe(data => {
          this.flight = data;
        }, error => {
          console.error('Error:', error);})
        this.data.boarding_pass.hora_salida = this.flight.hora_salida
      }

    }else {
    }
    this.router.navigate(['/seats-selection']);
  }
}
