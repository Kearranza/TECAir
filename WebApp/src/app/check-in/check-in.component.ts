import { Component } from '@angular/core';
import { Router } from '@angular/router';
import { ChargeThingsService } from '../charge-things.service';

@Component({
  selector: 'app-check-in',
  templateUrl: './check-in.component.html',
  styleUrls: ['./check-in.component.css']
})
export class CheckInComponent {
  constructor(private router: Router, private charge:ChargeThingsService) {}

  onSubmit() {
    this.router.navigate(['/seats-selection']);
  }
}
