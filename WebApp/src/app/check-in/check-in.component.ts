import { Component } from '@angular/core';
import { Router } from '@angular/router';
import { ChargeThingsService } from '../charge-things.service';
import { Boarding_pass } from '../Interfaces/boarding_pass.interface';
import { APIService } from '../api.service';

@Component({
  selector: 'app-check-in',
  templateUrl: './check-in.component.html',
  styleUrls: ['./check-in.component.css']
})
export class CheckInComponent {

  constructor(private router: Router, private charge:ChargeThingsService, private apiService:APIService) {}

  boarding_pass:Boarding_pass = {
    id_pasaje:0,
    puerta: '',
    asiento: '',
    hora_salida:new Date(),
    cedula_cliente:0,
    id_calendario:'',
  }

  onSubmit() {
    this.router.navigate(['/seats-selection']);
  }
}
