import { Calendar } from "./calendar.interface";
import { Scales } from "./scales.interface";

export interface Flight{//Interface for saving flight
    id_vuelo:number;
    hora_salida:Date;
    aereo_origen:string;
    aereo_final:string;
    calendarios:Calendar[];
    escalas:Scales[];
}