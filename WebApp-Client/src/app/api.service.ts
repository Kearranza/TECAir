import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http'
import { Observable } from 'rxjs';
import { Airport } from './Interfaces/airport.interface';
import { Baggage } from './Interfaces/baggage.interface';
import { Bill } from './Interfaces/bill.interface';
import { Boarding_pass } from './Interfaces/boarding_pass.interface';
import { Calendar } from './Interfaces/calendar.interface';
import { Client } from './Interfaces/client.interface';
import { Credit_card } from './Interfaces/credit_card.interface';
import { Flight } from './Interfaces/flight.interface';
import { Plane } from './Interfaces/plane.interface';
import { Sales } from './Interfaces/sales.interface';
import { Scales } from './Interfaces/scales.interface';
import { SeatPost } from './Interfaces/seatpost.interface';
import { Student } from './Interfaces/student.interface';
import { User } from './Interfaces/user.interface';
import { Color } from './Interfaces/color.interface';
import { Userpost } from './Interfaces/userpost.interface';
import { Display_flight } from './Interfaces/displayflight.interface';
import { Display_promo } from './Interfaces/displaypromo.interface';
import { Salespost } from './Interfaces/salespost.interface';
import { Billpost } from './Interfaces/billpost.intaface';
import { BaggagePost } from './Interfaces/baggagepost.interface'; 
import { Boarding_passpost } from './Interfaces/boarding_passpost.interface';

@Injectable({
  providedIn: 'root'
})
export class APIService {

  //Url of the API
  private urlApi = 'http://localhost:3333'

  constructor(private http: HttpClient) { }

  //Methods of Get, Post, Update, Delete 
  getDataAeropuerto(): Observable<Airport[]> {//
    const url = `${this.urlApi}/${'aeropuerto'}`;
    return this.http.get<Airport[]>(url)
  }

  getDataEAeropuerto(id:string): Observable<Airport> {
    const url  = `${this.urlApi}/${id}/${'aeropuerto'}`;
    return this.http.get<Airport>(url)
  }

  postDataAeropuerto(data: Airport): Observable<Airport> {
    const url = `${this.urlApi}/${'aeropuerto'}`;
    return this.http.post<Airport>(url, data);
  }

  updateDataAeropuerto(id: string, data: Airport): Observable<any> {
    const url = `${this.urlApi}/${'aeropuerto'}/id?id=${id}`;
    return this.http.put(url, data);
  }

  deleteDataAeropuerto(id: string): Observable<any> {
    const url = `${this.urlApi}/${'aeropuerto'}/id?id=${id}`;
    return this.http.delete(url);
  }

  getDataAvion(): Observable<Plane[]> {
    const url = `${this.urlApi}/${'avion'}`;
    return this.http.get<Plane[]>(url)
  }

  getDataEAvion(id:string): Observable<Plane> {
    const url  = `${this.urlApi}/${id}/${'avion'}`;
    return this.http.get<Plane>(url)
  }

  getDataAvionAsientos(id:string): Observable<any> {
    const url = `${this.urlApi}/${'avion'}/${id}/${'asientos'}`;
    return this.http.get<any>(url)
  }

  getDataAvionDisponible(): Observable<any> {
    const url = `${this.urlApi}/${'avion'}`;
    return this.http.get<any>(url)
  }

  postDataAvion(data: Plane): Observable<Plane> {
    const url = `${this.urlApi}/${'avion'}`;
    return this.http.post<Plane>(url, data);
  }

  updateDataAvion(id: number, data: any): Observable<any> {
    const url = `${this.urlApi}/${'avion'}/id?id=${id}`;
    return this.http.put(url, data);
  }

  DeleteDataAvion(id: number): Observable<any> {
    const url = `${this.urlApi}/${'avion'}/id?id=${id}`;
    return this.http.delete(url);
  }

  getDataFactura(): Observable<Bill[]> {
    const url = `${this.urlApi}/${'factura'}`;
    return this.http.get<Bill[]>(url)
  }

