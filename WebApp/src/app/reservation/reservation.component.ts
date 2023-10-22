import { Component} from '@angular/core';
import { Router } from '@angular/router';
import { DataService } from '../data.service';
import { billpdf } from '../Interfaces/billpdf.interface';
import { Client } from '../Interfaces/client.interface';

@Component({
  selector: 'app-reservation',
  templateUrl: './reservation.component.html',
  styleUrls: ['./reservation.component.css']
})
export class ReservationComponent{
  student: string = 'no';
  
  constructor(private router: Router, private data:DataService) {}

  client:Client = {//an instance of client
    cedula:0,
    nombre:'',
    apellido_1:'',
    apellido_2:'',
    telefono:'',
    correo:'',
    estudiantes:[],
    usuarios:[],
    maletas:[],
    pases:[],
    tarjetas:[],
    facturas:[],
  };

  ngOnInit(){
    this.client = this.data.client//updates the client with the saved in data
    console.log('Prueba')
    console.log(this.data.client)
  }

  billpdf:billpdf = {//an intance of billpdf
    origen:'',
    destino:'',
    precio:0,
    fecha: 0,
    cedula:'',
    tarjeta:'',
  }

  onSubmit() {
      // Redirigir al usuario a la página de inicio.
      console.log(this.data.client)
      this.data.billpdf.cedula = this.billpdf.cedula;//updates the data bill pdf for cedula
      this.data.client = this.client;//updates the data with the saved in client
      this.router.navigate(['/payment']);

    }
  }
