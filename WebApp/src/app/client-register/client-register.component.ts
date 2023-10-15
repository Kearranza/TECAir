import { Component } from '@angular/core';
import { Client } from '../Interfaces/client.interface';
import { APIService } from '../api.service';

@Component({
  selector: 'app-client-register',
  templateUrl: './client-register.component.html',
  styleUrls: ['./client-register.component.css']
})
export class ClientRegisterComponent {
  student: string = 'no';

  client1:Client = {
    cedula: '123',
    nombre: 'Santiago',
    apellido_1: 'Acuna',
    apellido_2: 'Araya',
    telefono: '321',
    correo: '1@gmail.com',
    estudiantes: [],
    usuarios: [],
    maletas: [],
    pases: [],
    tarjetas: []
  }

  constructor(private apiService: APIService) {}

  onSubmit() {
    // Handle form submission here;
    //console.log(this.client);
    this.PostC();
  }

  PostC(){
    this.apiService.postDataCliente(this.client1).subscribe(data => {
      console.log(this.client1)
      console.log('Funca')
    })
  }
}
