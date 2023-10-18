import { Component} from '@angular/core';
import { Router } from '@angular/router';
import { ChargeThingsService } from '../charge-things.service';

@Component({
  selector: 'app-reservation',
  templateUrl: './reservation.component.html',
  styleUrls: ['./reservation.component.css']
})
export class ReservationComponent{
  constructor(private router: Router, private charge:ChargeThingsService) {}

  onSubmit() {
      // Redirigir al usuario a la página de inicio.
      this.router.navigate(['/payment']);
    }
  }
