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

  baggage:BaggagePost = {//an instance of bagagge post
    cedula_cliente: 0,
    peso:0,
    id_pasaje:0,
    color:'negras',
  }

  colors: ColorInput[] = [{ id: 1 }];

  //Add extra colors input fields to the form
  addColorInput() {
    if (this.colors.length < 3) {
      const newColorInput: ColorInput = { id: this.colors.length + 1 };
      this.colors.push(newColorInput);
    }
  }

  // Function that is executed when the button is pressed and validates the form
  onSubmit(){
    this.charge.getBoarding_pass();//charges the boarding pass
    if(this.charge.boarding_pass.some(item => item.cedula_cliente === this.baggage.cedula_cliente && this.charge.boarding_pass.some(item => item.id_pasaje == this.baggage.id_pasaje)))
    {//checks if the cedula has a bording pass
        this.PostB();// if the cedula has a boarding pass saves a baggage
    }else {
      console.log(this.charge.airport)
    }
  }

  PostB(){//Calls the post method from the service
    this.apiService.postDataMaleta(this.baggage).subscribe(data => {
      console.log(this.baggage)
      console.log('Funca B')
    })
  }

  //Let the admin add more baggages to the form
  repeatCode(num : number) {
    this.repeatCount += num;
  }
}