  getDataEFactura(id:string): Observable<Bill> {
    const url  = `${this.urlApi}/${id}/${'factura'}`;
    return this.http.get<Bill>(url)
  }

  postDataFactura(data: Billpost): Observable<Billpost> {
    const url = `${this.urlApi}/${'factura'}`;
    return this.http.post<Billpost>(url, data);
  }

  updateDataFactura(id: number, data: any): Observable<any> {
    const url = `${this.urlApi}/${'factura'}/id?id=${id}`;
    return this.http.put(url, data);
  }

  DeleteDataFactura(id: number): Observable<any> {
    const url = `${this.urlApi}/${'factura'}/id?id=${id}`;
    return this.http.delete(url);
  }

  getDataCliente(): Observable<Client[]> {
    const url = `${this.urlApi}/${'cliente'}`;
    return this.http.get<Client[]>(url)
  }

  getDataECliente(id:number): Observable<Client> {
    const url  = `${this.urlApi}/${id}/${'cliente'}`;
    return this.http.get<Client>(url)
  }

  postDataCliente(data: Client): Observable<Client> {
    const url = `${this.urlApi}/${'cliente'}`;
    return this.http.post<Client>(url, data);
  }

  updateDataCliente(id: number, data: any): Observable<any> {
    const url = `${this.urlApi}/${'cliente'}/id?id=${id}`;
    return this.http.put(url, data);
  }

  DeleteDataCliente(id: number): Observable<any> {
    const url = `${this.urlApi}/${'cliente'}/id?id=${id}`;
    return this.http.delete(url);
  }

  getDataColor(): Observable<Color[]> {
    const url = `${this.urlApi}/${'color'}`;
    return this.http.get<Color[]>(url)
  }

  getDataEColor(id:string): Observable<Color> {
    const url  = `${this.urlApi}/${id}/${'color'}`;
    return this.http.get<Color>(url)
  }

  postDataColor(data: Color): Observable<Color> {
    const url = `${this.urlApi}/${'color'}`;
    return this.http.post<Color>(url, data);
  }

  updateDataColor(id: number, data: any): Observable<any> {
    const url = `${this.urlApi}/${'color'}/id?id=${id}`;
    return this.http.put(url, data);
  }

  DeleteDataColor(id: number): Observable<any> {
    const url = `${this.urlApi}/${'color'}/id?id=${id}`;
    return this.http.delete(url);
  }

  getDataCalendario(): Observable<Calendar[]> {
    const url = `${this.urlApi}/${'calendar'}`;
    return this.http.get<Calendar[]>(url)
  }

  getDataCalendarioV(): Observable<Display_flight[]> {
    const url = `${this.urlApi}/${'calendar'}/${'info'}`;
    return this.http.get<Display_flight[]>(url)
  }

  getDataCalendarioP(): Observable<Display_promo[]> {
    const url = `${this.urlApi}/${'calendar'}/${'promos'}`;
    return this.http.get<Display_promo[]>(url)
  }

  getDataECalendario(id:string): Observable<Calendar> {
    const url  = `${this.urlApi}/${id}/${'calendar'}`;
    return this.http.get<any>(url)
  }

  postDataCalendario(data: Calendar): Observable<Calendar> {
    const url = `${this.urlApi}/${'calendar'}`;
    return this.http.post<Calendar>(url, data);
  }

  updateDataCalendario(id: string, data: Calendar): Observable<any> {
    const url = `${this.urlApi}/${'calendar'}/id?id=${id}`;
    return this.http.put(url, data);
  }

  DeleteDataCalendario(id: number): Observable<any> {
    const url = `${this.urlApi}/${'calendar'}/id?id=${id}`;
    return this.http.delete(url);
  }

  getDataVuelos(): Observable<Flight[]> {
    const url = `${this.urlApi}/${'vuelos'}`;
    return this.http.get<Flight[]>(url)
  }

  getDataEVuelos(id:number): Observable<Flight> {
    const url  = `${this.urlApi}/${id}/${'vuelos'}`;
    return this.http.get<Flight>(url)
  }

