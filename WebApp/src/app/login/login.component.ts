import { Component } from '@angular/core';
import { Router } from '@angular/router';

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

  constructor(private router: Router) {}

  // Función para el login que se ejecuta al presionar el botón y que valida si el usuario y contraseña son correctos
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

        // Redirigir al usuario a la página de inicio.
        this.router.navigate(['/app']);
      }
    }
  }

}
