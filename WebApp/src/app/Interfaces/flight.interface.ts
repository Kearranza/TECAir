import { Plane } from "./plane.interface";
import { Airport } from "./airport.interface";

export interface Flight{
    id_vuelo:number;
    avion:Plane;
    aereo_destino: Airport;
    hora_salida: Date
}