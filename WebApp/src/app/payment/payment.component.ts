import { Component } from '@angular/core';
import { Router } from '@angular/router';
import jsPDF from 'jspdf';
import { Credit_card } from '../Interfaces/credit_card.interface';
import { APIService } from '../api.service';
import { ChargeThingsService } from '../charge-things.service';
import { DataService } from '../data.service';
import { Billpost } from '../Interfaces/billpost.intaface';

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

  credit_card:Credit_card = {//an instance of credit card 
    num_tarjeta:0,
    fecha_ex:'',
    cvv:0,
    cedula_cliente: 0
  }

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
    doc.text('Fecha Salida:' /* + Josue: Aquí tiene que agregar la fecha de salida del vuelo*/, 20, 80);
    doc.text('Número de Vuelo:' /* + Josue: Aquí tiene que agregar el nombre|número del vuelo*/, 20, 80);
    doc.text('Cédula:' /* + Josue: Aquí tiene que agregar la cedula del cliente*/, 20, 110);
    doc.text('Tarjeta:'/* + Josue: Aquí tiene que agregar el numero de tarjeta del cliente*/, 20, 120);
  
    // Add the flight information to the PDF
    let y = 150;
    doc.setFontSize(14);
    doc.text('Origen', 20, y);
    doc.text('Destino', 50, y);
    doc.text('Precio', 150, y);

    y += 10;
    doc.line(20, y, 190, y);
    y += 5;

    doc.text(''/*Josue: Aquí tiene que poner el origen del vuelo */, 20, y);
    doc.text(''/*Josue: Aquí tiene que poner el destino del vuelo */, 50, y);
    doc.text('₡'/* + Josue: Aquí tiene que agregar el precio del vuelo */, 150, y);

    y += 5;
    doc.line(20, y, 190, y);
  
    // Save the pdf
    doc.save('FacturaVuelo.pdf');
  }

  onSubmit() {
    this.charge.getClient();//Gets all the clients

    if(this.charge.client.some(item => item.cedula === this.data.client.cedula)){//sees if the client exist
      this.credit_card.cedula_cliente = this.data.client.cedula;//assigns the value of cedula to the credit card cedula cliente
      this.apiservice.postDataTarjeta(this.credit_card);//if the client exist saves the credit card
    }else{
      this.apiservice.postDataCliente(this.data.client)//saves the new client
      this.credit_card.cedula_cliente = this.data.client.cedula;//assigns the value of cedula to the credit card cedula cliente
      this.apiservice.postDataTarjeta(this.credit_card);//if the client exist saves the credit card
    }
    this.billpost.cliente = this.credit_card.cedula_cliente;//assigns the billpost cedula the value of the cedula
    this.billpost.calendario = this.data.calendar.id_calendario;//assings the billpost calendario value the value of id calendario
    this.billpost.tarjeta_cred = this.credit_card.num_tarjeta;//assigns the billpost tarjeta cred the value of the num tarjeta
    this.apiservice.postDataFactura(this.billpost)//saves the new bill
    // Redirect the user to the page of the completed payment
    this.router.navigate(['/thanks']);
  }
}