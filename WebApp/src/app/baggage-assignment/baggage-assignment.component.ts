import { Component } from '@angular/core';

interface ColorInput {
  id: number;
}

@Component({
  selector: 'app-baggage-assignment',
  templateUrl: './baggage-assignment.component.html',
  styleUrls: ['./baggage-assignment.component.css']
})
export class BaggageAssignmentComponent {

  colors: ColorInput[] = [{ id: 1 }];
  
  repeatCount = 1;

  addColorInput() {
    if (this.colors.length < 3) {
      const newColorInput: ColorInput = { id: this.colors.length + 1 };
      this.colors.push(newColorInput);
    }
  }

  repeatCode(num : number) {
    this.repeatCount += num;
  }

  onSubmit(){}

}
