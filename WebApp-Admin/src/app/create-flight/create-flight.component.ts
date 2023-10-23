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

  flight:Flight ={//an instance of flight 
    id_vuelo:0,
    hora_salida: new Date(),
    aereo_origen:'',
    aereo_final:'',
    calendarios: [],
    escalas: [],
  }

  constructor(private apiService: APIService, private charge:ChargeThingsService) { this.onInit();}

  onInit(){
    this.charge.getAirport();//charges the airport
  }

  // Function that is executed when the button is pressed and validates the form
  onSubmit() {
    if(this.charge.airport.some(item => item.id_aereo === this.flight.aereo_origen && this.charge.airport.some(item => item.id_aereo == this.flight.aereo_final)))
    {//if the aereo origen and aereo final exists in the data base saves ta flight 
        this.PostF();
    }else {
      console.log(this.charge.airport)
    }
  }

  PostF(){//calls the service to save flight
    this.apiService.postDataVuelos(this.flight).subscribe(data => {
      console.log(this.flight)
      console.log('Funca F')
    })
  }
}
