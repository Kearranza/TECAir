import { Component, OnInit } from '@angular/core';

interface Seat {
  number: number;
  occupied: boolean;
}

@Component({
  selector: 'app-seats-selection',
  templateUrl: './seats-selection.component.html',
  styleUrls: ['./seats-selection.component.css']
})
export class SeatsSelectionComponent implements OnInit {

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
    { number: 30, occupied: false }
  ];

  reserved: Seat[] = [];
  activeSelection?: Seat;

  ngOnInit() {
    this.seats = this.addReservedProperty(this.seats);
  }

  addReservedProperty(seats: Seat[]) {
    return seats.map(seat => ({ ...seat, reserved: false }));
  }

  reserveSeat(seat: Seat) {
    if (seat.occupied) {
      return;
    }

    if (this.activeSelection) {
      if (this.activeSelection === seat) {
        this.activeSelection = undefined;
        return;
      }

      if (this.reserved.includes(this.activeSelection)) {
        this.reserved.splice(this.reserved.indexOf(this.activeSelection), 1);
      }
    }

    this.activeSelection = seat;

    this.reserved.push(seat);
  }
}