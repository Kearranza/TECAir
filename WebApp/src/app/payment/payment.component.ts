import { Component } from '@angular/core';
import { Router } from '@angular/router';
import { ChargeThingsService } from '../charge-things.service';
import jsPDF from 'jspdf';

@Component({
  selector: 'app-payment',
  templateUrl: './payment.component.html',
  styleUrls: ['./payment.component.css']
})
export class PaymentComponent {
  constructor(private router: Router, private charge:ChargeThingsService) {}

  generatePDF() {
    const doc = new jsPDF();

    // Agregar la imagen
    const product = [ 'MEX', 'SJS', 200,123456];
    const img = new Image();
    img.src = '../../../assets/TECAirLogo.png';
    doc.addImage(img, 'PNG', 20, 20, 50, 50);
  
    // Agregar el encabezado de la factura
    doc.setFont('Roboto', 'bold');
    doc.setFontSize(22);
    doc.text('Pase de abordaje', 105, 50);
    doc.setFont('Roboto', 'sans-serif');
    doc.setFontSize(16);
    doc.text('Fecha: 01/01/2022', 20, 80);
    doc.text('Número de factura: 123456', 20, 90);

    doc.text('Cédula:'+product[3].toString(), 20, 110);
    doc.text('Tarjeta: 123456', 20, 120);
  
    // Agregar la tabla de productos
    let y = 150;
    doc.setFontSize(14);
    doc.text('Origen', 20, y);
    doc.text('Destino', 50, y);
    doc.text('Precio', 150, y);

    y += 10;
    doc.line(20, y, 190, y);
    y += 5;

    doc.text(product[0].toString(), 20, y);
    doc.text(product[1].toString(), 50, y);
    doc.text(product[2].toString(), 150, y);

    y += 5;
    doc.line(20, y, 190, y);
  
    // Guardar el PDF
    doc.save('factura.pdf');
  }

  onSubmit() {
      // Redirigir al usuario a la página de inicio.
      this.router.navigate(['/thanks']);
    }
}