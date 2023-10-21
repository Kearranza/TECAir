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
  
  constructor(private router: Router, private data:DataService) {}

  billpdf:billpdf = {
    origen:'',
    destino:'',
    precio:'',
    fecha: new Date(),
    cedula:'',
    tarjeta:'',
  }
  client:Client = {
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
  }

  onSubmit() {
      // Redirigir al usuario a la página de inicio.
      this.data.billpdf.cedula = this.billpdf.cedula;
      this.data.client = this.client;
      this.router.navigate(['/payment']);

    }
  }
