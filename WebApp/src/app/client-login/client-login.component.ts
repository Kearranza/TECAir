import { Component } from '@angular/core';
import { Router } from '@angular/router';
import { ChargeThingsService } from '../charge-things.service';
import { APIService } from '../api.service';
import { DataService } from '../data.service';
import { Client } from '../Interfaces/client.interface';

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

    constructor(private router: Router, private charge:ChargeThingsService, private apiService:APIService, private data:DataService) {}

  client: Client = {
      cedula: 0,
      nombre: '',
      apellido_1: '',
      apellido_2: '',
      telefono: '',
      correo: '',
      estudiantes: [],
      usuarios: [],
      maletas: [],
      pases: [],
      tarjetas: [],
      facturas: [],
    }

  // Función para el login que se ejecuta al presionar el botón y que valida si el usuario y contraseña son correctos
  onSubmit() {

    this.charge.getUser();

    for (let users of this.charge.user){
      
      if (this.usernameInput && this.passwordInput) {

        if (users.cedula !== this.usernameInput || users.contrasena !== this.passwordInput) {

          this.errorMessage = 'El nombre de usuario o la contraseña son incorrectos.';

        } else {
          this.errorMessage = '';
          this.apiService.getDataECliente(users.cedula).subscribe(data => {
            console.log(this.client)
            this.client = data;
          }, error => {
            console.error('Error:', error);})
          
          this.data.client = this.client;
          console.log('aa')
          console.log(this.data.client)

          // Redirigir al usuario a la página de inicio.
          this.router.navigate(['/client-view']);
        }
      }
    }
    console.log('111')  
  }



}