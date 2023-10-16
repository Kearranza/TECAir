import { Component } from '@angular/core';
import { Client } from '../Interfaces/client.interface';
import { APIService } from '../api.service';
import { Student } from '../Interfaces/student.interface';

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

  constructor(private apiService: APIService) {}

  onSubmit() {
    if (this.student == 'yes'){
      console.log(this.students)
      this.PostC();
      this.PostE();
    }else{
      return this.PostC();
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
}
