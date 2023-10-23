import { Bill } from "./bill.interface";
export interface Credit_card{//Interface for saving credit card
    num_tarjeta:number;
    fecha_exp:string;
    cvv:number;
    cedula: number;
    facturas: Bill[]
}
