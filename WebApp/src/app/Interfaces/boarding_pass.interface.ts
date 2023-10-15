import { Client } from "./client.interface";
import { Calendar } from "./calendar.interface";

export interface Boarding_pass{
    id_pasaje:number;
    puerta: string;
    asiento: string;
    hora_salida:Date;
    cedula_cliente:Client
    id_calendario:Calendar
}
