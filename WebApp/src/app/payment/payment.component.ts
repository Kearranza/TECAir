import { Component } from '@angular/core';
import { Router } from '@angular/router';
import jsPDF from 'jspdf';
import { Credit_card } from '../Interfaces/credit_card.interface';
import { APIService } from '../api.service';
import { ChargeThingsService } from '../charge-things.service';
import { DataService } from '../data.service';
import { Billpost } from '../Interfaces/billpost.intaface';
import { Calendar } from '../Interfaces/calendar.interface';
import { Client } from '../Interfaces/client.interface';
import { billpdf } from '../Interfaces/billpdf.interface';

@Component({
  selector: 'app-payment',
  templateUrl: './payment.component.html',
  styleUrls: ['./payment.component.css']
})
export class PaymentComponent {

  constructor(private router: Router, private data:DataService, private apiservice:APIService, private charge:ChargeThingsService) {}

  billpost:Billpost = {//an instance of billpost
    cliente:0,
    tarjeta_cred:0,
    calendario:''
  }

  billpdf:billpdf = {//an intance of billpdf
    origen:'',
    destino:'',
    precio:0,
    fecha: 0,
    cedula:'',
    tarjeta:'',
  }

  client: Client = { //an instance of client
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

  credit_card:Credit_card = {//an instance of credit card 
    num_tarjeta:0,
    fecha_exp:'',
    cvv:0,
    cedula: 0,
    facturas: []
  }

  calendar:Calendar = {//an intance of calendar
    id_calendario: '',
    fecha:new Date(),
    precio:0,
    id_avion: '',
    id_vuelo: 0,
    abierto: false,
    pases: [],
    promociones: [],
    facturas: [],
  }  

  ngOnInit(){
    this.client = this.data.getData('client');
    this.billpdf = this.data.getData('billpdf');
    console.log(this.client);
    console.log(this.billpdf);
  }

  flightInfo = [ 'MEX', 'SJS', 200,123456];
  depatureDate = '01/01/2022';
  ticketNumber = 123456789;
  creditCardNumber = 123456789;

  //Generate PDF, which is automatically downloaded
  generatePDF() {
    const doc = new jsPDF();

    // Add the image to the PDF
    const img = new Image();
    img.src = '../../../assets/TECAirLogo.png';
    doc.addImage(img, 'PNG', 20, 20, 50, 50);
  
    // Add the text to the PDF and set the font
    doc.setFont('Roboto', 'bold');
    doc.setFontSize(22);
    doc.text('Factura de Vuelo', 105, 50);
    doc.setFont('Roboto', 'sans-serif');
    doc.setFontSize(16);
    doc.text('Fecha Salida:' +this.billpdf.fecha, 20, 80);
    doc.text('Número de Vuelo:' +this.data.getData('calendario'), 20, 80);
    doc.text('Cédula:' +this.client.cedula, 20, 110);
    doc.text('Tarjeta:'+this.credit_card.num_tarjeta, 20, 120);
  
    // Add the flight information to the PDF
    let y = 150;
    doc.setFontSize(14);
    doc.text('Origen', 20, y);
    doc.text('Destino', 50, y);
    doc.text('Precio', 150, y);

    y += 10;
    doc.line(20, y, 190, y);
    y += 5;

    doc.text(this.billpdf.origen/*Josue: Aquí tiene que poner el origen del vuelo */, 20, y);
    doc.text(this.billpdf.destino/*Josue: Aquí tiene que poner el destino del vuelo */, 50, y);
    doc.text('₡' +this.billpdf.precio, 150, y);

    y += 5;
    doc.line(20, y, 190, y);
  
    // Save the pdf
    doc.save('FacturaVuelo.pdf');
  }

  onSubmit() {
    this.charge.getClient();//Gets all the clients
    this.credit_card.cedula = Number(this.client.cedula);
    console.log(this.credit_card)
    this.billpost.cliente = Number(this.credit_card.cedula);//assigns the billpost cedula the value of the cedula
    this.billpost.calendario = this.data.getData('calendario');//assings the billpost calendario value the value of id calendario
    this.billpost.tarjeta_cred = Number(this.credit_card.num_tarjeta);//assigns the billpost tarjeta cred the value of the num tarjeta
    this.PostC();
    this.PostT();
    console.log(this.billpost)
    this.PostF();//saves the new bill
    // Redirect the user to the page of the completed payment
    this.router.navigate(['/thanks']);
  }

  PostF(){//calls the service to save client
    this.apiservice.postDataFactura(this.billpost).subscribe(data => {
      console.log(this.billpost)
      console.log('Funca F')
    })
  }
  PostC(){//calls the service to save client
    this.apiservice.postDataCliente(this.client).subscribe(data => {
      console.log(this.client)
      console.log('Funca C')
    })
  }
  PostT(){//calls the service to save client
    this.apiservice.postDataTarjeta(this.credit_card).subscribe(data => {
      console.log(this.credit_card)
      console.log('Funca T')
    })
  }
}