  postDataVuelos(data: Flight): Observable<Flight> {
    const url = `${this.urlApi}/${'vuelos'}`;
    return this.http.post<Flight>(url, data);
  }

  updateDataVuelos(id: number, data: any): Observable<any> {
    const url = `${this.urlApi}/${'vuelos'}/id?id=${id}`;
    return this.http.put(url, data);
  }

  DeleteDataVuelos(id: number): Observable<any> {
    const url = `${this.urlApi}/${'vuelos'}/id?id=${id}`;
    return this.http.delete(url);
  }

  getDataPromociones(): Observable<Sales[]> {
    const url = `${this.urlApi}/${'promociones'}`;
    return this.http.get<Sales[]>(url)
  }

  getDataEPromociones(id:string): Observable<Sales> {
    const url  = `${this.urlApi}/${id}/${'promociones'}`;
    return this.http.get<Sales>(url)
  }

  postDataPromociones(data: Salespost): Observable<Salespost> {
    const url = `${this.urlApi}/${'promociones'}`;
    return this.http.post<Salespost>(url, data);
  }

  updateDataPromociones(id: number, data: any): Observable<any> {
    const url = `${this.urlApi}/${'promociones'}/id?id=${id}`;
    return this.http.put(url, data);
  }

  DeleteDataPromociones(id: number): Observable<any> {
    const url = `${this.urlApi}/${'promociones'}/id?id=${id}`;
    return this.http.delete(url);
  }

  getDataEscala(): Observable<Scales[]> {
    const url = `${this.urlApi}/${'escala'}`;
    return this.http.get<Scales[]>(url)
  }

  getDataEEscala(id:string): Observable<Scales> {
    const url  = `${this.urlApi}/${id}/${'escala'}`;
    return this.http.get<Scales>(url)
  }

  postDataEscala(data: Scales): Observable<Scales> {
    const url = `${this.urlApi}/${'escala'}`;
    return this.http.post<Scales>(url, data);
  }

  updateDataEscala(id: number, data: any): Observable<any> {
    const url = `${this.urlApi}/${'escala'}/id?id=${id}`;
    return this.http.put(url, data);
  }

  DeleteDataEscala(id: number): Observable<any> {
    const url = `${this.urlApi}/${'escala'}/id?id=${id}`;
    return this.http.delete(url);
  }

  getDataAsiento(): Observable<SeatPost[]> {
    const url = `${this.urlApi}/${'asiento'}`;
    return this.http.get<SeatPost[]>(url)
  }

  getDataEAsiento(id:string): Observable<SeatPost> {
    const url  = `${this.urlApi}/${id}/${'asiento'}`;
    return this.http.get<SeatPost>(url)
  }

  postDataAsiento(data: SeatPost): Observable<SeatPost> {
    const url = `${this.urlApi}/${'asiento'}`;
    return this.http.post<SeatPost>(url, data);
  }

  updateDataAsiento(data: SeatPost, id?: number): Observable<any> {
    const url = `${this.urlApi}/${'asiento'}/id?id=${id}`;
    return this.http.put(url, data);
  }

  DeleteDataAsiento(id: number): Observable<any> {
    const url = `${this.urlApi}/${'asiento'}/id?id=${id}`;
    return this.http.delete(url);
  }

  getDataEstudiante(): Observable<Student[]> {
    const url = `${this.urlApi}/${'estudiante'}`;
    return this.http.get<Student[]>(url)
  }

  getDataEEstudiante(id:number): Observable<Student> {
    const url  = `${this.urlApi}/${id}/${'estudiante'}`;
    return this.http.get<Student>(url)
  }

  postDataEstudiante(data: Student): Observable<Student> {
    const url = `${this.urlApi}/${'estudiante'}`;
    return this.http.post<Student>(url, data);
  }

  updateDataEstudiante(id: number, data: any): Observable<any> {
    const url = `${this.urlApi}/${'estudiante'}/id?id=${id}`;
    return this.http.put(url, data);
  }

