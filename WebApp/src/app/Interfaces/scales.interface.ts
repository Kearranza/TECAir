import { Flight } from "./flight.interface";

export interface Scales{
    id_escala:number;
    orden_lugares:string;
    origen:string;
    destino:string;
    id_vuelo:Flight;
}