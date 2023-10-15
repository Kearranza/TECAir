import { Calendar } from "./calendar.interface";

export interface Bill{
    id_factura:number;
    precio:number;
    cantidad:number;
    total:number;
    cedula_cliente:number;
    calendario_vuelo:Calendar;
    tarjeta_credito:number;
}
