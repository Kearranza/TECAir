import { Component } from '@angular/core';

@Component({
  selector: 'app-client-register',
  templateUrl: './client-register.component.html',
  styleUrls: ['./client-register.component.css']
})
export class ClientRegisterComponent {
  student: string = 'no';

  onSubmit() {
    // Handle form submission here
  }
}
