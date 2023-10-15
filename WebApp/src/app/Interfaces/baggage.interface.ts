import { Client } from "./client.interface";
import { Boarding_pass } from "./boarding_pass.interface";

export interface Baggage{
    id_maleta:number;
    cedula:Client;
    peso:number;
    color:string;
    id_pasaje:Boarding_pass
}