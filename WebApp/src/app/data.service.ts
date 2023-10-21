import { Injectable } from '@angular/core';
import { billpdf } from './Interfaces/billpdf.interface';
import { Calendar } from './Interfaces/calendar.interface';
import { Client } from './Interfaces/client.interface';

@Injectable({
  providedIn: 'root'
})
export class DataService {

  constructor() { }

  billpdf:billpdf = {
    origen:'',
    destino:'',
    precio:'',
    fecha: new Date(),
    cedula:'',
    tarjeta:'',
  }
  calendar:Calendar = {
    id_calendario:'',
    fecha: new Date(),
    precio:0,
    id_avion:'',
    id_vuelo:0,
    abierto:false,
    pases: [],
    promociones:[],
    facturas:[]
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
}
