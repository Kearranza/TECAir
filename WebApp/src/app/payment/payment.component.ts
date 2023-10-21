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

  generatePDF() {
    const doc = new jsPDF();

    // Agregar la imagen
    const img = new Image();
    img.src = '../../../assets/TECAirLogo.png';
    doc.addImage(img, 'PNG', 20, 20, 50, 50);
  
    // Agregar el encabezado de la factura
    doc.setFontSize(22);
    doc.text('Factura', 105, 20);
    doc.setFontSize(16);
    doc.text('Fecha: 01/01/2022', 20, 40);
    doc.text('Número de factura: 123456', 20, 50);
  
    // Agregar la tabla de productos
    const products = [
      { name: 'Producto 1', price: 10 },
      { name: 'Producto 2', price: 20 },
      { name: 'Producto 3', price: 30 },
    ];
    let y = 70;
    doc.setFontSize(14);
    doc.text('Productos', 20, y);
    doc.text('Precio', 150, y);
    y += 10;
    doc.line(20, y, 190, y);
    y += 5;
    products.forEach(product => {
      doc.text(product.name, 20, y);
      doc.text(product.price.toString(), 150, y);
      y += 10;
    });
  
    // Agregar el total de la factura
    const total = products.reduce((acc, product) => acc + product.price, 0);
    doc.line(20, y, 190, y);
    y += 10;
    doc.text('Total:', 20, y);
    doc.text(total.toString(), 150, y);
  
    // Guardar el PDF
    doc.save('factura.pdf');
  }

  onSubmit() {
    this.charge.getClient();
      // Redirigir al usuario a la página de inicio.
    if(this.charge.client.some(item => item.cedula === this.data.client.cedula)){
      this.credit_card.cedula_cliente = this.data.client.cedula;
      this.apiservice.postDataTarjeta(this.credit_card);
    }else{
      this.apiservice.postDataCliente(this.data.client)
      this.credit_card.cedula_cliente = this.data.client.cedula;
      this.apiservice.postDataTarjeta(this.credit_card);
    }
    this.router.navigate(['/thanks']);
  }
}