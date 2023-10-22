import { Component, OnInit } from '@angular/core';
import jsPDF from 'jspdf';
import { Router } from '@angular/router';
import { ChargeThingsService } from '../charge-things.service';
import { DataService } from '../data.service';

interface Seat {
  number: number;
  occupied: boolean;
}
interface SeatMatrix {
  number: number;
  occupied: boolean;
  reserved?: boolean;
}

@Component({
  selector: 'app-seats-selection',
  templateUrl: './seats-selection.component.html',
  styleUrls: ['./seats-selection.component.css']
})

export class SeatsSelectionComponent {

  seats: Seat[] = [
    { number: 1, occupied: false },
    { number: 2, occupied: true },
    { number: 3, occupied: false },
    { number: 4, occupied: false },
    { number: 5, occupied: false },
    { number: 6, occupied: false },
    { number: 7, occupied: false },
    { number: 8, occupied: false },
    { number: 9, occupied: false },
    { number: 10, occupied: false },
    { number: 11, occupied: false },
    { number: 12, occupied: false },
    { number: 13, occupied: false },
    { number: 14, occupied: false },
    { number: 15, occupied: false },
    { number: 16, occupied: false },
    { number: 17, occupied: false },
    { number: 18, occupied: false },
    { number: 19, occupied: false },
    { number: 20, occupied: false },
    { number: 21, occupied: false },
    { number: 22, occupied: false },
    { number: 23, occupied: false },
    { number: 24, occupied: false },
    { number: 25, occupied: false },
    { number: 26, occupied: false },
    { number: 27, occupied: false },
    { number: 28, occupied: false },
    { number: 29, occupied: false },
    { number: 30, occupied: false },
  ];

  activeSelection?: SeatMatrix;

  seatsMatrix: SeatMatrix[][] = [];

  constructor(private router: Router, private data:DataService, private charge:ChargeThingsService) {
    this.seatsMatrix = this.convertSeatsToMatrix(this.seats);
  }

  //
  reserveSeat(seat: SeatMatrix) {
    if (!seat.occupied) {
      if (this.activeSelection === seat) {
        seat.reserved = !seat.reserved;
        this.activeSelection = seat.reserved ? seat : undefined;
      } else if (!this.activeSelection || !this.activeSelection.reserved) {
        seat.reserved = true;
        this.activeSelection = seat;
      }
    }
    console.log(this.activeSelection);
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
}