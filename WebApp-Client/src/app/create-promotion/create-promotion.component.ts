import { Component } from '@angular/core';
import { APIService } from '../api.service';
import { ChargeThingsService } from '../charge-things.service';
import { Sales } from '../Interfaces/sales.interface';

@Component({
  selector: 'app-create-promotion',
  templateUrl: './create-promotion.component.html',
  styleUrls: ['./create-promotion.component.css']
})
export class CreatePromotionComponent {

  sale:Sales ={//an instance of sales
    id_promo:0,
    descuento:0,
    fecha_inicio: new Date(),
    fecha_fin: new Date(),
    origen:'',
    destino:'',
    aplicado_calendario:'',
  }

  constructor(private apiService: APIService, private charge:ChargeThingsService) { this.onInit();}

  onInit(){
    this.charge.getAirport();//charges airport
    this.charge.getCalendar();//charges calendar
  }

  // Function that is executed when the button is pressed and validates the form
  onSubmit(){
    if(this.charge.airport.some(item => item.id_aereo == this.sale.origen && this.charge.airport.some(item => item.id_aereo == this.sale.destino)) && this.charge.calendar.some(thisc => thisc.id_calendario == this.sale.aplicado_calendario))
    {// if the calendar, origen and destino exist saves the promo 
        this.PostS();
    }
  }

  PostS(){//calls the service to save promos
    this.apiService.postDataPromociones(this.sale).subscribe(data => {
      console.log(this.sale)
      console.log('Funca S')
    })
  }
}
