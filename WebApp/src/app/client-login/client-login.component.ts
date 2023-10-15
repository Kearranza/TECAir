import { Component } from '@angular/core';
import { Router } from '@angular/router';
import { ChargeThingsService } from '../charge-things.service';
import { Client } from '../Interfaces/client.interface';

@Component({
  selector: 'app-client-login',
  templateUrl: './client-login.component.html',
  styleUrls: ['./client-login.component.css']
})
export class ClientLoginComponent {
    // Variables para el login
    username: string = 'admin';
    password: string = 'admin';
    errorMessage: string = '';

    constructor(private router: Router, private charge:ChargeThingsService) {}

  // Función para el login que se ejecuta al presionar el botón y que valida si el usuario y contraseña son correctos
  onSubmit() {

    const usernameInput = document.getElementById('username') as HTMLInputElement;
    const passwordInput = document.getElementById('password') as HTMLInputElement;

    this.charge.getClient();

    for (let clients of this.charge.client){
      if (usernameInput && passwordInput) {

        if (clients.correo !== usernameInput.value || clients.apellido_1 !== passwordInput.value) {

          this.errorMessage = 'El nombre de usuario o la contraseña son incorrectos.';
          usernameInput.style.borderColor = 'red';
          passwordInput.style.borderColor = 'red';

        } else {

          this.errorMessage = '';
          usernameInput.style.borderColor = '';
          passwordInput.style.borderColor = '';

          // Redirigir al usuario a la página de inicio.
          this.router.navigate(['/admin-selector']);
        }
      }
    }   
  }



}
