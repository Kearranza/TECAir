import { Boarding_pass } from "./boarding_pass.interface";
import { Sales } from "./sales.interface";
import { Bill } from "./bill.interface";

export interface Calendar{//Interface for saving calendar
    id_calendario:string;
    fecha:Date;
    precio:number;
    id_avion:string;
    id_vuelo:number;
    abierto:boolean;
    pases:Boarding_pass[];
    promociones:Sales[];
    facturas:Bill[];
}
