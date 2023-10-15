import { Calendar } from "./calendar.interface";

export interface Sales{
    id_promo:number;
    descuento:number;
    fecha_inicio:Date;
    fecha_fin:Date;
    aplicado_calendario:Calendar

}
