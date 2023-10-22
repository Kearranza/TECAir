import { Component } from '@angular/core';
import { Router } from '@angular/router';
import { ChargeThingsService } from '../charge-things.service';
import { Airport } from '../Interfaces/airport.interface';
import { APIService } from '../api.service';

// Componente para el login de la aplicación, encargado de validar el usuario y contraseña ingresados por el usuario.

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})
export class LoginComponent {
  // Variables para el login
  username: string = 'admin';
  password: string = 'admin';
  errorMessage: string = '';

  constructor(private router: Router, private charge:ChargeThingsService) {}

  // Function that is executed when the button is pressed and validates the form
  onSubmit() {

    const usernameInput = document.getElementById('username') as HTMLInputElement;
    const passwordInput = document.getElementById('password') as HTMLInputElement;

    if (usernameInput && passwordInput) {

      if (this.username !== usernameInput.value || this.password !== passwordInput.value) {

        this.errorMessage = 'El nombre de usuario o la contraseña son incorrectos.';
        usernameInput.style.borderColor = 'red';
        passwordInput.style.borderColor = 'red';

      } else {

        this.errorMessage = '';
        usernameInput.style.borderColor = '';
        passwordInput.style.borderColor = '';

        // Redirect the user to the admid selector.
        this.router.navigate(['/admin-selector']);
      }
    }   
  }

}
