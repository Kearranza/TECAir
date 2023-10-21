import { Component } from '@angular/core';
import { Router } from '@angular/router';
import jsPDF from 'jspdf';
import { Credit_card } from '../Interfaces/credit_card.interface';
import { APIService } from '../api.service';
import { ChargeThingsService } from '../charge-things.service';
import { DataService } from '../data.service';

@Component({
  selector: 'app-payment',
  templateUrl: './payment.component.html',
  styleUrls: ['./payment.component.css']
})
export class PaymentComponent {
  constructor(private router: Router, private data:DataService, private apiservice:APIService, private charge:ChargeThingsService) {}

  credit_card:Credit_card = {
    num_tarjeta:'',
    fecha_ex:'',
    cvv:0,
    cedula_cliente: 0
  }
  flightInfo = [ 'MEX', 'SJS', 200,123456];
  depatureDate = '01/01/2022';
  ticketNumber = 123456789;
  creditCardNumber = 123456789;

  //Generar PDF, que se descarga automaticamente
  generatePDF() {
    const doc = new jsPDF();

    // Agregar la imagen
    const img = new Image();
    img.src = '../../../assets/TECAirLogo.png';
    doc.addImage(img, 'PNG', 20, 20, 50, 50);
  
    // Agregar el encabezado de la factura
    doc.setFont('Roboto', 'bold');
    doc.setFontSize(22);
    doc.text('Pase de abordaje', 105, 50);
    doc.setFont('Roboto', 'sans-serif');
    doc.setFontSize(16);
    doc.text('Fecha:' + this.depatureDate, 20, 80);
    doc.text('Número de pasaje:' + this.ticketNumber , 20, 90);

    doc.text('Cédula:' + this.flightInfo[3].toString(), 20, 110);
    doc.text('Tarjeta:' + this.creditCardNumber, 20, 120);
  
    // Agregar la información del vuelo
    let y = 150;
    doc.setFontSize(14);
    doc.text('Origen', 20, y);
    doc.text('Destino', 50, y);
    doc.text('Precio', 150, y);

    y += 10;
    doc.line(20, y, 190, y);
    y += 5;

    doc.text(this.flightInfo[0].toString(), 20, y);
    doc.text(this.flightInfo[1].toString(), 50, y);
    doc.text('₡'+this.flightInfo[2].toString(), 150, y);

    y += 5;
    doc.line(20, y, 190, y);
  
    // Guardar el PDF
    doc.save('factura.pdf');
  }

  onSubmit() {
    this.charge.getClient();

    if(this.charge.client.some(item => item.cedula === this.data.client.cedula)){
      this.credit_card.cedula_cliente = this.data.client.cedula;
      this.apiservice.postDataTarjeta(this.credit_card);
    }else{
      this.apiservice.postDataCliente(this.data.client)
      this.credit_card.cedula_cliente = this.data.client.cedula;
      this.apiservice.postDataTarjeta(this.credit_card);
    }
    // Redirigir al usuario a la página de pago efectuado
    this.router.navigate(['/thanks']);
  }
}