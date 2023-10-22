import { Component } from '@angular/core';
import { APIService } from '../api.service';
import { ChargeThingsService } from '../charge-things.service';
import { BaggagePost } from '../Interfaces/baggagepost.interface';

interface ColorInput {
  id: number;
}

@Component({
  selector: 'app-baggage-assignment',
  templateUrl: './baggage-assignment.component.html',
  styleUrls: ['./baggage-assignment.component.css']
})

export class BaggageAssignmentComponent {
  repeatCount = 1;

  constructor(private apiService:APIService, private charge:ChargeThingsService){}

  baggage:BaggagePost = {
    cedula_cliente: 0,
    peso:0,
    id_pasaje:0,
    color:'',
  }

  colors: ColorInput[] = [{ id: 1 }];

  addColorInput() {
    if (this.colors.length < 3) {
      const newColorInput: ColorInput = { id: this.colors.length + 1 };
      this.colors.push(newColorInput);
    }
  }

  onSubmit(){
    this.charge.getBoarding_pass();
    if(this.charge.boarding_pass.some(item => item.cedula_cliente === this.baggage.cedula_cliente && this.charge.boarding_pass.some(item => item.id_pasaje == this.baggage.id_pasaje)))
    {
        this.PostB();
    }else {
      console.log(this.charge.airport)
    }
  }

  PostB(){
    this.apiService.postDataMaleta(this.baggage).subscribe(data => {
      console.log(this.baggage)
      console.log('Funca B')
    })
  }

  repeatCode(num : number) {
    this.repeatCount += num;
  }
}