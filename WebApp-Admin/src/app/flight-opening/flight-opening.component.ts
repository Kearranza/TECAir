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

  calendar:Calendar = {//an instance of calendar
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

  // Function that is executed when the button is pressed and validates the form
  onSubmit() {
    this.apiService.getDataECalendario(this.string).subscribe(data => {//gets the value of calendar
      console.log(data)
      this.calendar = data;
    }, error => {
      console.error('Error:', error);})
    this.calendar.abierto = true ;//changes the abierto state to true 
    console.log(this.calendar);
    this.UpdateC();//update the calendario  
  }

  UpdateC(){//calls the service to save user
    this.apiService.updateDataCalendario(this.string, this.calendar).subscribe(data => {
      console.log(this.calendar)
      console.log('Funca C')
    })
  }
}
