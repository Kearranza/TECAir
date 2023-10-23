import { Component, OnInit } from '@angular/core';
import jsPDF from 'jspdf';
import { Router } from '@angular/router';
import { ChargeThingsService } from '../charge-things.service';
import { DataService } from '../data.service';
import { APIService } from '../api.service';
import { Boarding_pass } from '../Interfaces/boarding_pass.interface';
import { Calendar } from '../Interfaces/calendar.interface';
import { SeatPost } from '../Interfaces/seatpost.interface';

interface Seat {
  id:number;
  num_asiento: number;
  disponibilidad: boolean;
  id_avion:string;
}
interface SeatMatrix {
  id:number;
  num_asiento: number;
  disponibilidad: boolean;
  id_avion:string;
  reserved?: boolean;
}
interface SeatGet{
  num_asiento: number;
  disponibilidad: boolean;
}

@Component({
  selector: 'app-seats-selection',
  templateUrl: './seats-selection.component.html',
  styleUrls: ['./seats-selection.component.css']
})

export class SeatsSelectionComponent {

  //Mae necesito esto para el pasaje (puerta de abordaje, hora de salida, asiento y número de vuelo)
  seats: Seat[] = []
  reservedFlight?: SeatMatrix;
  seatsMatrix: SeatMatrix[][] = [];

  boarding_pass:Boarding_pass = { //an intance of boarding pass
    id_pasaje:0,
    puerta: '',
    asiento: '',
    hora_salida:new Date(),
    cedula_cliente:0,
    id_calendario:'',
  }

  seatP:SeatPost = {//an intance for saving seat
    id_mapa_asiento: 0,
    num_asiento: 0,
    disponibilidad:false,
    id_avion:'',
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

  constructor(private router: Router, private data:DataService, private charge:ChargeThingsService, private apiService:APIService) {
  }

  ngOnInit(){
    this.boarding_pass = this.data.getData('checkin');
    this.apiService.getDataECalendario(this.boarding_pass.id_calendario).subscribe(data => {
      this.calendar = data;//Gets the calendario that has the calendario id value from the database
    }, error => {
      console.error('Error:', error);})
    this.apiService.getDataAvionAsientos('HVM816').subscribe(data => {
      console.log(data);
      this.seatsMatrix = this.convertSeatsToMatrix(data);
      this.seats = data;//Gets the calendario that has id avion value from the database
    }, error => {
      console.error('Error:', error);})
    console.log(this.seats);
    console.log(this.seatsMatrix);
  }

  // This method is called when the user clicks on a seat in the UI and reserves it
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

  //Ths method converts the array of seats to a matrix of seats that also add a new property called reserved to be used in the UI
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

      //
      //
      // JOSUE si algo de lo que está aquí no lo puede incluir nada más borra la linea. o hacer magia ;D
      //
      //
      doc.text('Hora de salida:' /* + Josue: Aquí tiene que agregar la hora de salida */, 20, 100);
      doc.text('Puerta de abordaje: '/* + Josue: Aquí tiene que agregar la puerta de abordaje */, 20, 120);
      doc.text('Número de vuelo:' /* + Josue: Aquí tiene que agregar el nombre|número de vuelo */, 20, 140);
      doc.text('Asiento número:' /* + Josue: Aquí tiene que agregar el número de asiento */, 20, 80);
    
      // Save the pdf
      doc.save('PaseAbordaje.pdf');

      this.seatP.id_mapa_asiento = this.reservedFlight?.id
      this.seatP.num_asiento = this.reservedFlight?.num_asiento
      this.seatP.disponibilidad = this.reservedFlight?.disponibilidad
      this.seatP.id_avion = this.reservedFlight?.id_avion

      this.router.navigate(['/admin-selector']);
    }


  PostU(){//calls the service to save user
      this.apiService.postDataPaseA(this.boarding_pass).subscribe(data => {
        console.log(this.boarding_pass)
        console.log('Funca U')
      })
  }
  UpdateS(){//calls the service to save user
    this.apiService.updateDataAsiento(this.seatP, this.seatP.id_mapa_asiento).subscribe(data => {
      console.log(this.boarding_pass)
      console.log('Funca S')
    })
}
}