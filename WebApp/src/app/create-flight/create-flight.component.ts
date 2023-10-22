import { Component } from '@angular/core';
import { Flight } from '../Interfaces/flight.interface';
import { APIService } from '../api.service';
import { ChargeThingsService } from '../charge-things.service';
@Component({
  selector: 'app-create-flight',
  templateUrl: './create-flight.component.html',
  styleUrls: ['./create-flight.component.css']
})
export class CreateFlightComponent {

  flight:Flight ={
    id_vuelo:0,
    hora_salida: new Date(),
    aereo_origen:'',
    aereo_final:'',
    calendarios: [],
    escalas: [],
  }

  constructor(private apiService: APIService, private charge:ChargeThingsService) { this.onInit();}

  onInit(){
    this.charge.getAirport();
  }

  // Function that is executed when the button is pressed and validates the form
  onSubmit() {
    if(this.charge.airport.some(item => item.id_aereo === this.flight.aereo_origen && this.charge.airport.some(item => item.id_aereo == this.flight.aereo_final)))
    {
        this.PostF();
    }else {
      console.log(this.charge.airport)
    }
  }

  PostF(){
    this.apiService.postDataVuelos(this.flight).subscribe(data => {
      console.log(this.flight)
      console.log('Funca F')
    })
  }
}
