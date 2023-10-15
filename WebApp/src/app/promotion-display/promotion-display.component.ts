import { Component, Input} from '@angular/core';

@Component({
  selector: 'app-promotion-display',
  templateUrl: './promotion-display.component.html',
  styleUrls: ['./promotion-display.component.css']
})
export class PromotionDisplayComponent {
  @Input() origin?: string ;
  @Input() destination?: string;
  @Input() price?: number;
  @Input() discount?: number;

  //Variables para determinar el tiempo de vuelo
  @Input() start?: Date; 
  @Input() end?: Date;

}
