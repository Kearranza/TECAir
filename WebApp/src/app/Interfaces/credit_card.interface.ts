import { Client } from "./client.interface";

export interface Credit_card{
    num_tarjeta:string;
    cvv:number;
    cedula_cliente: Client;
}