  DeleteDataEstudiante(id: number): Observable<any> {
    const url = `${this.urlApi}/${'estudiante'}/id?id=${id}`;
    return this.http.delete(url);
  }

  getDataMaleta(): Observable<Baggage[]> {
    const url = `${this.urlApi}/${'maleta'}`;
    return this.http.get<Baggage[]>(url)
  }

  getDataEMaleta(id:string): Observable<Baggage> {
    const url  = `${this.urlApi}/${id}/${'maleta'}`;
    return this.http.get<Baggage>(url)
  }

  postDataMaleta(data: BaggagePost): Observable<BaggagePost> {
    const url = `${this.urlApi}/${'maleta'}`;
    return this.http.post<BaggagePost>(url, data);
  }

  updateDataMaleta(id: number, data: any): Observable<any> {
    const url = `${this.urlApi}/${'maleta'}/id?id=${id}`;
    return this.http.put(url, data);
  }

  DeleteDataMaleta(id: number): Observable<any> {
    const url = `${this.urlApi}/${'maleta'}/id?id=${id}`;
    return this.http.delete(url);
  }

  getDataTarjeta(): Observable<Credit_card[]> {
    const url = `${this.urlApi}/${'tarjeta'}`;
    return this.http.get<Credit_card[]>(url)
  }

  getDataETarjeta(id:string): Observable<Credit_card> {
    const url  = `${this.urlApi}/${id}/${'tarjeta'}`;
    return this.http.get<Credit_card>(url)
  }

  postDataTarjeta(data: Credit_card): Observable<Credit_card> {
    const url = `${this.urlApi}/${'tarjeta'}`;
    return this.http.post<Credit_card>(url, data);
  }

  updateDataTarjeta(id: number, data: any): Observable<any> {
    const url = `${this.urlApi}/${'tarjeta'}/id?id=${id}`;
    return this.http.put(url, data);
  }

  DeleteDataTarjeta(id: number): Observable<any> {
    const url = `${this.urlApi}/${'tarjeta'}/id?id=${id}`;
    return this.http.delete(url);
  }

  getDataPaseA(): Observable<Boarding_pass[]> {
    const url = `${this.urlApi}/${'pase_abordar'}`;
    return this.http.get<Boarding_pass[]>(url)
  }

  getDataEPaseA(id:string): Observable<Boarding_pass> {
    const url  = `${this.urlApi}/${id}/${'pase_abordar'}`;
    return this.http.get<Boarding_pass>(url)
  }

  postDataPaseA(data: Boarding_passpost): Observable<Boarding_passpost> {
    const url = `${this.urlApi}/${'pase_abordar'}`;
    return this.http.post<Boarding_passpost>(url, data);
  }

  updateDataPaseA(id: number, data: any): Observable<any> {
    const url = `${this.urlApi}/${'pase_abordar'}/id?id=${id}`;
    return this.http.put(url, data);
  }

  DeleteDataPaseA(id: number): Observable<any> {
    const url = `${this.urlApi}/${'pase_abordar'}/id?id=${id}`;
    return this.http.delete(url);
  }

  getDataUser(): Observable<User[]> {
    const url = `${this.urlApi}/${'user'}`;
    return this.http.get<User[]>(url)
  }

  getDataEUser(id:string): Observable<User> {
    const url  = `${this.urlApi}/${id}/${'user'}`;
    return this.http.get<User>(url)
  }

  postDataUser(data: Userpost): Observable<Userpost> {
    const url = `${this.urlApi}/${'user'}`;
    return this.http.post<Userpost>(url, data);
  }

  updateDataUser(id: number, data: User): Observable<any> {
    const url = `${this.urlApi}/${'user'}/id?id=${id}`;
    return this.http.put(url, data);
  }

  DeleteDataUser(id: number): Observable<any> {
    const url = `${this.urlApi}/${'user'}/id?id=${id}`;
    return this.http.delete(url);
  }
}
