import { Injectable } from '@angular/core';
import { billpdf } from './Interfaces/billpdf.interface';
import { Calendar } from './Interfaces/calendar.interface';
import { Client } from './Interfaces/client.interface';
import { Boarding_pass } from './Interfaces/boarding_pass.interface';

@Injectable({
  providedIn: 'root'
})
export class DataService {//Makes a service for mantein data between pages

  constructor() { }

  billpdf:billpdf = {//Creates an intance for billpdf
    origen:'',
    destino:'',
    precio:0,
    fecha: 0,
    cedula:'',
    tarjeta:'',
  }
  id_calendario: string = '';
  
  client:Client = {//Creates an intance for client
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

  boarding_pass:Boarding_pass = {//Creates an intance for boarding pass
    id_pasaje:0,
    puerta: '',
    asiento: '',
    hora_salida:new Date(),
    cedula_cliente:0,
    id_calendario:'',
  }

  setData(key: string, data: any) {
    sessionStorage.setItem(key, JSON.stringify(data));
  }

  getData(key: string) {
    const data = sessionStorage.getItem(key);
    return data ? JSON.parse(data) : null;
  }
}
