import { Component, OnInit} from '@angular/core';

@Component({
  selector: 'app-seats-selection',
  templateUrl: './seats-selection.component.html',
  styleUrls: ['./seats-selection.component.css']
})
export class SeatsSelectionComponent implements OnInit {
  seats: { id: number, number: number, available: boolean, active: boolean }[][] = [];
  activeSelection: { id: number, number: number, available: boolean } | null = null;

  ngOnInit() {
    // Replace this with your actual seat data
    const seatData = [
      { id: 1, number: '1', available: true },
      { id: 2, number: '2', available: false },
      { id: 3, number: '3', available: true },
      { id: 4, number: '4', available: true },
      { id: 5, number: '5', available: false },
      { id: 6, number: '6', available: true },
      { id: 7, number: '7', available: true },
      { id: 8, number: '8', available: true },
      { id: 9, number: '9', available: false },
      { id: 10, number: '10', available: true },
      { id: 11, number: '11', available: true },
      { id: 12, number: '12', available: true },
      { id: 13, number: '13', available: true },
      { id: 14, number: '14', available: true },
      { id: 15, number: '15', available: true },
      { id: 16, number: '16', available: false },
      { id: 17, number: '17', available: true },
      { id: 18, number: '18', available: true },
      { id: 19, number: '19', available: true },
      { id: 20, number: '20', available: true },
      { id: 21, number: '21', available: true },
      { id: 22, number: '22', available: true },
      { id: 23, number: '23', available: true },
      { id: 24, number: '24', available: true },
      { id: 25, number: '25', available: true },
      { id: 26, number: '26', available: true },
      { id: 27, number: '27', available: true },
      { id: 28, number: '28', available: true },
      { id: 29, number: '29', available: true },
      { id: 30, number: '30', available: true },
    ];

    // Calculate the number of rows needed based on the number of seats
    const numRows = Math.ceil(seatData.length / 6);

    // Loop through the seat data and create the seats list
    for (let i = 0; i < numRows; i++) {
      const row: { id: number, number: number, available: boolean, active: boolean }[] = [];
      for (let j = 0; j < 6; j++) {
        const seatIndex = i * 6 + j;
        if (seatIndex < seatData.length) {
          const seat = seatData[seatIndex];
          row.push({ id: seat.id, number: parseInt(seat.number), available: seat.available, active: false });
        } else {
          row.push({ id: 0, number: 0, available: false, active: false });
        }
      }
      this.seats.push(row);
    }
  }

  // Reserve or unreserve a seat
  reserveSeat(seat: { id: number, number: number, available: boolean, active: boolean } | null) {
    if (seat && seat.available) {
      seat.available = false;
      seat.active = true;
      this.activeSelection = seat;
    } else if (seat !== null) {
      seat.available = true;
      seat.active = false;
      this.activeSelection = null;
    }
  }
}