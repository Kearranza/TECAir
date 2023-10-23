import { Component, Input} from '@angular/core';

@Component({
  selector: 'app-flight-display',
  templateUrl: './flight-display.component.html',
  styleUrls: ['./flight-display.component.css']
})
export class FlightDisplayComponent {
  @Input() origin?: string ;
  @Input() destination?: string;
  @Input() price?: number;
  @Input() discount?: number;
  @Input() calendar_id?: string;

  //Variables the time of the flight is displayed
  @Input() start?: Date; 
  @Input() end?: Date;

}
