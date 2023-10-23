import { Component } from '@angular/core';
import { APIService } from '../api.service';
import { ChargeThingsService } from '../charge-things.service';
import { Calendar } from '../Interfaces/calendar.interface';

@Component({
  selector: 'app-create-calendar',
  templateUrl: './create-calendar.component.html',
  styleUrls: ['./create-calendar.component.css']
})
export class CreateCalendarComponent {

  calendar:Calendar = {//an intance of calendar
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

  constructor(private apiService: APIService, private charge:ChargeThingsService) { this.onInit();}

  onInit(){
    this.charge.getPlane();//charges planes 
    this.charge.getFlight();//charges airport 
  }
  
  // Function that is executed when the button is pressed and validates the form
  onSubmit(){
    
    if(this.charge.plane.some(item => item.placa === this.calendar.id_avion && this.charge.flight.some(item => item.id_vuelo == this.calendar.id_vuelo)))
    {// if placa and id vuelo exist in the database saves the calendar
        this.PostC();
    }

  }

  PostC(){//calls the service to save calendar
    this.apiService.postDataCalendario(this.calendar).subscribe(data => {
      console.log(this.calendar)
      console.log('Funca C')
    })
  }

}
