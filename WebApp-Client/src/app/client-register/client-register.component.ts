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

  client:Client = {//an intance of client
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

  students:Student = {//an intance of student
    carnet: 0,
    universidad: '',
    millas: 100,
    cedula: 0
  };

  userpost: Userpost = {//an intance of userpost
    contrasena: '',
    cedula: 0
  }

  constructor(private apiService: APIService) {}

  // Function that is executed when the button is pressed and validates the form
  onSubmit() {
    if (this.student == 'yes'){//checks if the user is true to save student
      this.PostC();
      this.PostU();
      this.PostE();
    }else{
      this.PostC();
      this.PostU();
    }
  }

  PostC(){//calls the service to save client
    this.apiService.postDataCliente(this.client).subscribe(data => {
      console.log(this.client)
      console.log('Funca C')
    })
  }
  PostE(){//calls the service to save student
    this.apiService.postDataEstudiante(this.students).subscribe(data => {
      console.log(this.students)
      console.log('Funca E')
    })
  }
  PostU(){//calls the service to save user
    this.apiService.postDataUser(this.userpost).subscribe(data => {
      console.log(this.userpost)
      console.log('Funca U')
    })
  }
}
