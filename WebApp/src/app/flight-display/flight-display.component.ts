import { Component, Input} from '@angular/core';

@Component({
  selector: 'app-flight-display',
  templateUrl: './flight-display.component.html',
  styleUrls: ['./flight-display.component.css']
})
export class FlightDisplayComponent {
  @Input() origin?: string ;
  @Input() destination?: string;
  @Input() price?: string;

}
