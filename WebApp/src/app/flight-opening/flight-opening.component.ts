import { Component } from '@angular/core';
import { APIService } from '../api.service';
import { Calendar } from '../Interfaces/calendar.interface';

@Component({
  selector: 'app-flight-opening',
  templateUrl: './flight-opening.component.html',
  styleUrls: ['./flight-opening.component.css']
})
export class FlightOpeningComponent {

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
    this.calendar.abierto = true;
    this.apiService.updateDataCalendario(this.string, this.calendar)  
  }
}
