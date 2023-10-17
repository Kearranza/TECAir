import { Component } from '@angular/core';
import { Client } from '../Interfaces/client.interface';
import { APIService } from '../api.service';
import { Student } from '../Interfaces/student.interface';
import { Userpost } from '../Interfaces/userpost.interface';

@Component({
  selector: 'app-client-register',
  templateUrl: './client-register.component.html',
  styleUrls: ['./client-register.component.css']
})
export class ClientRegisterComponent {
  student: string = 'no';

  client:Client = {
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
    tarjetas: []
  }

  students:Student = {
    carnet: 0,
    universidad: '',
    millas: 100,
    cedula: 0
  };

  userpost: Userpost = {
    contrasena: '',
    cedula: 0
  }

  constructor(private apiService: APIService) {}

  onSubmit() {
    if (this.student == 'yes'){
      this.PostC();
      this.PostU();
      this.PostE();
    }else{
      this.PostC();
      this.PostU();
    }
  }

  PostC(){
    this.apiService.postDataCliente(this.client).subscribe(data => {
      console.log(this.client)
      console.log('Funca C')
    })
  }
  PostE(){
    this.apiService.postDataEstudiante(this.students).subscribe(data => {
      console.log(this.students)
      console.log('Funca E')
    })
  }
  PostU(){
    this.apiService.postDataUser(this.userpost).subscribe(data => {
      console.log(this.userpost)
      console.log('Funca U')
    })
  }
}
