import { Component } from '@angular/core';
import { Calendar } from '../Interfaces/calendar.interface';
import { APIService } from '../api.service';

@Component({
  selector: 'app-flight-closure',
  templateUrl: './flight-closure.component.html',
  styleUrls: ['./flight-closure.component.css']
})
export class FlightClosureComponent {

  string:string = '';

  calendar:Calendar = {
    id_calendario:'',
    fecha: new Date(),
    precio:0,
    id_avion:'',
    id_vuelo:0,
    abierto:false,
    pases:[],
    promociones:[],
    facturas:[],
  }

  constructor(private apiService: APIService) {}

  onSubmit() {
    this.apiService.getDataECalendario(this.string).subscribe(data => {
      this.calendar = data;
    }, error => {
      console.error('Error:', error);})
    this.calendar.abierto = false;
    this.apiService.updateDataCalendario(this.string, this.calendar)  
  }


}
