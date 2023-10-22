import { Calendar } from "./calendar.interface";

export interface Bill{//Interface for saving bill
    id_factura:number;
    cliente:number;
    tarjeta_cred:number;
    calendario:string;
}
