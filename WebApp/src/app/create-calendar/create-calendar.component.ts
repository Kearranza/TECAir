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

  constructor(private apiService: APIService, private charge:ChargeThingsService) { this.onInit();}

  onInit(){
    this.charge.getPlane();
    this.charge.getFlight();
  }
  
  onSubmit(){
    
    if(this.charge.plane.some(item => item.placa === this.calendar.id_avion && this.charge.flight.some(item => item.id_vuelo == this.calendar.id_vuelo)))
    {
        this.PostC();
    }

  }

  PostC(){
    this.apiService.postDataCalendario(this.calendar).subscribe(data => {
      console.log(this.calendar)
      console.log('Funca C')
    })
  }

}
