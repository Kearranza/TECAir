import { Seat } from "./seat.interface";
import { Calendar } from "./calendar.interface";

export interface Plane{ //Interface for saving plane
    placa:string;
    row:number;
    pcolum:number;
    calendarios:Calendar[];
    asientos:Seat[];
}