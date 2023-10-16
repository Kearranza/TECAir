import { Component } from '@angular/core';
import { Router } from '@angular/router';
import { ChargeThingsService } from '../charge-things.service';

@Component({
  selector: 'app-client-login',
  templateUrl: './client-login.component.html',
  styleUrls: ['./client-login.component.css']
})
export class ClientLoginComponent {
    // Variables para el login
    errorMessage: string = '';
    usernameInput:number = 0;
    passwordInput:string = '';

    constructor(private router: Router, private charge:ChargeThingsService) {}

  // Función para el login que se ejecuta al presionar el botón y que valida si el usuario y contraseña son correctos
  onSubmit() {

    this.charge.getUser();

    for (let users of this.charge.user){
      console.log(users);
      
      if (this.usernameInput && this.passwordInput) {

        if (users.id_usuario !== this.usernameInput || users.contrasena !== this.passwordInput) {

          this.errorMessage = 'El nombre de usuario o la contraseña son incorrectos.';

        } else {

          this.errorMessage = '';

          // Redirigir al usuario a la página de inicio.
          this.router.navigate(['/admin-selector']);
        }
      }
    }   
  }



}
