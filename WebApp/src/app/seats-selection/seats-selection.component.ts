import { Component, OnInit } from '@angular/core';
import jsPDF from 'jspdf';
import { Router } from '@angular/router';
import { ChargeThingsService } from '../charge-things.service';
import { DataService } from '../data.service';

interface Seat {
  num_asiento: number;
  disponibilidad: boolean;
}
interface SeatMatrix {
  num_asiento: number;
  disponibilidad: boolean;
  reserved?: boolean;
}

@Component({
  selector: 'app-seats-selection',
  templateUrl: './seats-selection.component.html',
  styleUrls: ['./seats-selection.component.css']
})

export class SeatsSelectionComponent {

  //Mae necesito esto para el pasaje (puerta de abordaje, hora de salida, asiento y número de vuelo)

  seats: Seat[] = [
    { num_asiento: 1, disponibilidad: false },
    { num_asiento: 2, disponibilidad: true },
    { num_asiento: 3, disponibilidad: false },
    { num_asiento: 4, disponibilidad: false },
    { num_asiento: 5, disponibilidad: false },
    { num_asiento: 6, disponibilidad: false },
    { num_asiento: 7, disponibilidad: false },
    { num_asiento: 8, disponibilidad: false },
    { num_asiento: 9, disponibilidad: false },
    { num_asiento: 10, disponibilidad: false },
    { num_asiento: 11, disponibilidad: false },
    { num_asiento: 12, disponibilidad: false },
    { num_asiento: 13, disponibilidad: false },
    { num_asiento: 14, disponibilidad: false },
    { num_asiento: 15, disponibilidad: false },
    { num_asiento: 16, disponibilidad: false },
    { num_asiento: 17, disponibilidad: false },
    { num_asiento: 18, disponibilidad: false },
    { num_asiento: 19, disponibilidad: false },
    { num_asiento: 20, disponibilidad: false },
    { num_asiento: 21, disponibilidad: false },
    { num_asiento: 22, disponibilidad: false },
    { num_asiento: 23, disponibilidad: false },
    { num_asiento: 24, disponibilidad: false },
    { num_asiento: 25, disponibilidad: false },
    { num_asiento: 26, disponibilidad: false },
    { num_asiento: 27, disponibilidad: false },
    { num_asiento: 28, disponibilidad: false },
    { num_asiento: 29, disponibilidad: false },
    { num_asiento: 30, disponibilidad: false },
  ];

  reservedFlight?: SeatMatrix;

  seatsMatrix: SeatMatrix[][] = [];

  constructor(private router: Router, private data:DataService, private charge:ChargeThingsService) {
    this.seatsMatrix = this.convertSeatsToMatrix(this.seats);
  }

  //
  reserveSeat(seat: SeatMatrix) {
    if (!seat.disponibilidad) {
      if (this.reservedFlight === seat) {
        seat.reserved = !seat.reserved;
        this.reservedFlight = seat.reserved ? seat : undefined;
      } else if (!this.reservedFlight || !this.reservedFlight.reserved) {
        seat.reserved = true;
        this.reservedFlight = seat;
      }
    }
    console.log(this.reservedFlight);
  }

  private convertSeatsToMatrix(seats: Seat[]): Seat[][] {
    const seatsWithReserved = seats.map(seat => ({ ...seat, reserved: false }));
    const groupsOfSix = [];
    for (let i = 0; i < seatsWithReserved.length; i += 6) {
      groupsOfSix.push(seatsWithReserved.slice(i, i + 6));
    }
    return groupsOfSix;
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
      doc.text('Pase de abordaje', 105, 50);
      doc.setFont('Roboto', 'sans-serif');
      doc.setFontSize(16);
      doc.text('Fecha:', 20, 80);
      doc.text('Número de pasaje:', 20, 90);
  
      doc.text('Cédula:', 20, 110);
      doc.text('Tarjeta:', 20, 120);
    
      // Save the pdf
      doc.save('factura.pdf');
    }

    onSubmit() {}
}