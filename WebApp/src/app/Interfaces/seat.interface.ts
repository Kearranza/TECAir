import { Plane } from "./plane.interface";

export interface Seat{
    id_asiento: number;
    num_asiento: string;
    disponibilidad:boolean;
    id_avion:Plane

}
