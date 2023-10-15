import { Plane } from "./plane.interface";
import { Flight } from "./flight.interface";
import { Airport } from "./airport.interface";

export interface Calendar{
    id_calendario:number;
    date:Date;
    id_avion:Plane;
    id_vuelo:Flight;
    aereo_destino:Airport
    hora_salida:Date;
}