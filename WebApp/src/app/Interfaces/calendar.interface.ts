import { Boarding_pass } from "./boarding_pass.interface";
import { Sales } from "./sales.interface";

export interface Calendar{
    id_calendario:number;
    fecha:Date;
    precio:number;
    id_avion:string;
    id_vuelo:number;
    pases:Boarding_pass[];
    promociones:Sales[];
}